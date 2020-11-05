using CMDb_MGM.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb_MGM.Data
{
    public interface ICMDbRepo
    {
        public Task<List<MovieDTO>> GetTopmoviesMovieCMDb(string path);

        public Task<MovieDTO> GetMovieCMDb(string path);
    }
}
