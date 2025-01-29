using Microsoft.AspNetCore.Mvc;
using Stories.DAO;
using System.Text.Json;

namespace Stories.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrincipalController : ControllerBase
    {
        private readonly GetStories _getStories;

        public PrincipalController(GetStories getStories)
        {
            _getStories = getStories;
        }

        [HttpGet("{n}")]
        public async Task<IActionResult> Get(int n)
        {
            string? result = null;

            try
            {
                
                List<Models.details> cacheDetails = Services.DetailsCache.Details;

                if (cacheDetails.Count == 0)
                {
                    await _getStories.Stories();

                    cacheDetails = Services.DetailsCache.Details;
                }

                if (cacheDetails.Count > 0)
                {
                    if (n <= 0)
                    {
                        return BadRequest($"The entered number must be greater than zero and less than or equal to {cacheDetails.Count}.");
                    }

                    var selectedStories = cacheDetails.Take(n).ToList();

                    result = JsonSerializer.Serialize(selectedStories, new JsonSerializerOptions { WriteIndented = true });
                }
                else
                {
                    return BadRequest("Error while obtaining stories. Please try again.");
                }
            }
            catch (Exception)
            {
                return BadRequest("Error while obtaining stories. Please try again.");
            }

            return Ok(result);
        }
    }
}
