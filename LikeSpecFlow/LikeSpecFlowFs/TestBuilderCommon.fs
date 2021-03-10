module internal LikeSpecFlowFs.TestBuilderCommon

open FSharp.Quotations
open FSharp.Quotations.Patterns
open FSharp.Quotations.Evaluator

let createStepFromExpr (expr : Expr<TestStep>) =
    let rec unravelBindings expr =
        match expr with
        | Let(var, arg, body) ->
            let (bindings, finalBody) = unravelBindings body
            let bindings = bindings |> Map.add var arg
            (bindings, finalBody)
        | _ -> (Map.empty, expr)

    let (letBindings, body) = unravelBindings expr

    let prettyPrint =
        match body with
        | Lambda(_, Call(_, methodInfo, args)) ->
            let args =
                args
                |> List.take (args.Length - 1)
                |> List.map (function
                    | Var(v) -> letBindings |> Map.find v
                    | e -> e)
                |> List.map QuotationEvaluator.EvaluateUntyped

            AutoPrettyPrint.autoPrettyPrint methodInfo.Name args
        | _ -> failwith "Bad expr"

    (prettyPrint, QuotationEvaluator.Evaluate expr)