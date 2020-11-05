using CMDb_MGM.Data;
using CMDb_MGM.Models.DTO;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb_MGM.Test
{
    
    public class OMDbMockRepo : IOMDbRepo
    {
        string baseUrl;
     
        public OMDbMockRepo(IWebHostEnvironment webHostEnvironment)
        {
            baseUrl = $"{webHostEnvironment.ContentRootPath}\\Test\\Mockdata\\";
            
        }

        
        public async Task<MovieDTO> GetMovieByID(string ID)
        {
            string testFile = "movieJson.json";
            var result = GetTestMovies<MovieDTO>(testFile);
            await Task.Delay(0);
            return result;
        }

        public async Task<List<MovieDTO>>GetMovieTopListOMDB()
        {
            string testFile = "movielistJson.json";
            var result = GetTestMovies<List<MovieDTO>>(testFile);
            await Task.Delay(0);
            return result;
        }        

        private T GetTestMovies<T>(string testFile)
        {
            string searchpath = $"{baseUrl}{testFile}";
            string data = File.ReadAllText(searchpath);
            var fakemovielist = JsonConvert.DeserializeObject<T>(data);
            return fakemovielist;
        }

        public async Task<List<MovieDTO>> GetMovieListOMDB(List<MovieDTO> listOfID)
        {
            string testFile = "movielistJson.json";
            var result = GetTestMovies<List<MovieDTO>>(testFile);
            await Task.Delay(0);
            return result;
        }

        public async Task<List<MovieDTO>> GetSearchResultsOMDB(string search)
        {
            string testFile = "movielistJson.json";
            var result = GetTestMovies<List<MovieDTO>>(testFile);
            await Task.Delay(0);
            return result;
        }
    }
}
