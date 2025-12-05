using Microsoft.AspNetCore.Mvc;
using Storage.BLL.Services.Interfaces;

namespace Storage.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MeltController : ControllerBase
{
      private readonly IMeltService _meltService;

      public MeltController(IMeltService meltService)
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