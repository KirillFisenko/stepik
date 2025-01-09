using MySql.Data.MySqlClient;

public class CoursesService
{
    /// <summary>
    /// Получение списка курсов пользователя
    /// </summary>
    /// <param name="fullName">Полное имя пользователя</param>
    /// <returns>Список курсов</returns>
    public static List<Course> Get(string fullName)
    {
        var courses = new List<Course>();

        using var connection = new MySqlConnection(Constant.ConnectionString);
        connection.Open();

        var query = @"SELECT title, summary, photo, courses.id
                      FROM user_courses
                      JOIN courses ON user_courses.course_id = courses.id
                      JOIN users ON users.id = user_courses.user_id
                      WHERE users.full_name = @fullName AND users.is_active = 1
                      ORDER BY user_courses.last_viewed DESC;";

        using var command = new MySqlCommand(query, connection);
        var fullNameParam = new MySqlParameter("@fullName", fullName);
        command.Parameters.Add(fullNameParam);

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var course = new Course
            {
                Title = reader.GetString(0),
                Summary = reader.IsDBNull(1) ? null : reader.GetString(1),
                Photo = reader.IsDBNull(2) ? null : reader.GetString(2),
                Id = reader.GetInt32(3)
            };
            courses.Add(course);
        }

        return courses;
    }

    /// <summary>
    /// Получение общего количества курсов
    /// </summary>
    public static int GetTotalCount()
    {
        using var connection = new MySqlConnection(Constant.ConnectionString);
        connection.Open();

        var query = "SELECT COUNT(*) FROM courses;";

        using var command = new MySqlCommand(query, connection);
        var result = command.ExecuteScalar();

        return result != null ? Convert.ToInt32(result) : 0;
    }
}