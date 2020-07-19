using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assday5.Models
{
    public class Reviews
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; internal set; }
    }
}
