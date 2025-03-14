using System.Data;

namespace stepik.Services;
public interface ICertificatesService
{
    /// <summary>
    /// Получение сертификатов пользователя
    /// </summary>
    /// <param name="fullName">Полное имя пользователя</param>
    /// <returns>DataSet</returns>
    DataSet Get(string fullName);
}
