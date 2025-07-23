using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.MovieDtos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieApi.WebUI.Controllers
{
    /// <summary>
    /// Bu controller sadece film arama işlemini yönetir.
    /// </summary>
    public class MovieSearch : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        // Gerekli servisleri enjekte ediyoruz
        public MovieSearch(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Arama formundan gelen istek bu metoda düşer.
        /// Bu, controller'ın varsayılan (Index) metodudur.
        /// </summary>
        public async Task<IActionResult> Index(string searchText, string[] genres, string rating, int? startYear, int? endYear)
        {
            ViewData["Title"] = "Arama Sonuçları";
            ViewBag.v1 = "Film Listesi";
            ViewBag.v2 = "Ana Sayfa";
            ViewBag.v3 = "Film Arama Sonuçları";

            var client = _httpClientFactory.CreateClient();
            // API'ye gönderilecek URL'yi oluşturuyoruz
            string apiUrl = "https://localhost:7132/api/Movies/search?";

            if (!string.IsNullOrEmpty(searchText))
                apiUrl += $"searchText={System.Net.WebUtility.UrlEncode(searchText)}&";
            if (genres != null && genres.Any())
                apiUrl += string.Join("&", genres.Select(g => $"genres={System.Net.WebUtility.UrlEncode(g)}")) + "&";
            if (!string.IsNullOrEmpty(rating))
                apiUrl += $"rating={rating}&";
            if (startYear.HasValue)
                apiUrl += $"startYear={startYear}&";
            if (endYear.HasValue)
                apiUrl += $"endYear={endYear}";

            // API'ye isteği gönderiyoruz
            var responseMessage = await client.GetAsync(apiUrl);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var movies = JsonConvert.DeserializeObject<List<ResultMovieDto>>(jsonData);
                // Sonuçları View'a gönderiyoruz
                return View(movies);
            }

            // Hata durumunda veya sonuç yoksa boş bir liste gönder
            return View(new List<ResultMovieDto>());
        }
    }
}