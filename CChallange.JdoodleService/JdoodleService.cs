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
        private readonly string language = "java";
        private readonly string versionIndex = "3";
        private readonly string uri = "https://api.jdoodle.com/v1/execute";

        public JdoodleService()
        {
            client = new HttpClient();
            ConfigureClient();
        }

        public async Task<string> CompileCodeAsync(string code, string input)
        {
            var response = await client.PostAsync(uri, GenerateContent(code, input)).ConfigureAwait(false);
            var output = await DeserializeResponseAsync(response).ConfigureAwait(false);

            return output;
        }

        private async Task<string> DeserializeResponseAsync(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var stringContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var content = JsonConvert.DeserializeObject<JDoodleOutputModel>(stringContent);
            return content.output;
        }

        private StringContent GenerateContent(string code, string input)
        {
            var inputModel = new JDoodleInputModel
            {
                clientId = clientId,
                clientSecret = clientSecret,
                language = language,
                versionIndex = versionIndex,
                script = code,
                stdin = input
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
