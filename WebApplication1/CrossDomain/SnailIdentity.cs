using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace WebApplication1.CrossDomain
{
    public class SnailIdentity : IIdentity
    {
        public SnailIdentity(string id)
        {
            Name = id;
        }

        public string Name { get; }

        public string AuthenticationType => "AuthenticatedSnail";

        public bool IsAuthenticated => true;
    }
}