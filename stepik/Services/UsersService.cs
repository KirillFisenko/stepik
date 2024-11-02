using MySql.Data.MySqlClient;

public class UsersService
{
    /// <summary>
    /// Добавление нового пользователя в таблицу users
    /// </summary>
    /// <param name="user">Новый пользователь</param>
    /// <returns>Количество вставленных записей</returns>
    public static int Add(User user)
    {
        using (var connection = new MySqlConnection(Constant.connectionString))
        {
            connection.Open();

            string query = @"
                INSERT INTO users (full_name, details, join_date, avatar, is_active)
                VALUES (@FullName, @Details, @JoinDate, @Avatar, @IsActive)";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FullName", user.FullName);
                command.Parameters.AddWithValue("@Details", user.Details);
                command.Parameters.AddWithValue("@JoinDate", user.JoinDate);
                command.Parameters.AddWithValue("@Avatar", user.Avatar);
                command.Parameters.AddWithValue("@IsActive", user.IsActive);

                var rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            };
        }
    }
}
