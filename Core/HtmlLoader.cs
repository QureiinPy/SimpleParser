using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParserWPF.Core
{
    internal class HtmlLoader
    {
        readonly HttpClient client;
        readonly string url;

        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
            url = $"{settings.BaseUrl}/{settings.Preffix}";
        }

        public async Task<string> GetSourceByPageId(int id)
        {
            //var currentUrl = url.Replace("{CurrentId}", id.ToString());
            var currentUrl = $"{url}{id}";
            var response = await client.GetAsync(currentUrl);
            string source = string.Empty;

            if(response?.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}
