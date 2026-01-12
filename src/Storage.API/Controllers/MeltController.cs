using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.BLL.Services.Interfaces;
using System.Threading;

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
}