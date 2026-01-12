namespace Storage.BLL.Services.Interfaces;

/// <summary>
/// Сервис для хеширования паролей и проверки соответствия предоставленного пароля и хэшированного значения.
/// Используется для безопасного хранения и валидации паролей пользователей.
/// </summary>
public interface IPasswordHashingService
{
    /// <summary>
    /// Вычисляет хеш пароля для последующего сохранения в хранилище.
    /// </summary>
    /// <param name="password">Исходная текстовая строка пароля.</param>
    /// <returns>Строка, содержащая хеш и (по реализации) соль в формате, принятом в проекте.</returns>
    string HashPassword(string password);

    /// <summary>
    /// Проверяет соответствие хэшированного пароля и введённого пользователем пароля.
    /// </summary>
    /// <param name="hashedPassword">Хранимое хэшированное представление пароля.</param>
    /// <param name="providedPassword">Пароль, предоставленный пользователем.</param>
    /// <returns><c>true</c>, если пароли совпадают; иначе <c>false</c>.</returns>
    bool VerifyHashedPassword(string hashedPassword, string providedPassword);
}