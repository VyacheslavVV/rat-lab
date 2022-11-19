using Billing_API.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Billing_API.Filters;

public class ExampleActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ActionArguments.ContainsKey("order"))
        {
            var order = context.ActionArguments["order"] as Order;

            if (order is not null)
            {
                order.Description += " (modified by Action filter)";

                context.ActionArguments["order"] = order;
            }
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // no action
    }
}