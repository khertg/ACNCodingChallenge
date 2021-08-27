namespace Services.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string message = "Bad request.") : base(message)
        {
        }
    }
}
