
using API_Project.Helpers.CustomExceptions;
using System.Net;
using System.Text.Json;

namespace API_Project.Helpers
{
    public class ErrorsHandler
    {
        private readonly RequestDelegate _next;
        public ErrorsHandler(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {

                var result = context.Response;
                result.ContentType= "application/json";
                switch (error) 
                {
                    case AppException e:
                        result.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        result.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                        default:
                        result.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var res = JsonSerializer.Serialize(new { message = error?.Message });
                await result.WriteAsync(res);

            }


        }
    }

}
