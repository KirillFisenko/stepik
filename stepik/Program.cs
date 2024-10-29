using MySql.Data.MySqlClient;

public class Program
{
    public static void Main()
    {
        string connectionString = "Server=localhost;Database=test;Uid=root;Pwd=m48kHz16bit%;";

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("Подключение открыто");
            Console.WriteLine("Запросы к БД");
        }
        Console.WriteLine("Подключение закрыто");
    }
}