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
    public class CMDbMockRepo : ICMDbRepo
    {
        string baseUrl;

        public CMDbMockRepo(IWebHostEnvironment webHostEnvironment)
        {
            baseUrl = $"{webHostEnvironment.ContentRootPath}\\Test\\Mockdata\\";

        }

        //Genererar en film att skicka till vy
        public async Task<MovieDTO> GetMovieCMDb(string path)
        {
            string testFile = "movieJson.json";
            var result = GetTestMovies<MovieDTO>(testFile);
            await Task.Delay(0);
            return result;
        }

        //Generar filmlista att skicka till vyn
        public async Task<List<MovieDTO>> GetTopmoviesMovieCMDb(string path)
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
    }
}
