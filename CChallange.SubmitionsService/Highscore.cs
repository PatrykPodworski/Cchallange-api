using System.Collections.Generic;

namespace CChallange.Services
{
    public class Highscore
    {
        public string UserName { get; set; }
        public int NumberOfSuccesfulSolutions { get; set; }
        public IEnumerable<string> SolvedTasks { get; set; }
    }

}
