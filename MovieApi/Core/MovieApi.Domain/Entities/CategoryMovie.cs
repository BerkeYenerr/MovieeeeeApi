using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieApi.Domain.Entities
{
    public class CategoryMovie
    {
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
        public int MovieId { get; set; }
        [JsonIgnore]
        public Movie Movie { get; set; }

    }
}
