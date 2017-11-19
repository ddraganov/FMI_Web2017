using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using WebApplication1.CrossDomain;
using WebApplication1.DataAccess;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [AuthenticationFilter]
    public class SnailsController : ApiController
    {
        private readonly ISnailRepository _snailRepository;

        public SnailsController(ISnailRepository snailRepository)
        {
            _snailRepository = snailRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Snail>> GetSnails()
        {
            //throw new TypedDataSetGeneratorException();
            return await _snailRepository.SelectAll();
        }

        //[HttpPost]
        //public Snail CreateSnail(Snail snail)
        //{
        //    snail.Id = Guid.NewGuid().ToString();
        //    _snails.Add(snail);
        //    return snail;
        //}

        //[HttpGet]
        //public Snail GetSnail(string id)
        //{
        //    return _snails.First(x => x.Id == id);
        //}

        [HttpDelete]
        public void Opi([FromUri]int page, [FromBody]int sth)
        {
            
        }
    }
}
