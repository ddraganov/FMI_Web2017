using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Snails.Data.Entities;
using Snails.Data.Repositories;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/competitions")]
    public class CompetitionsController : ApiController
    {
        private readonly ICompetitionRepository _competitionRepository;


        public CompetitionsController(ICompetitionRepository CompetitionRepository)
        {
            _competitionRepository = CompetitionRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Competition>> GetCompetitions()
        {
            return await _competitionRepository.SelectAll().ConfigureAwait(false);
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> CreateCompetition(Competition Competition)
        {
            await _competitionRepository.Insert(Competition).ConfigureAwait(false);

            return Created(Request.RequestUri, Competition);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Competition> GetCompetition(int id)
        {
            return await _competitionRepository.SelectById(id).ConfigureAwait(false);
        }
    }
}
