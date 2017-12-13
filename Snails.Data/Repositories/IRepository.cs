using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snails.Data.Repositories
{
    public interface IRepository<TEntityType, in TKeyType>
    {
        Task<IEnumerable<TEntityType>> SelectAll();

        Task<TEntityType> SelectById(TKeyType id);

        Task Insert(TEntityType entity);

        Task Update(TEntityType entity);

        Task Delete(TKeyType id);
    }
}