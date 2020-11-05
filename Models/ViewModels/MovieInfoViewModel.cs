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
             //kollar så att filmen finns. Finns den inte så finns den sannorlikt inte i CMDb databasen.
            if (cmdbMovie != null)
            { 
            omdbMovie.numberOfLikes = cmdbMovie.numberOfLikes;
            omdbMovie.numberOfDislikes = cmdbMovie.numberOfDislikes;
            }
            
            //om inte så får likes och dislikes 0. 
            else
            {
                omdbMovie.numberOfLikes = 0;
                omdbMovie.numberOfDislikes = 0;
            }

            //Splittar upp strängen med skådespelare för att kunna visa upp dom en och en i ett bildspel.
            Actors = omdbMovie.Actors.Split(',').ToList();
            Movie = omdbMovie;
        }
    }
}
