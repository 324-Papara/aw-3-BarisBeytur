namespace Para.Api.Middleware
{

    /// <summary>
    /// Bu middleware, request ve response'ları loglamak için kullanılır.
    /// </summary>
    public class LoggerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<LoggerMiddleware> _logger;

        public LoggerMiddleware(RequestDelegate next, ILogger<LoggerMiddleware> logger)
        {
            this.next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            // before controller invoke

            // logging the request
            _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path} {context.Request.QueryString} {context.Request.Headers} {context.Request.Body}");

            await next.Invoke(context);

            // after controller invoke

            // logging the response
            _logger.LogInformation($"Response: {context.Response.StatusCode} {context.Response.ContentType} {context.Response.Body}");
        }
    }
}
