namespace Commons.Exceptions.Http
{
    public class NotFoundException : BaseExceptionAbstract
    {
        public NotFoundException(string error) : base(error) { }
    }
}
