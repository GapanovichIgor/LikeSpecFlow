open System
open LikeSpecFlowFs
open LikeSpecFlowFs.Test
open LikeSpecFlowFs.TestFragment

// Steps
let ``Initialize Selenium with <parameter> parameter`` (param : string) (ctx : TestExecutionContext) =
    ctx.log (sprintf "Initialized Selenium! %s" param)

let ``Open page <url>`` (url : string) (ctx : TestExecutionContext) =
    ctx.log (sprintf "Opened page! %s" url)

let ``Wait for element <selector> to be clickable`` (element : string) (ctx : TestExecutionContext) =
    ctx.log (sprintf "Waited for an element! %s" element)

let ``Input <text> into <selector> control`` (text : string) (control : string) (ctx : TestExecutionContext) =
    ctx.log (sprintf "Inputted text into control! %s %s" text control)

let ``Click on <selector> control`` (control : string) (ctx : TestExecutionContext) =
    ctx.log (sprintf "Clicked on control! %s" control)

let ``Assert element <selector> exists`` (element : string) (ctx : TestExecutionContext) =
    ctx.log (sprintf "Asserted that element exists! %s" element)

// Test fragment
let ``fill login form`` name password =
    testFragment {
        ``Input <text> into <selector> control`` name "Name"
        ``Input <text> into <selector> control`` password "Password"
    }

// Test
let loginSuccessTest =
    test "Login test" {
        ``Initialize Selenium with <parameter> parameter`` "/nocache"

        ``Open page <url>`` "mail.ru"
        ``Wait for element <selector> to be clickable`` "loginButton"

        ``fill login form`` "jon@mail.ru" "123"

        ``Click on <selector> control`` "Login"

        ``Assert element <selector> exists`` "logo"
    }

[<EntryPoint>]
let main argv =
    prettyPrint loginSuccessTest

    let executionContext = { log = Console.WriteLine }
    run executionContext loginSuccessTest

    0