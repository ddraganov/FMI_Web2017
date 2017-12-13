using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Snails.Data.Entities;

namespace Snails.Data.Repositories
{
    public class SnailRepository : BaseRepository, ISnailRepository
    {
        public SnailRepository(IDbSettings settings) : base(settings)
        {
        }

        public async Task<IEnumerable<Snail>> SelectAll()
        {
            using (var connection = CreateConnection())
            {
                var snails = await connection.QueryAsync<Snail>("SELECT * FROM Snails").ConfigureAwait(false);

                return snails.ToList();
            }
        }

        public async Task<Snail> SelectById(string id)
        {
            using (var connection = CreateConnection())
            {
                var snails = await connection
                    .QueryAsync<Snail>("SELECT * FROM Snails WHERE Id = @Id",
                        new { Id = id }).ConfigureAwait(false);

                return snails.SingleOrDefault();
            }
        }

        public async Task Insert(Snail entity)
        {
            using (var connection = CreateConnection())
            {
                await connection.ExecuteAsync(@"INSERT INTO 
                    Snails (Id, ShellRadius, Length, IsAlive)
                    VALUES (@Id, @ShellRadius, @Length, @IsAlive)", entity).ConfigureAwait(false);
            }
        }

        public Task Update(Snail entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Snail> GetSnailByAuthToken(string authToken)
        {
            // Просто примерно. тук трябва да има обръщение към база данни/вънешн ресурс/друго за проверка на authToken
            return Task.FromResult(new Snail() { Id = "xoxo", IsAlive = true, ShellRadius = 4.4 });
        }

        public async Task EnterSnailIntoCompetition(string snailId, int competitionId)
        {
            using (var connection = CreateConnection())
            {
                var parameters = new
                {
                    SnailId = snailId,
                    CompetitionId = competitionId
                };

                await connection.ExecuteAsync(@"INSERT INTO 
                    SnailsCompetitions (SnailId, CompetitionId)
                    VALUES (@SnailId, @CompetitionId)", parameters).ConfigureAwait(false);
            }
        }
    }
}