using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.CrossDomain;
using WebApplication1.Models;

namespace WebApplication1.DataAccess
{
    public class SnailRepository : ISnailRepository
    {
        private Dictionary<string, Snail> _snails;

        public SnailRepository()
        {
            _snails = new Dictionary<string, Snail>();
        }

        public Task<IEnumerable<Snail>> SelectAll()
        {
            _snails.Add("xoxo", new Snail() { Id = "xoxo", IsAlive = true, ShellRadius = 4.4 });
            // !!! Изцяло презентационна цел. Това се случва защото нямаме наистина асинхронна база от данни.
            return Task.FromResult(_snails.Values.AsEnumerable());
        }

        public Task<Snail> SelectById(string id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Snail entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Snail entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}