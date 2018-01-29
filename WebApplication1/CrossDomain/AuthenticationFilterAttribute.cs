using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Security;
using Autofac.Integration.WebApi;
using WebApplication1.Controllers;
using WebApplication1.DataAccess;
using WebApplication1.Models;

namespace WebApplication1.CrossDomain
{
    public class AuthenticationFilterAttribute : ActionFilterAttribute, IAutofacActionFilter
    {
        private readonly ISnailRepository _snailRepository;

        public AuthenticationFilterAttribute(ISnailRepository snailRepository)
        {
            // Инджекнат по молба от студент, просто за пример. Затова не се ползва реално
            _snailRepository = snailRepository;
        }

        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            IEnumerable<string> authValues;
            if (!actionContext.Request.Headers.TryGetValues("AuthToken", out authValues) ||
                // Тук трябва да проверите стойността на хедъра дали е валиден token. За презентационни  цели ползваме статична стойност.
                authValues.First() != "super-secure-token")
                throw new HttpResponseException(HttpStatusCode.Unauthorized);

            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }
    }
}