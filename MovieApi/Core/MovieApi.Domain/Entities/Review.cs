using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieApi.Domain.Entities
{
    public class Review
    {

        public int ReviewID { get; set; }

        public string ReviewComment { get; set; }

        public int UserRating { get; set; }

        public DateTime ReviewDate { get; set; }

        public bool Status { get; set; }
        public int MovieId { get; set; }

        [JsonIgnore]
        public Movie Movie { get; set; } = null!;
    }
}
