using Microsoft.EntityFrameworkCore;

namespace stepik.Services.EF;

public class CoursesService : ICoursesService
{
    /// <summary>
    /// Получение списка курсов пользователя
    /// </summary>
    /// <param name="fullName">Полное имя пользователя</param>
    /// <returns>Список курсов</returns>
    public List<Course> Get(string fullName)
    {
        using ApplicationDbContext dbContext = new();

        var courses = dbContext.UserCourses
            .AsNoTracking()
            .Include(uc => uc.Course)
            .Where(uc => uc.User.FullName == fullName && uc.User.IsActive)
            .OrderByDescending(uc => uc.LastViewed)
            .Select(uc => uc.Course)
            .ToList();

        return courses;
    }

    /// <summary>
    /// Получение общего количества курсов
    /// </summary>
    public int GetTotalCount()
    {
        using ApplicationDbContext dbContext = new();
        return dbContext.Courses
            .AsNoTracking()
            .Count();
    }
}
