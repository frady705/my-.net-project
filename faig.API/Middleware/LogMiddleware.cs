using NLog;

namespace faig.API.Middleware
{
    public class LogMiddleware
    {

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly RequestDelegate _next;

        public LogMiddleware(RequestDelegate next)
        {
            _next = next;
        }
           int num = 0;
        public async Task Invoke(HttpContext context)

        {
            num++;
            Console.WriteLine($"Action number {num}");
            logger.Info($"The Request {context.Request.Method} is starting");
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"its failed! {ex.Message}");
            }

            logger.Info($"The status is: {context.Response.StatusCode}");
        }
    }
}
