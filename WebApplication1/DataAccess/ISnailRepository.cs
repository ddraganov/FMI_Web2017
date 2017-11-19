using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DataAccess
{
    public interface ISnailRepository : IRepository<Snail, string>
    {
    }
}