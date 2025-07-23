using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieApi.Domain.Entities
{
    public class CastMovie
    {
        public int MovieId {  get; set; }
        [JsonIgnore]
        public Movie Movie { get; set; }

        public int CastId { get; set; }
        [JsonIgnore]
        public Cast Cast { get; set; }
    }
}
