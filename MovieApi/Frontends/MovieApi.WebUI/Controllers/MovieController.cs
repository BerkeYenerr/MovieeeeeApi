using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.MovieDtos;
using Newtonsoft.Json;
using System.Reflection;

namespace MovieApi.WebUI.Controllers
{
    public class MovieController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MovieController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MovieList()
        {
            ViewBag.v1 = "Film Listesi";
            ViewBag.v2 = "Ana Sayfa";
            ViewBag.v3 = "Tüm Filmler";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7132/api/Movies");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMovieDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        public async Task<IActionResult> MovieDetail(int id)
        {
            ViewBag.v1 = "Film Listesi";
            ViewBag.v2 = "Ana Sayfa";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7132/api/Movies/GetMovie?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultMovieDetailsDto>(jsonData);
                ViewBag.v3 = values.Title;

                var relatedresponse = await client.GetAsync("https://localhost:7132/api/Movies");
                if (relatedresponse.IsSuccessStatusCode)
                {
                    var relatedjson = await relatedresponse.Content.ReadAsStringAsync();
                    var relatedmovie = JsonConvert.DeserializeObject<List<ResultMovieDto>>(relatedjson);
                    values.resultMovieDtos = relatedmovie
                        .Where(x => x.MovieId != values.MovieId).ToList();
                }
                return View(values);
            }

            return View();
        }
        public async Task<IActionResult> MovieSearch(string searchText, string[] genres, string rating, int? startYear, int? endYear)
        {
            ViewBag.v1 = "Film Listesi";
            ViewBag.v2 = "Ana Sayfa";
            ViewBag.v3 = "Film Arama Sonuçları";

            var client = _httpClientFactory.CreateClient();
            string apiUrl = "https://localhost:7132/api/Movies/search?"; // API URL'si

            // Gelen parametrelere göre URL'yi oluşturuyoruz
            if (!string.IsNullOrEmpty(searchText))
                apiUrl += $"searchText={searchText}&";
            if (genres != null && genres.Any())
                apiUrl += $"genres={string.Join(",", genres)}&";
            if (!string.IsNullOrEmpty(rating))
                apiUrl += $"rating={rating}&";
            if (startYear.HasValue)
                apiUrl += $"startYear={startYear}&";
            if (endYear.HasValue)
                apiUrl += $"endYear={endYear}";

            var responseMessage = await client.GetAsync(apiUrl);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var movies = JsonConvert.DeserializeObject<List<ResultMovieDto>>(jsonData);
                return View(movies);
            }

            return View(new List<ResultMovieDto>());
        }
    }
}