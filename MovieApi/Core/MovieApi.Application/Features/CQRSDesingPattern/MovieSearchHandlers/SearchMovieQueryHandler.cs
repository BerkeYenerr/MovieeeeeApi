using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesingPattern.Queries.MovieQeries;
using MovieApi.Application.Features.CQRSDesingPattern.Results.MovieResults;
using MovieApi.Persistence.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Handlers.MovieHandlers
{
    /// <summary>
    /// Arama sorgusunu işleyip veritabanından ilgili filmleri getiren Handler sınıfı.
    /// </summary>
    public class SearchMovieQueryHandler
    {
        private readonly MovieContext _context;

        public SearchMovieQueryHandler(MovieContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Arama kriterlerini alıp filtreleme işlemini gerçekleştirir.
        /// </summary>
        /// <param name="query">Kullanıcının girdiği arama kriterlerini içeren nesne.</param>
        /// <returns>Filtrelenmiş film listesi.</returns>
        public async Task<List<GetMovieQueryResult>> Handle(SearchMoviesQuery query)
        {
            // Sorgulanabilir bir temel sorgu oluşturuyoruz.
            var values = _context.Movies.AsQueryable();

            // 1. Film Adına Göre Filtreleme (Büyük/küçük harf duyarsız)
            if (!string.IsNullOrEmpty(query.SearchText))
            {
                values = values.Where(m => m.Title.ToLower().Contains(query.SearchText.ToLower()));
            }

            // 2. Türe Göre Filtreleme
            if (query.Genres != null && query.Genres.Any())
            {
                values = values.Where(m => query.Genres.Contains(m.Genre));
            }

            // 3. Reytinge Göre Filtreleme
            if (!string.IsNullOrEmpty(query.Rating) && query.Rating != "range")
            {
                if (query.Rating.Contains("-")) // "5-8" gibi aralıklar için
                {
                    var parts = query.Rating.Split('-');
                    if (decimal.TryParse(parts[0], out var minRating) && decimal.TryParse(parts[1], out var maxRating))
                    {
                        values = values.Where(m => m.Rating >= minRating && m.Rating <= maxRating);
                    }
                }
                else // "8" gibi tek değerler için (8 ve üzeri)
                {
                    if (decimal.TryParse(query.Rating, out var minRating))
                    {
                        values = values.Where(m => m.Rating >= minRating);
                    }
                }
            }

            // 4. Başlangıç Yılına Göre Filtreleme
            if (query.StartYear.HasValue)
            {
                values = values.Where(m => m.CreatedYear >= query.StartYear.Value);
            }

            // 5. Bitiş Yılına Göre Filtreleme
            if (query.EndYear.HasValue)
            {
                values = values.Where(m => m.CreatedYear <= query.EndYear.Value);
            }

            // Sonuçları istenen formata dönüştürüp listeliyoruz.
            return await values.Select(x => new GetMovieQueryResult
            {
                MovieId = x.MovieId,
                Title = x.Title,
                Description = x.Description,
                Rating = x.Rating,
                CoverImageUrl = x.CoverImageUrl,
                ReleaseDate = x.ReleaseDate,
                Duration = x.Duration,
                CreatedYear = x.CreatedYear,
                Status = (x.Status)
            }).ToListAsync();
        }
    }
}