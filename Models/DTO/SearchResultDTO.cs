using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb_MGM.Models.DTO
{
    //Denna klass är enbart till för att fånga upp söklistan från OMDB
    public class SearchResultDTO
    {

        public List<MovieDTO> Search { get; set; }
    }
}
