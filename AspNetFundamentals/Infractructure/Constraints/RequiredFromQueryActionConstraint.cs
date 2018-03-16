using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace AspNetFundamentals.Infractructure.Constraints
{
    public class RequiredFromQueryActionConstraint : IActionConstraint
    {
        private readonly string parameter;

        public RequiredFromQueryActionConstraint(string parameter)
        {
            this.parameter = parameter;
        }

        //Some framework build int action constrains have 200 order -> We make sure our runs last
        public int Order => 500;

        public bool Accept(ActionConstraintContext context)
        {
            var request = context.RouteContext.HttpContext.Request;
            if (request.Query.ContainsKey(parameter) && request.Query[parameter].FirstOrDefault().Length > 0)
            {
                return true;
            }

            return false;
        }
    }
}
