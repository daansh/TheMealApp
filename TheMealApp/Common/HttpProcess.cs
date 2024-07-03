using System.Net;
using Newtonsoft.Json;

namespace TheMealApp.Common
{
    static class HttpProcess
	{
        private static Dictionary<TimoutConnector, HttpClient> Clients;
        public static string RequestBaseURL = "https://www.themealdb.com/api/json/v1/1/";

        static HttpProcess()
		{
            Clients = new Dictionary<TimoutConnector, HttpClient>();
            var tcList = Enum.GetValues(typeof(TimoutConnector)).Cast<TimoutConnector>().ToList();
            foreach (var tc in tcList)
            {
                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback += (sender, cert, chaun, ssPolicyError) =>
                {
                    return true;
                };
                var httpClient = new HttpClient(httpClientHandler);
                httpClient.Timeout = new TimeSpan(0, 0, (int)tc);
                Clients.Add(tc, httpClient);
            }
        }

        #region GetRequest

        public static async Task<HttpProcessResponse<T>> GetRequest<T>(TimoutConnector timeoutConnector, string api) where T : new()
        {
            var client = Clients[timeoutConnector];
            var returnValue = new HttpProcessResponse<T>(HttpStatusCode.RequestTimeout, new T());
            try
            {
                client.DefaultRequestHeaders.Clear();
                var url = $"{RequestBaseURL}{api}";

                var response = await client.GetAsync(url).ConfigureAwait(false);

                returnValue.HttpStatus = response.StatusCode;
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    returnValue = new HttpProcessResponse<T>(HttpStatusCode.Unauthorized, new T());

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var data = new T();
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        data = JsonConvert.DeserializeObject<T>(result);
                    }
                    returnValue.Data = data;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.StackTrace); }
            return await Task.FromResult(returnValue);
        }
        #endregion
    }
}

