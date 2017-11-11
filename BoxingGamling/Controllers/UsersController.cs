using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BoxingGamling.Controllers
{
    public class UsersController : ApiController
    {
        public int Get()
        {
            return 42;
        }

        //[HttpGet]
        //public int Test()
        //{
        //    return 43;
        //}

        //[HttpGet]
        //public int Test1()
        //{
        //    return 1;
        //}
    }
}
