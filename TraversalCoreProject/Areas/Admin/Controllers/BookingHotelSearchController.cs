using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProje.Areas.Admin.Models;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class BookingHotelSearchController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id=20079942&search_type=CITY&arrival_date=2025-08-01&departure_date=2025-08-08&adults=2&children_age=0%2C17&room_qty=1&page_number=1&units=metric&temperature_unit=c&languagecode=en-us&currency_code=AED&location=US"),
                Headers =
    {
        {  "x-rapidapi-key", "2ae46c2f88msh3f43b0dfbcc71f8p1e7acfjsncd4ff215d031" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com"  },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<BookingHotelSearchViewModel.Rootobject>(body);

                var hotels = result.data.hotels.Select(h => new BookingHotelSearchViewModel2
                {
                    HotelName = h.property.name,
                    ReviewScore = h.property.reviewScore,
                    ReviewScoreWord = h.property.reviewScoreWord
                }).ToList();

                return View(hotels);
            }
        }

        [HttpGet]
        public IActionResult GetCityDestID()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetCityDestID(string p)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name={p}"),
                Headers =
    {
        { "X-RapidAPI-Key", "cb5ee15da1mshb46d59d679af3abp1fe84cjsn167590fdc0cc" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                return View();
            }
        }
    }
}