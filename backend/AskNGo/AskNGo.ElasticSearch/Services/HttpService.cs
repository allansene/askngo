using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace AskNGo.ElasticSearch
{
    
    public static class HttpService
    {
        public static string HttpPost(string json, string uri)
        {
            
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri(uri);
                var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "admin", "wBnewR82Ec")));

                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
                StringContent queryString = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage result = client.PostAsync(new Uri(uri), queryString).Result;//client.PostAsJsonAsync(new Uri(uri), Newtonsoft.Json.JsonConvert.DeserializeObject(json)).Result;
                if (result.IsSuccessStatusCode)
                    return result.Content.ReadAsStringAsync().Result;
                else
                    return "";
            }
        }

        public static string HttpDelete(string uri, string delete)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "admin", "wBnewR82Ec")));

                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                HttpResponseMessage result = client.DeleteAsync(delete).Result;
                if (result.IsSuccessStatusCode)
                    return result.Content.ReadAsStringAsync().Result;
                else
                    return "";
            }
        }
        public static string HttpPost<T>(T objeto, string uri)
        {
            
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri(uri);
                var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "admin", "wBnewR82Ec")));

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                HttpResponseMessage result = client.PostAsJsonAsync(new Uri(uri), objeto).Result;
                if (result.IsSuccessStatusCode)
                    return result.Content.ReadAsStringAsync().Result;
                else
                    return "";
            }
        }

        public static string HttpPut<T>(T objeto, string uri)
        {

            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri(uri);
                var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "admin", "wBnewR82Ec")));

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                HttpResponseMessage result = client.PutAsJsonAsync(new Uri(uri), objeto).Result;
                if (result.IsSuccessStatusCode)
                    return result.Content.ReadAsStringAsync().Result;
                else
                    return "";
            }
        }

        public static string HttpGet(string uri)
        {
            using (var client = new HttpClient())
            {
                var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "admin", "wBnewR82Ec")));

                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
                //client.DefaultRequestHeaders.Add("hash", DadosLogin.HashAutenticacao);

                HttpResponseMessage response = client.GetAsync(new Uri(uri)).Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsStringAsync().Result;
                else
                    return "";
            }
        }
    }
}
