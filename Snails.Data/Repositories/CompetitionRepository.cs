using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Snails.Data.Entities;

namespace Snails.Data.Repositories
{
    public class CompetitionRepository : BaseRepository, ICompetitionRepository
    {
        public CompetitionRepository(IDbSettings settings) : base(settings)
        {
        }

        public async Task<IEnumerable<Competition>> SelectAll()
        {
            using (var connection = CreateConnection())
            {
                var competitions = await connection.QueryAsync<Competition>("SELECT * FROM Competitions").ConfigureAwait(false);

                return competitions.ToList();
            }
        }

        public async Task<Competition> SelectById(int id)
        {
            using (var connection = CreateConnection())
            {
                var competitions = await connection.QueryAsync<Competition, Snail, Competition>(@"
                    SELECT c.*, s.*
                    FROM Competitions c
                    LEFT JOIN Snails s ON s.Id = c.WinnerId
                    WHERE c.Id = @Id",
                    (c, s) => { c.Winner = s; return c; },
                    new { Id = id }).ConfigureAwait(false);
                var competition = competitions.SingleOrDefault();
                competition.Competitors = await SelectCompetitors(id).ConfigureAwait(false);

                return competition;
            }
        }

        public async Task<IEnumerable<Snail>> SelectCompetitors(int id)
        {
            using (var connection = CreateConnection())
            {
                var snails = await connection.QueryAsync<Snail>(@"SELECT s.*
                    FROM SnailsCompetitions sc
                    INNER JOIN Snails s ON s.Id = sc.SnailId
                    WHERE sc.CompetitionId = @Id", new { Id = id }).ConfigureAwait(false);

                return snails.ToList();
            }
        }

        public async Task Insert(Competition entity)
        {
            using (var connection = CreateConnection())
            {
                await connection.ExecuteAsync(@"INSERT INTO 
                    Competitions (Name)
                    VALUES (@Name)", entity).ConfigureAwait(false);
            }
        }

        public Task Update(Competition entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
