module LikeSpecFlowFs.DefaultTestSteps

open LikeSpecFlowFs.AutoPrettyPrint

let rec ``Initialize Selenium with <parameter> parameter`` param =
    { new TestStep with
        member _.PrettyPrint = autoPrettyPrint (nameof ``Initialize Selenium with <parameter> parameter``) [param] }

let rec ``Open page <url>`` (url : string) =
    { new TestStep with
        member _.PrettyPrint = autoPrettyPrint (nameof ``Open page <url>``) [url] }

let rec ``Wait for element <selector> to be clickable`` element =
    { new TestStep with
        member _.PrettyPrint = autoPrettyPrint (nameof ``Wait for element <selector> to be clickable``) [element] }

let rec ``Input <text> into <selector> control`` control text =
    { new TestStep with
        member _.PrettyPrint = autoPrettyPrint (nameof ``Input <text> into <selector> control``) [control; text] }

let rec ``Click on <selector> control`` control =
    { new TestStep with
        member _.PrettyPrint = autoPrettyPrint (nameof ``Click on <selector> control``) [control] }

let rec ``Assert element <selector> exists`` element =
    { new TestStep with
        member _.PrettyPrint = autoPrettyPrint (nameof ``Assert element <selector> exists``) [element] }