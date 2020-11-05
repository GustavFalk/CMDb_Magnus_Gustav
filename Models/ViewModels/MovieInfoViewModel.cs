using CMDb_MGM.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb_MGM.Models.ViewModels
{
    public class MovieInfoViewModel
    {

        public MovieDTO Movie { get; set; }
        public List<string> Actors { get; set; }
        public MovieInfoViewModel(MovieDTO cmdbMovie, MovieDTO omdbMovie)
        {
            if (cmdbMovie != null)
            { 
            omdbMovie.numberOfLikes = cmdbMovie.numberOfLikes;
            omdbMovie.numberOfDislikes = cmdbMovie.numberOfDislikes;
            }
            else
            {
                omdbMovie.numberOfLikes = 0;
                omdbMovie.numberOfDislikes = 0;
            }
            Actors = omdbMovie.Actors.Split(',').ToList();
            Movie = omdbMovie;
        }
    }
}
