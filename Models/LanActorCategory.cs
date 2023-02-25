using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sprint2_WebApi.Models
{
    public class LanActorCategory
    {
        public List<LanguageDTO> Languages { set; get; }
        public List<ActorDTO> Actors { set; get; }
        public List<CategoryDTO> Categories { set; get; }

    }
}