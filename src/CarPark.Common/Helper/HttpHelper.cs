using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CarPark.Common.Helper
{
    public class HttpHelper<T> where T : class
    {
        private readonly HttpClient _client;

        public HttpHelper()
        {
            _client = new HttpClient();
        }

        public async Task<T> SendGetRequestAsync(string requestUri)
        {
            try
            {
                // HTTP GET
                var response = await _client.GetAsync(requestUri);
                if (!response.IsSuccessStatusCode)
                    throw new Exception(response.ReasonPhrase);

                var responseStream = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseStream);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
