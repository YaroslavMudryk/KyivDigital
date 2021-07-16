using KyivDigital.Business.Exceptions;
using KyivDigital.Business.Helpers;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace KyivDigital.Business.Services.Interfaces
{
    public class KyivDigitalRequest
    {
        private readonly string _token;
        private readonly HttpClient _httpClient;

        public KyivDigitalRequest(HttpClient httpClient)
        {
            _httpClient = _httpClient ?? httpClient;
        }


        public async Task<HttpResponseMessage> PostAsync(string url, object data)
        {
            return await PostAuthorizeAsync(url, data, _token);
        }

        public async Task<HttpResponseMessage> PostAuthorizeAsync(string url, object data, string accessToken)
        {
            if (!string.IsNullOrWhiteSpace(accessToken))
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            var httpContent = HttpConvertor.GetHttpContent(data);
            return await _httpClient.PostAsync(url, httpContent);
        }



        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await GetAuthorizeAsync(url, _token);
        }

        public async Task<HttpResponseMessage> GetAuthorizeAsync(string url, string accessToken)
        {
            if (!string.IsNullOrWhiteSpace(accessToken))
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            return await _httpClient.GetAsync(url);
        }



        public async Task<HttpResponseMessage> PutAsync(string url, object data)
        {
            return await PutAuthorizeAsync(url, data, _token);
        }

        public async Task<HttpResponseMessage> PutAuthorizeAsync(string url, object data, string accessToken)
        {
            if (!string.IsNullOrWhiteSpace(accessToken))
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            var httpContent = HttpConvertor.GetHttpContent(data);
            return await _httpClient.PutAsync(url, httpContent);
        }



        public async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            return await DeleteAuthorizeAsync(url, _token);
        }

        public async Task<HttpResponseMessage> DeleteAuthorizeAsync(string url, string accessToken)
        {
            if (!string.IsNullOrWhiteSpace(accessToken))
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            return await _httpClient.DeleteAsync(url);
        }




        public void CheckAuthResponse(HttpResponseMessage httpResponse)
        {
            if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException("User is unauthorized");
        }
    }
}