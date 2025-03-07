using MySql.Data.MySqlClient;
using System.Data;

public partial class UsersService
{
    /// <summary>
    /// Добавление нового пользователя в таблицу users
    /// </summary>
    /// <param name="user">Новый пользователь</param>
    /// <returns>Удалось ли добавить пользователя</returns>
    [Obsolete("Метод ADO.NET устарел")]
    public bool AddOld(User user)
    {
        try
        {
            using var connection = new MySqlConnection(Constant.ConnectionString);
            connection.Open();
            var query = @"INSERT INTO users (full_name, details, join_date, avatar, is_active)
                          VALUES (@FullName, @Details, @JoinDate, @Avatar, @IsActive)";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@FullName", user.full_name);
            command.Parameters.AddWithValue("@Details", user.details);
            command.Parameters.AddWithValue("@JoinDate", user.join_date);
            command.Parameters.AddWithValue("@Avatar", user.avatar);
            command.Parameters.AddWithValue("@IsActive", user.is_active);
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
    [Obsolete("Метод ADO.NET устарел")]
    public User? GetOld(string fullName)
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
                full_name = reader.GetString("full_name"),
                details = reader.IsDBNull("details") ? null : reader.GetString("details"),
                join_date = reader.GetDateTime("join_date"),
                avatar = reader.IsDBNull("avatar") ? null : reader.GetString("avatar"),
                is_active = reader.GetBoolean("is_active"),
                knowledge = reader.GetInt32("knowledge"),
                reputation = reader.GetInt32("reputation"),
                followers_count = reader.GetInt32("followers_count")
            }
            : null;
    }

    /// <summary>
    /// Получение общего количества пользователей
    /// </summary>
    [Obsolete("Метод ADO.NET устарел")]
    public int GetTotalCountOld()
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
    [Obsolete("Метод ADO.NET устарел")]
    public string? FormatUserMetricsOld(int number)
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