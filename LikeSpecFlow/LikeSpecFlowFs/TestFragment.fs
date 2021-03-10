module LikeSpecFlowFs.TestFragment

open FSharp.Quotations

type TestFragment = { steps : (PrettyPrint * TestStep) list }

type TestFragmentBuilder() =
    member _.Zero() = { steps = [] }

    member _.Yield([<ReflectedDefinition>] step : Expr<TestStep>) =
        { steps = [TestBuilderCommon.createStepFromExpr step] }

    member _.Yield(fragment : TestFragment) = fragment

    member _.Combine(fragment1, fragment2) =
        { steps = fragment1.steps @ fragment2.steps }

    member _.Delay(f) = f()

let testFragment = TestFragmentBuilder()