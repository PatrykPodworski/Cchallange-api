using System.Threading.Tasks;

namespace CChallange.JdoodleService
{
    public interface IJdoodleService
    {
        Task<string> CompileCodeAsync(string code, string input);
    }
}
