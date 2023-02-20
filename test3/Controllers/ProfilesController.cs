using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace test3.Controllers
{
    public class Profile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public SocialInsiderDate Date { get; set; }

        public string ProfileType { get; set; }
    }

    public class SocialInsiderProfile2
    {
        public int id { get; set; }

        public string name { get; set; }

        public SocialInsiderDate date { get; set; }

        public string profiletype { get; set; }

        //public List <> 
    }

    public class SocialInsiderDate
    {
        public string start { get; set; }

        public string end { get; set; }

        public string timezone { get; set; }
    }

    public class SocialInsiderAPIResponse2<T>
    {
        public int id { get; set; } = 0;

        public T result { get; set; }
    }

    public class SocialInsiderAPIBody2
    {
        public int id { get; set; } = 1;

        public string method { get; set; }

        [JsonPropertyName("params")]
        public Dictionary<string, object> parameters { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private const string apiUrl = "https://app.socialinsider.io/api";

        private const string apiKey = "API_KEY_TEST";

        [HttpGet]
        public async Task<ActionResult<List<Profile>>> GetProfiles()
        {
            Console.Write("apel_profiles");

            var body = new SocialInsiderAPIBody2();
            body.method = "socialinsider_api.get_profile_data";
            body.parameters = new Dictionary<string, object>
                                {
                                    { "id", "44596321012" },
                                    { "profile_type", "facebook_page" },
                                    { "date", new
                                                {
                                                    start = 1608209422374,
                                                    end = 1639745412436,
                                                    timezone = "Europe/London"
                                                 }
                                    }
                                };
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);
            var response = await httpClient.PostAsJsonAsync(apiUrl, body);
            Console.Write("apel_profiles");
            Console.Write(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                //var brand_data = await response.Content.ReadFromJsonAsync<SocialInsiderAPIResponse<List<SocialInsiderBrand>>>();
                //var res = brand_data.result.Select(brand => new Brand { Name = brand.Name }).ToList();
                //var res2 = brand_data.result.Select(brand => new Brand { Profiles = brand.Profiles });
                return NotFound();
            }
            else
                return NotFound();

        }
        public ProfilesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

    }
}
