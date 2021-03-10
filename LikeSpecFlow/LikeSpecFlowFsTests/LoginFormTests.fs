module LoginFormTests

open LikeSpecFlowFs.Test
open LikeSpecFlowFs.DefaultTestSteps
open Xunit

[<Fact>]
let loginSuccessTest () =
    let test =
        test "Login test" {
            ``initialize Selenium with parameter`` "/nocache"
        }

    prettyPrint test

    ()