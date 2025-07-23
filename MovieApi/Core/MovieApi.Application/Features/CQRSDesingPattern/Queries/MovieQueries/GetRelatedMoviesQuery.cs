using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Queries.MovieQueries
{
    public class GetRelatedMoviesQuery
    {
        public int MovieId { get; set; }
        public GetRelatedMoviesQuery(int movieId) {
            MovieId = movieId;
        }
    }
}
