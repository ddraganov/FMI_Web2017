using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Autofac.Integration.WebApi;
using Snails.Controllers;
using Snails.Data.Entities;
using Snails.Data.Repositories;

namespace WebApplication1.CrossDomain
{
    public class AuthenticationFilterAttribute : ActionFilterAttribute, IAutofacActionFilter
    {
        private readonly ISnailRepository _snailRepository;

        public AuthenticationFilterAttribute(ISnailRepository snailRepository)
        {
            _snailRepository = snailRepository;
        }

        public override async Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            IEnumerable<string> authValues;
            if (!actionContext.Request.Headers.TryGetValues("AuthToken", out authValues))
                throw new HttpResponseException(HttpStatusCode.Unauthorized);

            Snail snail = await _snailRepository.GetSnailByAuthToken(authValues.First());

            if (snail == null)
                throw new HttpResponseException(HttpStatusCode.Unauthorized);

            ((SnailsController)actionContext.ControllerContext.Controller).SetCurrentSnail(snail);

            await base.OnActionExecutingAsync(actionContext, cancellationToken);
        }
    }
}