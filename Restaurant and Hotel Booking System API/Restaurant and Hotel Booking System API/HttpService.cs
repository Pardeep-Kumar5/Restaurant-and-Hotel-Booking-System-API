#nullable disable
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace SubmittalTransmittal.ApplicationCore
{
    public class HttpService(HttpClient client)
    {
        public async Task<T> Get<T>(string url, string accessToken = null) where T : class
        {
            AddAuthorization(accessToken);

            var response = await client.GetAsync(url);

            await EnsureSuccessStatusCode(response);

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        public async Task<T> Put<T>(string url, HttpContent content, string accessToken = null, bool encrypt = false)
        {
            AddAuthorization(accessToken);
            var request = GetHttpRequestMessage(HttpMethod.Put, url, content);

            if (encrypt)
            {
                client.DefaultRequestHeaders.Add("x-amz-server-side-encryption", "AES256");
            }

            var response = await client.SendAsync(request);
            await EnsureSuccessStatusCode(response);

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        public async Task<T> Post<T>(string url, HttpContent content, string accessToken = null)
        {
            AddAuthorization(accessToken);
            var request = GetHttpRequestMessage(HttpMethod.Post, url, content);
            var response = await client.SendAsync(request);
            await EnsureSuccessStatusCode(response);

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        public async Task<T> Delete<T>(string url, string accessToken = null)
        {
            AddAuthorization(accessToken);
            var request = GetHttpRequestMessage(HttpMethod.Delete, url, null);
            var response = await client.SendAsync(request);
            await EnsureSuccessStatusCode(response);

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        public async Task DownloadFile(string fileName, string filePath, string accessToken)
        {
            var uri = new Uri(fileName, UriKind.Absolute);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", accessToken);

            var response = await client.GetAsync(uri);

            using var fs = new FileStream(filePath, FileMode.CreateNew);
            await response.Content.CopyToAsync(fs);
        }

        private static HttpRequestMessage GetHttpRequestMessage(HttpMethod httpMethod, string url, HttpContent content)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new Exception("Url cannot be null or empty");
            }

            var request = new HttpRequestMessage(httpMethod, url);

            request.Headers.Add("Accept", "application/json");

            if (content is not null)
            {
                request.Content = content;
            }

            return request;
        }

        private static async Task EnsureSuccessStatusCode(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("User is not authorized. Refresh token");
                }

                var message = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException(message, null, response.StatusCode);
            }
        }

        private void AddAuthorization(string accessToken = null)
        {
            if (accessToken is not null)
            {
                if (client.DefaultRequestHeaders.Contains("Authorization"))
                {
                    client.DefaultRequestHeaders.Remove("Authorization");
                }
                client.DefaultRequestHeaders.Add("Authorization", $"bearer {accessToken}");
            }
        }
    }
}
