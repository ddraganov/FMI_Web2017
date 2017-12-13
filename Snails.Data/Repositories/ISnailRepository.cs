using System.Threading.Tasks;
using Snails.Data.Entities;

namespace Snails.Data.Repositories
{
    public interface ISnailRepository : IRepository<Snail, string>
    {
        Task<Snail> GetSnailByAuthToken(string authToken);
        Task EnterSnailIntoCompetition(string snailId, int competitionId);
    }
}