namespace LikeSpecFlowFs

type TestExecutionContext =
    { log : string -> unit }

type TestStep = TestExecutionContext -> unit