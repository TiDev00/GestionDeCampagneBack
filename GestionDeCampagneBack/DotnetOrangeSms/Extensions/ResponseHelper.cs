using DotnetOrangeSms.Models;
using System.Net;

namespace DotnetOrangeSms.Extensions
{
    public static class ResponseHelper
    {
        public static Result<T> GetError<T>((HttpStatusCode code, string result) response) where T:class
        {
            return new Result<T>(false, $"error_code: {(int)response.code}, body: {response.result}", null);
        }
    }
}
