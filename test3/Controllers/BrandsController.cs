using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Globalization;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace test3.Controllers
{
    public class Brand
    {
        public string Name { get; set; }

       // public List<SocialInsiderProfile> Profiles { get; set; }

        public int Counter { get; set; }
    }

    public class SocialInsiderAPIBody
    {
        public string jsonrpc { get; set; } = "2.0";

        public int id { get; set; } = 0;

        public string method { get; set; }

        [JsonPropertyName("params")]
        public Dictionary<string, object> parameters { get; set; }
    }

    public class SocialInsiderAPIResponse<T>
    {
        public string jsonrpc { get; set; }

        public int id { get; set; } = 0;

        public T result { get; set; }
    }

    public class SocialInsiderBrand
    {
        [JsonPropertyName("brandname")]
        //[JsonPropertyName("name")]
        public string Name { get; set; }

        public List<SocialInsiderProfile> Profiles { get; set; }
    }

    public class SocialInsiderProfile
    {
        public string id { get; set; }

        public string name { get; set; }

        public string profile_type { get; set; }

        public DateTime profile_added { get; set; }
    }




    /*public class Profile
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
    }*/


    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private const string apiUrl = "https://app.socialinsider.io/api";

        private const string apiKey = "API_KEY_TEST";


        [HttpGet]
        public async Task<ActionResult<List<Brand>>> GetBrands()
        {
            var body = new SocialInsiderAPIBody();
            body.method = "socialinsider_api.get_brands";
            body.parameters = new Dictionary<string, object> { { "projectname", "API_test" } };
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);
            var response = await httpClient.PostAsJsonAsync(apiUrl, body);
            Console.Write("apel_brands");
            if (response.IsSuccessStatusCode)
            {
                var brand_data = await response.Content.ReadFromJsonAsync<SocialInsiderAPIResponse<List<SocialInsiderBrand>>>();
                var res = brand_data.result.Select(brand => new Brand { Name = brand.Name, Counter = brand.Profiles.Count() }).ToList();
                //var res2 = brand_data.result.Select(brand => new Brand { Profiles = brand.Profiles }).Count();
                return res;
            }
            else
                return NotFound();
        }

        /*[HttpGet]
        public async Task<ActionResult<List<Profile>>> GetProfiles()
        {
            var body = new SocialInsiderAPIBody();
            body.method = "socialinsider_api.get_profiles";
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
            Console.Write("aaaaaaaaaaaaaaaaaaaaa");
            if (response.IsSuccessStatusCode)
            {
                Console.Write(response);
                //var brand_data = await response.Content.ReadFromJsonAsync<SocialInsiderAPIResponse<List<SocialInsiderBrand>>>();
                //var res = brand_data.result.Select(brand => new Brand { Name = brand.Name }).ToList();
                //var res2 = brand_data.result.Select(brand => new Brand { Profiles = brand.Profiles });
                return NotFound();
            }
            else
                return NotFound();

        }*/

        public BrandsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
    }  
}
