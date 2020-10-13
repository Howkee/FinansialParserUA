using System.Net.Http;
using System.Threading.Tasks;

namespace MoneyParserUA.Core
{
    class HTMLLoader
    {
        readonly HttpClient client;
        readonly string url;

        public HTMLLoader(IParserSettings settings)
        {
            url = $"{settings.Url}/{settings.Postfix}/";
            client = new HttpClient();
        }

        public async Task<string> GetSourse()
        {
            string sourse = null;
            var response = await client.GetAsync(url);

            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                sourse = await response.Content.ReadAsStringAsync();
            }
            return sourse;
        }
    }
}
