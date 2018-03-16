using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetFundamentals.Infractructure.Filters
{
    public class ShortCircuitResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.Result = new ContentResult()
            {
                Content = "The site is under maintenance"
            };
        }
        public void OnResourceExecuted(ResourceExecutedContext context) { }

    }
}
