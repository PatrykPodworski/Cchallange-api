using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CChallange.JdoodleService
{
    public class JdoodleService : IJdoodleService
    {
        private readonly HttpClient client;

        private readonly string clientId = "2b7a8906b7dce18fa002bf40ca1d2968";
        private readonly string clientSecret = "84f26b4c1dc1eb612d184505c183b49b77deda68cb16cecd3f036b4a4b21e0ce";
        private readonly string language = "csharp";
        private readonly string versionIndex = "3";
        private readonly string uri = "https://api.jdoodle.com/v1/execute";

        public JdoodleService()
        {
            client = new HttpClient();
            ConfigureClient();
        }

        public async Task CompileCodeAsync(string code)
        {
            var response = await client.PostAsync(uri, GenerateContent(code));
        }

        private StringContent GenerateContent(string code)
        {
            var inputModel = new JDoodleInputModel
            {
                clientId = clientId,
                clientSecret = clientSecret,
                language = language,
                versionIndex = versionIndex,
                script = code
            };

            var json = JsonConvert.SerializeObject(inputModel);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private void ConfigureClient()
        {
            client.DefaultRequestHeaders.Clear();
        }
    }
}
