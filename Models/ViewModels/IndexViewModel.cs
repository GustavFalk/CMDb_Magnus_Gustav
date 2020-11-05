using CMDb_MGM.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb_MGM.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<MovieDTO> MovieTopList { get; set; }

        public IndexViewModel(List<MovieDTO> OMDbToplist, List<MovieDTO> CMDbToplist )
        {
            int i = 0, toplistplacement = 1;
            

            foreach(MovieDTO movie in OMDbToplist)
            {
                movie.numberOfLikes = CMDbToplist[i].numberOfLikes;
                movie.numberOfDislikes = CMDbToplist[i].numberOfDislikes;
                movie.toplistplacement = toplistplacement;
                i++;
                toplistplacement++;
            }

            MovieTopList = OMDbToplist;
        }

    }
}
