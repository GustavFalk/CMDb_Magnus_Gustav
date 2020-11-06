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

        //Genererar en film utifrån en sträng bestående av IMDbID
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

        //Hämtar en filmlista från OMDb med hjälp av en annan filmlista. 
        public async Task<List<MovieDTO>> GetMovieListOMDB(List<MovieDTO> listOfID)
        {
            List<MovieDTO> movielist = new List<MovieDTO>();

            //Den loopar igenom listan som kommer in, och tar varje film i listans IMDbID och med hjälp av ovan Metod genererar vi en film av den.
            //den filmen hamnar sedermera i en ny lista. När loopen är klar så returneras den nya filmlistan.
            List<Task> tasks = new List<Task>();

            foreach (MovieDTO x in listOfID)            
            {
                var movie = GetMovieByID(x.IMDbID);
                tasks.Add(movie);
                movielist.Add(movie.Result);
            };
            await Task.WhenAll(tasks);
            return movielist;
        }

        //En metod som generar en filmlista med hjälp av ett sökord från OMDb. den plockar ut en klass av "SearchresultDTO" och tar listan
        //från den och skickar ut. Då vymodellerna enbart använder sig av filmlistor eller filmer.
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
