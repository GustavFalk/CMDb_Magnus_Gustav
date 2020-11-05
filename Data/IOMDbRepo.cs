using CMDb_MGM.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb_MGM.Data
{
   public interface IOMDbRepo
    {
        public Task<MovieDTO> GetMovieByID(string ID);

        public Task<List<MovieDTO>> GetMovieListOMDB (List<MovieDTO> listOfID);

        public Task<List<MovieDTO>> GetSearchResultsOMDB(string search);
    }
}
