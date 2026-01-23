using Storage.DAL.Models;

namespace Storage.DAL.Repositories.Interfaces;

using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// Репозиторий справочник для получения изготавливаемых продуктов компанией.
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Получает продукт по его идентификатору.
    /// <param name="productId">Идентификатор продукта.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Изготавливаемый продукт. <see cref="Product"/>.</returns>
    /// </summary>
    Task<Product?> GetByIdAsync(int productId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Ищет продукты по совпадению названия.
    /// <param name="name">Название продукта.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Изготавливаемый продукт. <see cref="Product"/>.</returns>
    /// </summary>
    Task<Product?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
}