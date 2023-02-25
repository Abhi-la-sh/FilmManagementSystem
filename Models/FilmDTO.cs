using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sprint2_MVC.Models
{
    public class FilmDTO
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public string FilmDescription { get; set; }
        public int FilmLength { get; set; }
        public DateTime ReleaseYear { get; set; }
        public int LanguageId { get; set; }
        public int Rating { get; set; }
        public int CategoryId { get; set; }
        public int ActorId { get; set; }
        public int ReplacementCost { get; set; }
        public string SpecialFeatures { get; set; }
    }
}