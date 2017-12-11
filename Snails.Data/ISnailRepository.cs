using System.Threading.Tasks;
using Snails.Data.Entities;

namespace Snails.Data
{
    public interface ISnailRepository : IRepository<Snail, string>
    {
        Task<Snail> GetSnailByAuthToken(string authToken);
    }
}