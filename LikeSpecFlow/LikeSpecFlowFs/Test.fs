module LikeSpecFlowFs.Test

open System
open FSharp.Quotations
open LikeSpecFlowFs.TestFragment

type Test =
    { name : string
      steps : (PrettyPrint * TestStep) list }

type TestBuilder(name) =
    member _.Zero() =
        { name = name
          steps = [] }

    member _.Yield([<ReflectedDefinition>] step : Expr<TestStep>) =
        { name = name
          steps = [TestBuilderCommon.createStepFromExpr step] }

    member _.Yield(fragment : TestFragment) =
        { name = name
          steps = fragment.steps }

    member this.Yield() = this.Zero()

    member _.Combine(test1, test2) =
        { name = name
          steps = test1.steps @ test2.steps }

    member _.Delay(f) = f()

let test name = TestBuilder(name)

let run context test =
    for (_, f) in test.steps do
        f context

type PrintStyle =
    { plainTextColor : ConsoleColor
      parameterColor : ConsoleColor }

let prettyPrint style test =
    let consoleColorBefore = Console.ForegroundColor

    let printCol color (text : string) =
        let consoleColor =
            match color with
            | Plain -> style.plainTextColor
            | Parameter -> style.parameterColor
        Console.ForegroundColor <- consoleColor
        Console.Write(text)

    let mutable stepNumber = 1

    for (prettyPrint, _) in test.steps do
        printCol Plain $"Step {stepNumber}: "

        for (color, text) in prettyPrint do
            printCol color text

        Console.WriteLine()

        stepNumber <- stepNumber + 1

    Console.ForegroundColor <- consoleColorBefore
