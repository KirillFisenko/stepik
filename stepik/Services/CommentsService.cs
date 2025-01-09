using MySql.Data.MySqlClient;
using stepik.Models;

namespace stepik.Services
{
    public class CommentsService
    {
        /// <summary>
        /// Получение всех комментариев к курсу
        /// </summary>
        /// <param name="id">id курса</param>
        /// <returns>Список комментариев</returns>
        public static List<Comment> Get(int id)
        {
            var comments = new List<Comment>();

            using var connection = new MySqlConnection(Constant.ConnectionString);
            connection.Open();

            var query = @"SELECT c.id, c.text, c.time
                          FROM comments AS c
                          JOIN steps AS s ON c.step_id = s.id
                          JOIN unit_lessons AS ul ON s.id = ul.lesson_id
                          JOIN lessons AS l ON ul.lesson_id = l.id
                          JOIN units AS u ON ul.unit_id = u.id
                          JOIN courses AS cr ON u.course_id = cr.id
                          WHERE reply_comment_id IS NULL AND cr.id = @id
                          ORDER BY c.time DESC;";

            using var command = new MySqlCommand(query, connection);
            var idParam = new MySqlParameter("@id", id);
            command.Parameters.Add(idParam);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var comment = new Comment
                {
                    Id = reader.GetInt32(0),
                    Text = reader.GetString(1),
                    Time = reader.GetDateTime(2),
                };
                comments.Add(comment);
            }

            return comments;
        }

        /// <summary>
        /// Удаление комментария пользователя
        /// </summary>
        /// <param name="id">id комментария</param>
        /// <returns>Удалось ли удалить комментарий</returns>
        public static bool Delete(int id)
        {
            using var connection = new MySqlConnection(Constant.ConnectionString);
            connection.Open();
            MySqlTransaction transaction = connection.BeginTransaction();

            try
            {
                string sqlQuery = @"DELETE FROM course_reviews
                                    WHERE comment_id = @id;";

                using MySqlCommand command = new MySqlCommand(sqlQuery, connection, transaction);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();

                command.CommandText = $@"DELETE FROM comments
                                         WHERE reply_comment_id = @id;";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();

                command.CommandText = $@"DELETE FROM comments
                                         WHERE id = @id;";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();

                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }
        }
    }
}
