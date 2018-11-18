namespace CleanArchitectureV3.AspCoreApp.Commands
{
    public class CommandResult
    {
        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        public static CommandResult SuccessResult() => new CommandResult { Success = true };

        public static CommandResult FailureResult(string errorMessage) => new CommandResult { ErrorMessage = errorMessage };
    }

    public class CommandResult<T> : CommandResult
    {
        public T Data { get; set; }

        public static CommandResult<T> SuccessResult(T data) => new CommandResult<T> { Success = true, Data = data };
    }
}
