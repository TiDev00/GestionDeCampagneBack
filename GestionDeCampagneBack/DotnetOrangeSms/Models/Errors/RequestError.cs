namespace DotnetOrangeSms.Models.Errors
{
    public class RequestError
    {
        public ServiceException ServiceException { get; set; }

        public PolicyException PolicyException { get; set; }
    }
}
