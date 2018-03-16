using System;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace AspNetFundamentals.Infractructure.Constraints
{
    public class RequiredHeaderActionConstraint :IActionConstraint
    {
        private readonly string header;

        public RequiredHeaderActionConstraint(string header)
        {
            this.header = header;
        }

        public bool Accept(ActionConstraintContext context)
        {
            return context.RouteContext.HttpContext.Request.Headers.ContainsKey(header);
        }

        public int Order { get; } = 300;
    }
}
