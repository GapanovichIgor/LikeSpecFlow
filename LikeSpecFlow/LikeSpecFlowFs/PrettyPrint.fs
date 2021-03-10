namespace LikeSpecFlowFs

type TextColor =
    | Plain
    | Parameter

type ColoredText = TextColor * string

type PrettyPrint = ColoredText list