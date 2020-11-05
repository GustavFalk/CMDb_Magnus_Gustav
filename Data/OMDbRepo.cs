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
    public class OMDbRepo: IOMDbRepo
    {
        private string baseUrl;


        public OMDbRepo(IConfiguration config)
        {
            baseUrl = config.GetValue<string>("OMDbApi:baseURL");
        }

        public async Task<MovieDTO> GetMovieByID(string ID)
        {
            using(HttpClient client = new HttpClient())
            {
                string endPoint = $"{baseUrl}&i={ID}&plot=full";
                var response = await client.GetAsync(endPoint, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<MovieDTO>(data);
                return result;
            }

        }

        public async Task<List<MovieDTO>> GetMovieListOMDB(List<MovieDTO> listOfID)
        {
            List<MovieDTO> movielist = new List<MovieDTO>();
           
            foreach(MovieDTO x in listOfID)
            {
                MovieDTO movie = await GetMovieByID(x.IMDbID);
                movielist.Add(movie);
            };

            return movielist;
        }

        public async Task<List<MovieDTO>> GetSearchResultsOMDB(string search)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = $"{baseUrl}&s={search}";
                var response = await client.GetAsync(endPoint, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<SearchResultDTO>(data);
                return result.Search;
            }
        }
    }
}
