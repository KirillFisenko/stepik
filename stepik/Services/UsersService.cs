using MySql.Data.MySqlClient;
using System.Data;

public class UsersService
{
    /// <summary>
    /// Добавление нового пользователя в таблицу users
    /// </summary>
    /// <param name="user">Новый пользователь</param>
    /// <returns>Удалось ли добавить пользователя</returns>
    public static bool Add(User user)
    {
        try
        {
            using var connection = new MySqlConnection(Constant.ConnectionString);
            connection.Open();
            var query = @"
                INSERT INTO users (full_name, details, join_date, avatar, is_active)
                VALUES (@FullName, @Details, @JoinDate, @Avatar, @IsActive)";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@FullName", user.FullName);
            command.Parameters.AddWithValue("@Details", user.Details);
            command.Parameters.AddWithValue("@JoinDate", user.JoinDate);
            command.Parameters.AddWithValue("@Avatar", user.Avatar);
            command.Parameters.AddWithValue("@IsActive", user.IsActive);
            var rowsAffected = command.ExecuteNonQuery();
            return rowsAffected == 1;
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
    public static User Get(string fullName)
    {
        User user = null;
        using var connection = new MySqlConnection(Constant.ConnectionString);
        connection.Open();
        var query = @"SELECT * FROM users
                  WHERE full_name = @FullName AND is_active = 1;";
        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@FullName", fullName);
        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            user = new User
            {
                FullName = reader.IsDBNull(1) ? null : reader.GetString(1),
                Details = reader.IsDBNull(2) ? null : reader.GetString(2),
                JoinDate = reader.GetDateTime(3),
                Avatar = reader.IsDBNull(4) ? null : reader.GetString(4),
                IsActive = reader.GetBoolean(5)
            };
        }

        return user;
    }

    /// <summary>
    /// Получение общего количества пользователей
    /// </summary>
    public static int GetTotalCount()
    {
        using var connection = new MySqlConnection(Constant.ConnectionString);
        connection.Open();

        var query = "SELECT COUNT(*) FROM users;";

        using var command = new MySqlCommand(query, connection);
        var result = command.ExecuteScalar();

        return result != null ? Convert.ToInt32(result) : 0;
    }

    /// <summary>
    /// Форматирование показателей пользователя
    /// </summary>
    /// <param name="number">Число для форматирования</param>
    /// <returns>Отформатированное число</returns>
    public static string FormatUserMetrics(int number)
    {
        using var connection = new MySqlConnection(Constant.ConnectionString);
        connection.Open();

        using var command = new MySqlCommand("format_number", connection);
        command.CommandType = CommandType.StoredProcedure;

        var numberParam = new MySqlParameter("number", number)
        {
            Direction = ParameterDirection.Input
        };
        command.Parameters.Add(numberParam);

        var returnValueParam = new MySqlParameter()
        {
            Direction = ParameterDirection.ReturnValue
        };
        command.Parameters.Add(returnValueParam);

        command.ExecuteNonQuery();

        var returnValue = returnValueParam.Value;
        return returnValue != null ? returnValue.ToString() : string.Empty;
    }
}