using CMDb_MGM.Models.DTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CMDb_MGM.Data
{
    public class CMDbRepo : ICMDbRepo
    {
        private string baseUrl;


        public CMDbRepo(IConfiguration config)
        {
            baseUrl = config.GetValue<string>("CMDbApi:baseURL");
        }

       
        
        public async Task<List<MovieDTO>> GetTopmoviesMovieCMDb(string path)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = $"{baseUrl}{path}";
                var response = await client.GetAsync(endPoint, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<MovieDTO>>(data);
                return result;
            }
        }

        public async Task<MovieDTO> GetMovieCMDb(string path)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = $"{baseUrl}{path}";
                var response = await client.GetAsync(endPoint, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<MovieDTO>(data);
                return result;
            }
        }

    }
}
