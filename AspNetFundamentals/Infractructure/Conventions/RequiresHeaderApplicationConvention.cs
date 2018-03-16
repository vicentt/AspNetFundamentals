using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AspNetFundamentals.Infractructure.Attributes;
using AspNetFundamentals.Infractructure.Constraints;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace AspNetFundamentals.Infractructure.Conventions
{
    public class RequiresHeaderApplicationConvention :IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            var applicableActions = GetConventionApplicationActions(application);

            foreach (var action in applicableActions)
            {
                foreach (var selector in action.Selectors)
                {
                    var requiredAttribute = action.ActionMethod.GetCustomAttribute<RequiredHeaderAttribute>();
                    selector.ActionConstraints.Add(new RequiredHeaderActionConstraint(requiredAttribute.Header));
                }
            }
        }

        public IEnumerable<ActionModel> GetConventionApplicationActions(ApplicationModel application)
        {
            return application.Controllers.SelectMany(c => c.Actions)
                .Where(a => a.ActionMethod.GetCustomAttribute<RequiredHeaderAttribute>() != null)
                .ToList();
        }

    }
}
