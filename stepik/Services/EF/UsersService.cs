using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Globalization;

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
            .AsNoTracking()
            .FirstOrDefault(u => u.FullName == fullName && u.IsActive);
    }

    /// <summary>
    /// Получение общего количества пользователей
    /// </summary>
    public int GetTotalCount()
    {
        using ApplicationDbContext dbContext = new();
        return dbContext.Users
            .AsNoTracking()
            .Count();
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
                .ToString("0.0K", CultureInfo.InvariantCulture)
                .Replace(".0K", "K");
            return formattedString;
        }
    }

    /// <summary>
    /// Рейтинг пользователей (топ-10 по знаниям)
    /// </summary>
    /// <returns>DataSet</returns>
    public DataSet GetUserRating()
    {
        using ApplicationDbContext dbContext = new();

        var topUsers = dbContext.Users
            .Where(u => u.IsActive)
            .AsNoTracking()
            .OrderByDescending(u => u.Knowledge)
            .Take(10)
            .Select(u => new
            {
                u.FullName,
                u.Knowledge,
                u.Reputation
            })
            .ToList();

        var dataTable = new DataTable("UserRating");
        dataTable.Columns.Add("full_name", typeof(string));
        dataTable.Columns.Add("knowledge", typeof(int));
        dataTable.Columns.Add("reputation", typeof(int));

        foreach (var user in topUsers)
        {
            dataTable.Rows.Add(user.FullName, user.Knowledge, user.Reputation);
        }

        var dataSet = new DataSet();
        dataSet.Tables.Add(dataTable);
        return dataSet;
    }

    /// <summary>
    /// Получение социальной информации пользователя
    /// </summary>
    /// <param name="userName">Имя пользователя</param>
    /// <returns>DataSet</returns>
    public DataSet GetUserSocialInfo(string userName)
    {
        using var dbContext = new ApplicationDbContext();

        var socialInfos = (
            from u in dbContext.Users
            join usp in dbContext.UserSocialProviders on u.Id equals usp.UserId
            join sp in dbContext.SocialProviders on usp.SocialProviderId equals sp.Id
            where u.FullName == userName
            orderby sp.Name
            select new
            {
                sp.Name,
                usp.ConnectUrl
            }
        ).ToList();

        var dataTable = new DataTable("user_social_providers");
        dataTable.Columns.Add("name", typeof(string));
        dataTable.Columns.Add("connect_url", typeof(string));

        foreach (var info in socialInfos)
        {
            dataTable.Rows.Add(info.Name, info.ConnectUrl);
        }

        var dataSet = new DataSet();
        dataSet.Tables.Add(dataTable);
        return dataSet;
    }
}
