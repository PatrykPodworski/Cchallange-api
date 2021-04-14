using System.Collections.Generic;
using System.Threading.Tasks;

namespace CChallange.Services
{
    public interface IHighscoresService
    {
        Task<IEnumerable<Highscore>> GetHighscores();
    }
}
