using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb_MGM.Models.DTO
{
    public class MovieDTO
    {
       public string Title { get; set; }              
       public string Rated { get; set; }
       public string Runtime { get; set; }
       public string Released { get; set; }
       public string Genre { get; set; }
       public string Poster { get; set; }
       public string IMDbID { get; set; }
       public int numberOfLikes { get; set; }
       public int numberOfDislikes { get; set; }
       public int toplistplacement { get; set; }
       public string Plot { get; set; }
       public string Actors  { get; set; }
       public string Metascore { get; set; }
       public string imdbRating { get; set; }
       public string Director { get; set; }
       

    }
}
