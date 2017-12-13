using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Snails.Data.Entities;
using Snails.Data.Repositories;

namespace Snails.Controllers
{
    [RoutePrefix("api/snails")]
    public class SnailsController : ApiController
    {
        private readonly ISnailRepository _snailRepository;
        private readonly ICompetitionRepository _competitionRepository;

        // Ако това е потребител може да се изнесе в базов клас за контролерите за да не се повтаря във всички
        private Snail _currentSnail;

        public SnailsController(ISnailRepository snailRepository, ICompetitionRepository competitionRepository)
        {
            _snailRepository = snailRepository;
            _competitionRepository = competitionRepository;
        }

        public void SetCurrentSnail(Snail currentSnail)
        {
            _currentSnail = currentSnail;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Snail>> GetSnails()
        {
            return await _snailRepository.SelectAll().ConfigureAwait(false);
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> CreateSnail(Snail snail)
        {
            var existingSnail = await _snailRepository.SelectById(snail.Id).ConfigureAwait(false);
            if (existingSnail != null)
            {
                return BadRequest("Snail with this id already exists");
            }

            await _snailRepository.Insert(snail).ConfigureAwait(false);

            return Created(Request.RequestUri, snail);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Snail> GetSnail(string id)
        {
            return await _snailRepository.SelectById(id).ConfigureAwait(false);
        }

        [HttpPost]
        [Route("{snailId}/competitions/{competitionId}")]
        public async Task<IHttpActionResult> EnterSnailIntoCompetition(string snailId, int competitionId)
        {
            var snail = await _snailRepository.SelectById(snailId).ConfigureAwait(false);
            if (snail == null)
            {
                return BadRequest("Snail does not exist");
            }
            if (!snail.IsAlive)
            {
                return BadRequest("Snail is already dead");
            }

            var competition = await _competitionRepository.SelectById(competitionId).ConfigureAwait(false);
            if (competition == null)
            {
                return BadRequest("Competition does not exist");
            }

            await _snailRepository.EnterSnailIntoCompetition(snailId, competitionId).ConfigureAwait(false);

            return Ok();
        }

        [HttpDelete]
        public void Opi([FromUri]int page, [FromBody]int sth)
        {

        }
    }
}
