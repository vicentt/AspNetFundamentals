using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;

namespace AspNetFundamentals.Infractructure.Filters
{
    public class NonRequiredFormatFilter : FormatFilter
    {
        public NonRequiredFormatFilter(IOptions<MvcOptions> options) : base(options) { }
        public override string GetFormat(ActionContext context)
        {
            var format = base.GetFormat(context);
            return format ?? "json";
        }
    }
}
