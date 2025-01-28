using MySql.Data.MySqlClient;
using System.Data;

public class UsersService
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
            using var connection = new MySqlConnection(Constant.ConnectionString);
            connection.Open();
            var query = @"INSERT INTO users (full_name, details, join_date, avatar, is_active)
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
    public User? Get(string fullName)
    {
        using var connection = new MySqlConnection(Constant.ConnectionString);
        connection.Open();
        var query = @"SELECT * FROM users
                      WHERE full_name = @FullName AND is_active = 1;";
        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@FullName", fullName);
        using var reader = command.ExecuteReader();
        return reader.Read()
            ? new User
            {
                FullName = reader.GetString("full_name"),
                Details = reader.IsDBNull("details") ? null : reader.GetString("details"),
                JoinDate = reader.GetDateTime("join_date"),
                Avatar = reader.IsDBNull("avatar") ? null : reader.GetString("avatar"),
                IsActive = reader.GetBoolean("is_active"),
                Knowledge = reader.GetInt32("knowledge"),
                Reputation = reader.GetInt32("reputation"),
                FollowersCount = reader.GetInt32("followers_count")
            }
            : null;
    }

    /// <summary>
    /// Получение общего количества пользователей
    /// </summary>
    public int GetTotalCount()
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
    public string? FormatUserMetrics(int number)
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

    /// <summary>
    /// Рейтинг пользователей
    /// </summary>
    /// <returns>DataSet</returns>
    public DataSet GetUserRating()
    {
        using var connection = new MySqlConnection(Constant.ConnectionString);
        connection.Open();
        var query = @"SELECT full_name, knowledge, reputation
                      FROM users
                      WHERE is_active = 1
                      ORDER BY knowledge DESC
                      LIMIT 10;";
        using var command = new MySqlCommand(query, connection);
        using var dataAdapter = new MySqlDataAdapter(command);
        var dataSet = new DataSet();
        dataAdapter.Fill(dataSet);
        return dataSet;
    }

    /// <summary>
    /// Получение социальной информации пользователя
    /// </summary>
    /// <param name="userName">Имя пользователя</param>
    /// <returns>DataSet</returns>
    public DataSet GetUserSocialInfo(string userName)
    {
        using var connection = new MySqlConnection(Constant.ConnectionString);
        connection.Open();
        var query = "CALL get_user_social_info(@user_name);";
        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@user_name", userName);
        using var dataAdapter = new MySqlDataAdapter(command);
        var dataSet = new DataSet();
        dataAdapter.Fill(dataSet);
        return dataSet;
    }
}