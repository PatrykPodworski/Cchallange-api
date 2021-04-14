using CChallange.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CChallange.Services
{
    public class HighscoresService : IHighscoresService
    {
        private readonly CChallangeDbContext dbContext;

        public HighscoresService(CChallangeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<Highscore>> GetHighscores()
        {
            return await dbContext.Users
                .Select(x => new Highscore
                {
                    UserName = x.Name,
                    NumberOfSuccesfulSolutions = x.Submitions.Count(),
                    SolvedTasks = x.Submitions.Select(x => x.Task.Name)
                })
                .OrderByDescending(x => x.NumberOfSuccesfulSolutions)
                .Take(3)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
