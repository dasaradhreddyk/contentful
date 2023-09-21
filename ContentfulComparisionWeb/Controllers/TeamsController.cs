using ContentfulComparisionWeb.Builder;
using ContentfulComparisionWeb.Services.ContentFulFactory;
using ContentfulComparisionWeb.ContentFul.Core.ReportGenerator.PostToTeams;
using GraphQL.Client.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContentfulComparisionWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
 
        private readonly ILogger<TeamsController> _logger;

        public TeamsController(ILogger<TeamsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task Post()
        {
           var response =  await PostReportForContentChangesToTeams.PostReportForContentChangesToTeamsAsync();
        }

    }
}