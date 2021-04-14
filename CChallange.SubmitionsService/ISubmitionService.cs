using System.Threading.Tasks;

namespace CChallange.Services
{
    public interface ISubmitionService
    {
        Task<bool> SubmitAsync(string taskId, string submitionerName, string code);
    }
}
