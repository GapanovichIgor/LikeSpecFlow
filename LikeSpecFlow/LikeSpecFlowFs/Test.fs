module LikeSpecFlowFs.Test

open System
open LikeSpecFlowFs.TestFragment

type Test =
    { name : string
      steps : TestStep list }

type TestBuilder(name) =
    member _.Zero() =
        { name = name
          steps = [] }

    member _.Yield(step : TestStep) =
        { name = name
          steps = [step] }

    member _.Yield(fragment : TestFragment) =
        { name = name
          steps = fragment.steps }

    member this.Yield() = this.Zero()

    member _.Combine(test1, test2) =
        { name = name
          steps = test1.steps @ test2.steps }

    member _.Delay(f) = f()

let test name = TestBuilder(name)

let prettyPrint test =
    let consoleColorBefore = Console.ForegroundColor

    let printCol color (text : string) =
        let consoleColor =
            match color with
            | Plain -> ConsoleColor.Yellow
            | Parameter -> ConsoleColor.Green
        Console.ForegroundColor <- consoleColor
        Console.Write(text)

    let mutable stepNumber = 1

    for step in test.steps do
        printCol Plain $"Step {stepNumber}: "

        for (color, text) in step.PrettyPrint do
            printCol color text

        Console.WriteLine()

        stepNumber <- stepNumber + 1

    Console.ForegroundColor <- consoleColorBefore
