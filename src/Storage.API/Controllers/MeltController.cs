using Microsoft.AspNetCore.Mvc;
using Storage.BLL.Services;

namespace Storage.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MeltController : ControllerBase
{
      private readonly MeltService _meltService;

      public MeltController(MeltService meltService)
      {
            _meltService = meltService;
      }

      [HttpGet]
      public async Task<IActionResult> GetAsync()
      {
            var melts = await _meltService.ListMeltsAsync();
            return Ok(melts);
      }
}