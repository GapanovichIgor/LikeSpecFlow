open LikeSpecFlowFs.Test
open LikeSpecFlowFs.TestFragment
open LikeSpecFlowFs.DefaultTestSteps

let ``fill login form`` name password =
    testFragment {
        ``input text into control`` "Name" name
        ``input text into control`` "Password" password
    }

let loginSuccessTest =
    test "Login test" {
        ``initialize Selenium with parameter`` "/nocache"

        ``open page`` "mail.ru"
        ``wait for element to be clickable`` "loginButton"
        ``fill login form`` "jon@mail.ru" "123"

        ``click on control`` "Login"

        ``assert element exists`` "logo"
    }

[<EntryPoint>]
let main argv =
    prettyPrint loginSuccessTest

    0