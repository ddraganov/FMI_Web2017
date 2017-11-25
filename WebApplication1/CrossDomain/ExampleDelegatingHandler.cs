using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication1.CrossDomain
{
    public class ExampleDelegatingHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // просто тестов handler
            Trace.WriteLine("Just saying hi");

            return base.SendAsync(request, cancellationToken);
        }
    }
}