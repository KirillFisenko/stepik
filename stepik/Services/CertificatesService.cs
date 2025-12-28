using MySql.Data.MySqlClient;
using System.Data;

public class CertificatesService
{
    /// <summary>
    /// Получение сертификатов пользователя
    /// </summary>
    /// <param name="fullName">Полное имя пользователя</param>
    /// <returns>DataSet</returns>
    public DataSet Get(string fullName)
    {
        using var connection = new MySqlConnection(Constant.ConnectionString);
        connection.Open();
        var query = @"SELECT courses.title, certificates.issue_date, certificates.grade
                          FROM certificates
                          JOIN users ON certificates.user_id = users.id
                          JOIN courses ON certificates.course_id = courses.id
                          WHERE users.full_name = @fullName
                          ORDER BY certificates.issue_date DESC;";
        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@fullName", fullName);
        using var dataAdapter = new MySqlDataAdapter(command);
        var dataSet = new DataSet();
        dataAdapter.Fill(dataSet);
        return dataSet;
    }
}
