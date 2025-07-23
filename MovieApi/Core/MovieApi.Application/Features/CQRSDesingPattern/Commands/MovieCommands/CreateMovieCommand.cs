using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Commands.MovieCommands
{
    public class CreateMovieCommand
    {

        public string Title { get; set; }

        public string CoverImageUrl { get; set; }

        public decimal Rating { get; set; }

        public string Description { get; set; }
        public int Duration { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int CreateDate { get; set; }

        public int CreatedYear { get; set; }

        public bool Status { get; set; }



    }
}
