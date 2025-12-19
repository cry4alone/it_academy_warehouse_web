using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.BLL.Services.Interfaces;
using System.Threading;

namespace Storage.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MeltController : ControllerBase
{
      private readonly IMeltService _meltService;

      public MeltController(IMeltService meltService)
      {
            _meltService = meltService;
      }

      [HttpGet]
      [Authorize(Policy = "Melt.View")]
      public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
      {
            var melts = await _meltService.ListMeltsAsync(cancellationToken);
            return Ok(melts);
      }
}