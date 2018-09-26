using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApiLivrariaVirtual.Models;

namespace WebApiLivrariaVirtual.Helpers
{
    public class Util 
    {
        public async Task<Livro> A(int livroId) 
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response =  client.GetAsync("livraria-virtual/livros/"+ livroId).Result;

                if(response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Livro>(result);
                }

                return null;
            }
        } 
    }
}