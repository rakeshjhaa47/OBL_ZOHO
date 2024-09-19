using OBL_Zoho.Models.Response;
using System.Net;

namespace AnyTimePediatricsAPI.Middleware
{
    public static class ExtensionMethods
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }
    }

    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;

        public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
        {
            this.next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context != null)
            {
                try
                {
                    await next(context).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    _logger.LogError(ex, ex.Message);
                    await LogExceptionToFileAsync(ex);
                    await HandleExceptionAsync(context, ex).ConfigureAwait(false);
                }
            }
        }

        private static async Task LogExceptionToFileAsync(Exception exception)
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "exception");
            Directory.CreateDirectory(folderPath);

            var fileName = $"{DateTime.Now:yyyy-MM-dd}.log"; // Create a filename with the current date
            var filePath = Path.Combine(folderPath, fileName);

            var logMessage = $"{DateTime.Now}: {exception.Message}\n{exception.StackTrace}\n";
            await File.AppendAllTextAsync(filePath, logMessage);
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string result = new ErrorDetails()
            {
                Message = exception.Message,
                StatusCode = context.Response.StatusCode
            }.ToString();

            return context.Response.WriteAsync(result);
        }
    }
}
