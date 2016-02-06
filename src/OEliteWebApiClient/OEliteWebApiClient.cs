using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.WebEncoders;

namespace OElite.Web.Utils
{
    public class OEliteWebApiClient
    {
        private string _baseUrl = null;
        public OEliteWebApiClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }
        public OEliteWebApiClient(Uri baseUri)
        {
            _baseUrl = baseUri.ToString();
        }
        public string BaseUrl
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }

        #region Get
        public async Task<T> GetAsync<T>(string relativePath, string mediaType = "application/json")
        {
            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

                var response = await client.GetAsync(relativePath);
                response.EnsureSuccessStatusCode();
                T result = await response.Content.ReadAsAsync<T>();
                return result;
            }
        }

        public async Task<T> GetJsonAsync<T>(string relativePath, params KeyValuePair<string, string>[] queryValues)
        {
            relativePath = BuildQuery(relativePath, queryValues);
            return await GetAsync<T>(relativePath);
        }
        #endregion

        #region Post
        public async Task<T> PostAsync<P, T>(string relativePath, P submittingData, string mediaType = "application/json")
        {
            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

                HttpResponseMessage response = null;
                if (submittingData.GetType() == typeof(FormUrlEncodedContent))
                {
                    response = await client.PostAsync(relativePath, ((FormUrlEncodedContent)Convert.ChangeType(submittingData, typeof(FormUrlEncodedContent))));
                }
                else if ((mediaType?.ToLower()).Contains("xml"))
                {
                    response = await client.PostAsXmlAsync<P>(relativePath, submittingData);
                }
                else
                {
                    response = await client.PostAsJsonAsync<P>(relativePath, submittingData);
                }

                response.EnsureSuccessStatusCode();
                T result = await response.Content.ReadAsAsync<T>();
                return result;
            }

        }
        public async Task<T> PostJsonAsync<T>(string relativePath, params KeyValuePair<string, string>[] queryValues)
        {
            FormUrlEncodedContent content = new FormUrlEncodedContent(queryValues);
            return await PostAsync<FormUrlEncodedContent, T>(relativePath, content);
        }
        #endregion

        #region Put
        public async Task<T> PutAsync<P, T>(string relativePath, P submittingData, string mediaType = "application/json")
        {
            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

                HttpResponseMessage response = null;
                if (submittingData.GetType() == typeof(FormUrlEncodedContent))
                {
                    response = await client.PutAsync(relativePath, ((FormUrlEncodedContent)Convert.ChangeType(submittingData, typeof(FormUrlEncodedContent))));
                }
                else if ((mediaType?.ToLower()).Contains("xml"))
                {
                    response = await client.PutAsXmlAsync<P>(relativePath, submittingData);
                }
                else
                {
                    response = await client.PutAsJsonAsync<P>(relativePath, submittingData);
                }

                response.EnsureSuccessStatusCode();
                T result = await response.Content.ReadAsAsync<T>();
                return result;
            }

        }
        public async Task<T> PutJsonAsync<T>(string relativePath, params KeyValuePair<string, string>[] queryValues)
        {
            FormUrlEncodedContent content = new FormUrlEncodedContent(queryValues);
            return await PutAsync<FormUrlEncodedContent, T>(relativePath, content);
        }
        #endregion

        #region Delete
        public async Task<T> DeleteAsync<T>(string relativePath, string mediaType = "application/json")
        {
            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

                var response = await client.DeleteAsync(relativePath);
                response.EnsureSuccessStatusCode();
                T result = await response.Content.ReadAsAsync<T>();
                return result;
            }
        }

        public async Task<T> DeleteJsonAsync<T>(string relativePath, params KeyValuePair<string, string>[] queryValues)
        {
            relativePath = BuildQuery(relativePath, queryValues);

            return await DeleteAsync<T>(relativePath);
        }

        public static string BuildQuery(string relativePath, KeyValuePair<string, string>[] queryValues)
        {
            var valueBuilder = string.Empty;
            if (queryValues != null)
            {
                foreach (var pair in queryValues)
                {
                    valueBuilder += string.Format("{0}={1}&", pair.Key, UrlEncoder.Default.UrlEncode(pair.Value));
                }
            }
            if ((relativePath?.Contains("?")).GetValueOrDefault())
            {
                relativePath = string.Format("{0}&{1}", relativePath?.TrimEnd('&'), valueBuilder);
            }
            else
                relativePath = string.Format("{0}?{1}", relativePath?.TrimEnd('&'), valueBuilder);
            return relativePath;
        }
        #endregion
    }
}
