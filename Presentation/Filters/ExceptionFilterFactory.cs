using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;

namespace Presentation.Filters
{
    //  💫 Similiar to well known pattern factory - each filter interface
    //          (like IExceptionFilter, IActionFilter) implements IFilterMetadata
    //          this interface nothing more than filter action, so every IFilterMetadata
    //          realization will be attempted to cast to IFilterFactory to produce filter instance ✨
    public class ExceptionFilterFactory : Attribute, IFilterFactory
    {
        //  ᓚᘏᗢ Something like singleton, created instance must be
        //          reused in future calls(if true)
        public bool IsReusable => false;
        //  ᓚᘏᗢ Now we can add this filter with [ExceptionFilterFactory]
        //  ᓚᘏᗢ Also we don't have to register our filter!
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider) =>
            new ExceptionFilter(serviceProvider.GetService(typeof(IHostEnvironment)) as IHostEnvironment); 
    }
}
