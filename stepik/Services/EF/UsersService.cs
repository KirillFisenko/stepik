using System.Data;

namespace stepik.Services.EF;

public class UsersService : IUsersService
{
    /// <summary>
    /// Добавление нового пользователя в таблицу users
    /// </summary>
    /// <param name="user">Новый пользователь</param>
    /// <returns>Удалось ли добавить пользователя</returns>
    public bool Add(User user)
    {
        try
        {
            using ApplicationDbContext dbContext = new();
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Получение пользователя из таблицы users
    /// </summary>
    /// <param name="fullName">Полное имя пользователя</param>
    /// <returns>User</returns>    
    public User? Get(string fullName)
    {
        using ApplicationDbContext dbContext = new();
        return dbContext.Users
            .FirstOrDefault(u => u.full_name == fullName && u.is_active);
    }

    /// <summary>
    /// Получение общего количества пользователей
    /// </summary>
    public int GetTotalCount()
    {
        using ApplicationDbContext dbContext = new();
        return dbContext.Users.Count();
    }

    /// <summary>
    /// Форматирование показателей пользователя
    /// </summary>
    /// <param name="number">Число для форматирования</param>
    /// <returns>Отформатированное число</returns>
    public string? FormatUserMetrics(int number)
    {
        if (number < 1000)
        {
            return number.ToString();
        }
        else
        {
            double formattedNumber = number / 1000.0;
            string formattedString = formattedNumber
                .ToString("0.0K", System.Globalization.CultureInfo.InvariantCulture)
                .Replace(".0K", "K");
            return formattedString;
        }
    }

    public DataSet GetUserRating()
    {
        throw new NotImplementedException();
    }

    public DataSet GetUserSocialInfo(string userName)
    {
        throw new NotImplementedException();
    }
}
