module LikeSpecFlowFs.DefaultTestSteps

let ``initialize Selenium with parameter`` param =
    { new TestStep with
        member _.PrettyPrint =
            [ Plain, "Initialize Selenium With "
              Parameter, param
              Plain, " Parameter" ] }

let ``open page`` (url : string) =
    { new TestStep with
        member _.PrettyPrint =
            [ Plain, "Open Page "
              Parameter, url ] }

let ``wait for element to be clickable`` element =
    { new TestStep with
        member _.PrettyPrint =
            [ Plain, "Wait For Element "
              Parameter, element
              Plain, " To Be Clickable" ] }


let ``input text into control`` control text =
    { new TestStep with
        member _.PrettyPrint =
            [ Plain, "Input "
              Parameter, text
              Plain, " Into Control "
              Parameter, control ] }

let ``click on control`` control =
    { new TestStep with
        member _.PrettyPrint =
            [ Plain, "Click On "
              Parameter, control
              Plain, " Control" ] }

let ``assert element exists`` element =
    { new TestStep with
        member _.PrettyPrint =
            [ Plain, "Assert Element "
              Parameter, element
              Plain, " Exists" ]}