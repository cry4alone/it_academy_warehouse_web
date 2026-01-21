using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.BLL.Services.Interfaces;
using Storage.BLL.DTO.Requests.MeltRequests;

namespace Storage.API.Controllers;

/// <summary>
/// Контроллер для управления выплавками (melts): предоставляет операции чтения списка выплавок.
/// Методы контроллера защищены авторизацией и используют <see cref="IMeltService"/> для бизнес-логики.
/// </summary>
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

      /// <summary>
      /// Возвращает список всех выплавок.
      /// </summary>
      /// <param name="cancellationToken">Токен отмены операции.</param>
      /// <returns>200 OK с коллекцией DTO выплавок.</returns>
      [HttpGet]
      [Authorize(Policy = "Melt.View")]
      public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
      {
            var melts = await _meltService.ListMeltsAsync(cancellationToken);
            return Ok(melts);
      }

      [HttpGet("{id}")]
      [Authorize(Policy = "Melt.View")]
      public async Task<IActionResult> GetByIdAsync([FromRoute] int id, CancellationToken cancellationToken)
      {
            var melt = await _meltService.GetMeltByIdAsync(id, cancellationToken);
            return Ok(melt);
      }

      [HttpPost]
      [Authorize(Policy = "Melt.Create")]
      public async Task<IActionResult> CreateMeltAsync([FromBody] CreateMeltRequest createMeltRequest, CancellationToken cancellationToken)
      {
            var createdMelt = await _meltService.CreateMeltAsync(createMeltRequest, cancellationToken);

            return CreatedAtAction("GetById", new { id = createdMelt.MeltId }, createdMelt);
      }

      [HttpPut]
      // [Authorize(Policy = "Melt.Edit")]
      public async Task<IActionResult> UpdateMeltAsync([FromBody] UpdateMeltRequest updateMeltRequest,
            CancellationToken cancellationToken)
      {
            var updatedMelt = await _meltService.UpdateMeltAsync(updateMeltRequest, cancellationToken);
            
            return Ok(updatedMelt);
      }

      [HttpDelete("{id}")]
      [Authorize(Policy = "Melt.Delete")]
      public async Task<IActionResult> DeleteMeltAsync([FromRoute] int id, CancellationToken cancellationToken)
      {
            await _meltService.DeleteMeltAsync(id, cancellationToken);
            return NoContent();
      }
      
}