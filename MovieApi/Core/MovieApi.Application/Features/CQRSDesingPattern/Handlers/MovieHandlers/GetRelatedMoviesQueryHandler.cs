using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesingPattern.Results.MovieResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Handlers.MovieHandlers
{
    public class GetRelatedMoviesQueryHandler
    {
        private readonly MovieContext _context;

        public GetRelatedMoviesQueryHandler(MovieContext context)
        {
            _context = context;
        }
       
    }
}
