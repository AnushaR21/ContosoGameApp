using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contoso_Game_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistanceCalculationController : ControllerBase
    {
       

        [HttpGet(Name = "LandmarkDistance Calculation")]
        public async Task<IActionResult> CalculateDistance(string route)
        {
            Dictionary<string, double> distance = new Dictionary<string, double>();
            distance.Add("AB", 3);
            distance.Add("BC", 9);
            distance.Add("CD", 3);
            distance.Add("DE", 6);
            distance.Add("AD", 4);
            distance.Add("DA", 5);
            distance.Add("CE", 2);
            distance.Add("AE", 4);
            distance.Add("EB", 1);

            double result = 0;
            int length = route.Length;
            string[] input = new string[length];

            for (int i = 0; i < length; i++)
            {
                input[i] = route[i].ToString();

            }

            for (int i = 0; i < length; i++)
            {
                string start = input[i];

                if (!(i >= length - 1))
                {
                    string end = input[i + 1];


                    if (distance.ContainsKey(start + end))
                    {
                        result = result + distance[start + end];
                    }
                    else
                    {
                        result = 0;
                        break;
                    }
                }
                else
                {
                    break;
                }

            }

            if (result == 0)
                return NotFound("Path Not Found");

            else
                return Ok(result);


        }

        
    }
}
