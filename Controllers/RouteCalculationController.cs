using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Contoso_Game_Application.Application;

namespace Contoso_Game_Application.Controllers
{
    [Route("Contoso/[controller]")]
    [ApiController]
    public class RouteCalculationController : ControllerBase
    {

         
        [HttpGet(Name = "Number of routes Calculation")]
        public async Task<IActionResult> RouteCalculator(string Source,string Destination)
        {


            var result = new Routes();

            int NoOfPaths= result.GetNumberOfPaths(Source, Destination, 2);

            return Ok(NoOfPaths);
        }



    }
}
