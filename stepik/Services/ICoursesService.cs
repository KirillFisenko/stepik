namespace stepik.Services;

public interface ICoursesService
{
    /// <summary>
    /// Получение списка курсов пользователя
    /// </summary>
    /// <param name="fullName">Полное имя пользователя</param>
    /// <returns>Список курсов</returns>
    List<Course> Get(string fullName);

    /// <summary>
    /// Получение общего количества курсов
    /// </summary>
    int GetTotalCount();
}
