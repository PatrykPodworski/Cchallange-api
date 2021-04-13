using System.Threading.Tasks;

namespace CChallange.SubmitionsService
{
    public interface ISubmitionService
    {
        Task<bool> SubmitAsync(string taskId, string submitionerName, string code);
    }
}
