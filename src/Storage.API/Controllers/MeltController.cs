using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.BLL.Services.Interfaces;
using Storage.BLL.DTO.Requests.MeltRequests;
using System.Threading;

namespace Storage.API.Controllers;

/// <summary>
/// Контроллер для управления выплавками (melts).
/// Предоставляет CRUD‑операции и поддержку постраничного получения списка.
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
      /// Возвращает постраничный список выплавок.
      /// </summary>
      /// <param name="request">Параметры запроса: номер страницы, размер страницы и возможные фильтры (<see cref="GetMeltsRequest"/>).</param>
      /// <param name="cancellationToken">Токен отмены операции.</param>
      /// <returns>200 OK с объектом пагинированного ответа, содержащим коллекцию DTO выплавок и метаданные пагинации.</returns>
      /// <response code="200">Успешный ответ с данными.</response>
      [HttpGet]
      [Authorize(Policy = "Melt.View")]
      public async Task<IActionResult> GetAsync(
            [FromQuery] GetMeltsRequest request,
            CancellationToken cancellationToken = default)
      {
            var pagedResult = await _meltService.GetPagedMeltsAsync(request, cancellationToken);
            return Ok(pagedResult);
      }

      /// <summary>
      /// Возвращает информацию о выплавке по идентификатору.
      /// </summary>
      /// <param name="id">Идентификатор выплавки.</param>
      /// <param name="cancellationToken">Токен отмены операции.</param>
      /// <returns>
      /// 200 OK с DTO выплавки, если найдена; 404 NotFound, если запись не найдена.
      /// </returns>
      /// <response code="200">Найденная выплавка возвращается в теле ответа.</response>
      /// <response code="404">Выплавка с указанным идентификатором не найдена.</response>
      [HttpGet("{id}")]
      [Authorize(Policy = "Melt.View")]
      public async Task<IActionResult> GetByIdAsync([FromRoute] int id, CancellationToken cancellationToken)
      {
            var melt = await _meltService.GetMeltByIdAsync(id, cancellationToken);
            return Ok(melt);
      }

      /// <summary>
      /// Создаёт новую выплавку.
      /// </summary>
      /// <param name="createMeltRequest">Данные для создания выплавки.</param>
      /// <param name="cancellationToken">Токен отмены операции.</param>
      /// <returns>
      /// 201 Created с заголовком Location, указывающим на созданный ресурс, и телом созданной сущности.
      /// </returns>
      /// <response code="201">Ресурс успешно создан.</response>
      /// <response code="400">Неправильные данные запроса.</response>
      [HttpPost]
      [Authorize(Policy = "Melt.Create")]
      public async Task<IActionResult> CreateMeltAsync([FromBody] CreateMeltRequest createMeltRequest, CancellationToken cancellationToken)
      {
            var createdMelt = await _meltService.CreateMeltAsync(createMeltRequest, cancellationToken);

            return CreatedAtAction("GetById", new { id = createdMelt.MeltId }, createdMelt);
      }

      /// <summary>
      /// Обновляет существующую выплавку.
      /// </summary>
      /// <param name="updateMeltRequest">Данные для обновления выплавки.</param>
      /// <param name="cancellationToken">Токен отмены операции.</param>
      /// <returns>
      /// 200 OK с обновлённой сущностью, либо 404 NotFound если сущность не найдена.
      /// </returns>
      /// <response code="200">Обновлённая сущность возвращается в теле ответа.</response>
      /// <response code="404">Сущность для обновления не найдена.</response>
      [HttpPut]
      [Authorize(Policy = "Melt.Edit")]
      public async Task<IActionResult> UpdateMeltAsync([FromBody] UpdateMeltRequest updateMeltRequest,
            CancellationToken cancellationToken)
      {
            var updatedMelt = await _meltService.UpdateMeltAsync(updateMeltRequest, cancellationToken);
            
            return Ok(updatedMelt);
      }

      /// <summary>
      /// Удаляет выплавку по идентификатору.
      /// </summary>
      /// <param name="id">Идентификатор выплавки для удаления.</param>
      /// <param name="cancellationToken">Токен отмены операции.</param>
      /// <returns>204 NoContent при успешном удалении, либо 404 NotFound если сущность не найдена.</returns>
      /// <response code="204">Удаление прошло успешно.</response>
      /// <response code="404">Сущность для удаления не найдена.</response>
      [HttpDelete("{id}")]
      [Authorize(Policy = "Melt.Delete")]
      public async Task<IActionResult> DeleteMeltAsync([FromRoute] int id, CancellationToken cancellationToken)
      {
            await _meltService.DeleteMeltAsync(id, cancellationToken);
            return NoContent();
      }
      
}