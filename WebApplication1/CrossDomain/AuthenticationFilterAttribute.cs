using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApplication1.CrossDomain
{
    public class AuthenticationFilterAttribute : ActionFilterAttribute
    {
        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            IEnumerable<string> authValues;
            if (!actionContext.Request.Headers.TryGetValues("AuthToken", out authValues) ||
                authValues.First() == "super-secure-token")
                throw new HttpResponseException(HttpStatusCode.Unauthorized);

            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }
    }
}