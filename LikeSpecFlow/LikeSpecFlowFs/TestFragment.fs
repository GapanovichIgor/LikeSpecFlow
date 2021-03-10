module LikeSpecFlowFs.TestFragment

type TestFragment = { steps : TestStep list }

type TestFragmentBuilder() =
    member _.Zero() = { steps = [] }
    member _.Yield(step : TestStep) = { steps = [step] }
    member _.Yield(fragment : TestFragment) = fragment
    member _.Combine(fragment1, fragment2) =
        { steps = fragment1.steps @ fragment2.steps }
    member _.Delay(f) = f()

let testFragment = TestFragmentBuilder()