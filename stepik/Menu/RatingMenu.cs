using System.Data;

public record class RatingMenu(WrongChoice _wrongChoice)
{
    private readonly UsersService _usersService = new();

    public void Display()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n* Рейтинг пользователей *\n\n" +
                          "Выберите действие (введите число и нажмите Enter):\n" +
                          "1. Назад\n");

        var dataSet = _usersService.GetUserRating();

        if (dataSet.Tables.Count == 0 || dataSet.Tables[0].Rows.Count == 0)
        {
            Console.WriteLine("На платформе еще нет пользователей");
            return;
        }

        var indent = 22;
        var separatorCount = 56;

        Console.WriteLine(new string('-', separatorCount));
        Console.WriteLine($"{"Пользователь".PadRight(indent)} " +
                          $"{"Знания".PadRight(indent)} " +
                          $"{"Репутация".PadRight(indent)}");
        Console.WriteLine(new string('-', separatorCount));

        foreach (DataRow row in dataSet.Tables[0].Rows)
        {
            Console.WriteLine($"{row["full_name"]?.ToString()?.PadRight(indent)} " +
                              $"{row["knowledge"]?.ToString()?.PadRight(indent)} " +
                              $"{row["reputation"]?.ToString()?.PadRight(indent)}");
        }

        Console.WriteLine(new string('-', separatorCount));
        Console.ResetColor();
    }

    public void HandleUserChoice()
    {
        while (true)
        {
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var mainMenu = new MainMenu();
                    mainMenu.Display();
                    mainMenu.HandleUserChoice();
                    return;
                default:
                    _wrongChoice.PrintWrongChoiceMessage();
                    break;
            }
        }
    }
}
