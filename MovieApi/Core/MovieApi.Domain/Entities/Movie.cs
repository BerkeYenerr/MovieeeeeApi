using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Domain.Entities
{
    public class Movie
    {

        public int MovieId { get; set; }

        public string Title { get; set; }

        public string CoverImageUrl { get; set; }

        public decimal Rating { get; set; }

        public string Description  { get; set; }
        public int Duration { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int CreateDate { get; set; }

        public int CreatedYear { get; set; }
        public string Genre { get; set; }
        public bool Status { get; set; }

        public ICollection<Review> Reviews { get; set; } =new List<Review>();
        public ICollection<CastMovie> CastMovies { get; set; } =new List<CastMovie>();
        public ICollection<CategoryMovie> CategoryMovies { get; set; } =new List<CategoryMovie>();
        public ICollection<TagMovie> TagMovies { get;set; } =new List<TagMovie>();
    
    }
}
