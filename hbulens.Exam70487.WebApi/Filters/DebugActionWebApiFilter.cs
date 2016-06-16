using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace hbulens.Exam70487.WebApi
{
    public class DebugActionWebApiFilter : ActionFilterAttribute
    {
        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            Debug.WriteLine("DebugActionWebApiFilter's OnActionExecutedAsync was fired.");
            return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        }

        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            Debug.WriteLine("DebugActionWebApiFilter's OnActionExecutingAsync was fired.");
            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }
    }
}
