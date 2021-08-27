namespace Services.Exceptions
{
    public class ValidationException : BaseException
    {
        public ValidationException(string message = "Validation error.") : base(message)
        {
        }
    }
}
