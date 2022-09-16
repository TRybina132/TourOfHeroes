using Service.ServicesAbstractions;

namespace TourOfHeroes.Middleware
{
    //  ᓚᘏᗢ When we're using factory based middleware we must register
    //          it as service(like scoped or transient), we don't have to implement factory it will
    //          be created by default one
    public class ExceptionMiddleware : IMiddleware
    {
        //  ᓚᘏᗢ Now we can inject services
        private readonly ILogService logService;

        public ExceptionMiddleware(ILogService logService)
        {
            this.logService = logService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(Exception ex)
            {
                context.Response.StatusCode = 501;
                await context.Response.WriteAsync(ex.ToString());
                await logService.LogAsync(ex.ToString());
            }
        }
    }
}
