using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Queries.MovieQeries
{
    public class SearchMoviesQuery
    {
        public string? SearchText { get; set; }
        public string[]? Genres { get; set; }
        public string? Rating { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
    }
}

