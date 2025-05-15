using Application.Exceptions;
using Application.Features.Places.Queries.GetAllUsers;
using Microsoft.AspNetCore.Mvc;

namespace EnlacesGymsWeb.Server.Controllers.v1
{
    [ApiVersion("1.0")]
    public class HiringController : BaseApiController
    {
        [HttpGet("GetAllPlans")]
        public async Task<IActionResult> GetPlans()
        {
            try
            {
                return Ok(await Mediator.Send(new GetAllUsersQuery() { name = "" }));
            }
            catch(ValidationException ext)
            {
                return BadRequest(ext.Errors);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
