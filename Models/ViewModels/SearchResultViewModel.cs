using CMDb_MGM.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb_MGM.Models.ViewModels
{
    public class SearchResultViewModel
    {
        public List<MovieDTO> MovieResults { get; set; }

        public SearchResultViewModel(List<MovieDTO> result)
        {
            MovieResults = result;
        }
    }
}
