namespace Services.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message = "Not found.") : base(message)
        {
        }
    }
}
