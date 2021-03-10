open LikeSpecFlowFs.Test
open LikeSpecFlowFs.TestFragment
open LikeSpecFlowFs.DefaultTestSteps

let ``fill login form`` name password =
    testFragment {
        ``Input <text> into <selector> control`` "Name" name
        ``Input <text> into <selector> control`` "Password" password
    }

let loginSuccessTest =
    test "Login test" {
        ``Initialize Selenium with <parameter> parameter`` "/nocache"

        ``Open page <url>`` "mail.ru"
        ``Wait for element <selector> to be clickable`` "loginButton"

        includeFragment (
            ``fill login form`` "jon@mail.ru" "123"
        )

        ``Click on <selector> control`` "Login"

        ``Assert element <selector> exists`` "logo"
    }

[<EntryPoint>]
let main argv =
    prettyPrint loginSuccessTest

    0