using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication1.CrossDomain;
using WebApplication1.DataAccess;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SnailsController : ApiController
    {
        private readonly ISnailRepository _snailRepository;

        // Ако това е потребител може да се изнесе в базов клас за контролерите за да не се повтаря във всички
        private Snail _currentSnail;

        public SnailsController(ISnailRepository snailRepository)
        {
            _snailRepository = snailRepository;
        }

        public void SetCurrentSnail(Snail currentSnail)
        {
            _currentSnail = currentSnail;
        }

        [HttpGet]
        public async Task<IEnumerable<Snail>> GetSnails()
        {
            //throw new System.Exception();
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
