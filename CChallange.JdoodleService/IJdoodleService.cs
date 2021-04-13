using System.Threading.Tasks;

namespace CChallange.JdoodleService
{
    public interface IJdoodleService
    {
        Task CompileCodeAsync(string code);
    }
}
