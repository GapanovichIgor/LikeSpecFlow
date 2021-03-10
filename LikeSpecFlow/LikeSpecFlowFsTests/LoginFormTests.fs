module LoginFormTests

open LikeSpecFlowFs.Test
open LikeSpecFlowFs.DefaultTestSteps
open Xunit

[<Fact>]
let loginSuccessTest () =
    let test =
        test "Login test" {
            ``Initialize Selenium with <parameter> parameter`` "/nocache"
        }

    prettyPrint test

    ()