using ContentfulComparisionWeb.Builder;
using ContentfulComparisionWeb.ContentFul.Core.ReportGenerator.PostToTeams;
using ContentfulComparisionWeb.Services.ContentFulFactory;
using GraphQL.Client.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContentfulComparisionWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
        CFContentViewModel response = new CFContentViewModel();
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            GetContentModel.GetContentModelAsync("Development");
            GetContentModel.GetContentModelAsync("UAT");
        }

        [HttpGet]
        public async  Task<List<ContentDisplayModelItem>> Get()
        {
           response =  await GetContentfulData();
#pragma warning disable CS8603 // Possible null reference return.
            return response?.ViewModelData;
#pragma warning restore CS8603 // Possible null reference return.
                              //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                              //{
                              //    Date = DateTime.Now.AddDays(index),
                              //    TemperatureC = Random.Shared.Next(-20, 55),
                              //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                              //})
                              //.ToArray();
        }
        public async void GetAwareData()
        {
            response = await  GetContentfulData();
        }
        
        public async  Task<CFContentViewModel> GetContentfulData()
        {
            return  await GetContentUsingGraphQL.ExecuteQueryAsync("Development", "transferCoverPageCollection", "awr", "AwareSuper");
        }


        [HttpPost]
        public async Task<string> Post() {
            var response = await PostReportForContentChangesToTeams.PostReportForContentChangesToTeamsAsync();
            return "success";
        }
    }
}