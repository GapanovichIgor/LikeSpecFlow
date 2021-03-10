module LikeSpecFlowFs.AutoPrettyPrint

open System.Text.RegularExpressions

let private parameterPlaceholderRegex = Regex("\<\s*\w+\s*\>")

let autoPrettyPrint name (arguments : obj list) : PrettyPrint =
    let placeholdersMatches = parameterPlaceholderRegex.Matches(name)

    if placeholdersMatches.Count <> arguments.Length then failwith "Argument count doesn't match the parameter count"

    let placeHolderPositions = [ for m in placeholdersMatches -> (m.Index, m.Length) ]

    let parameterSubstitutions =
        List.zip placeHolderPositions arguments
        |> List.map (fun ((ind, len), a) -> (ind, len, a))

    [
        let mutable i = 0

        for (paramStart, paramLen, value) in parameterSubstitutions do
            yield (Plain, name.Substring(i, paramStart - i))
            yield (Parameter, string value)
            i <- paramStart + paramLen

        yield (Plain, name.Substring(i))
    ]