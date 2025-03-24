using stepik.Services;
using System.Data;

public record class ProfileMenu(User _user)
{
    public void Display()
    {
        var socialInfo = ServiceProvider.usersService.GetUserSocialInfo(_user.full_name);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n* " + _user.full_name + " *\n\n" +
                          "Выберите действие (введите число и нажмите Enter):\n" +
                          "1. Назад\n\n" +
                          "Профиль пользователя: " + _user.full_name + "\n" +
                          "Дата регистрации: " + _user.join_date + "\n" +
                          "Описание профиля: " + (_user.details ?? "Не заполнено") + "\n" +
                          "Фото профиля: " + (_user.avatar ?? "Не заполнено") + "\n" +
                          ServiceProvider.usersService.FormatUserMetrics(_user.followers_count) + " подписчиков\n" +
                          ServiceProvider.usersService.FormatUserMetrics(_user.reputation) + " репутация\n" +
                          ServiceProvider.usersService.FormatUserMetrics(_user.knowledge) + " знания\n\n" +
                          "Социальные сети:");

        if (socialInfo.Tables.Count == 0 || socialInfo.Tables[0].Rows.Count == 0)
        {
            Console.WriteLine("У пользователя еще нет социальных сетей");
            Console.ResetColor();
            return;
        }

        var indent = 25;
        var separatorCount = 70;

        Console.WriteLine(new string('-', separatorCount));

        foreach (DataRow row in socialInfo.Tables[0].Rows)
        {
            Console.WriteLine($"{row["name"]?.ToString()?.PadRight(indent)} " +
                              $"{row["connect_url"]?.ToString()?.PadRight(indent)}");
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
                    var userMenu = new UserMenu(_user);
                    userMenu.Display();
                    userMenu.HandleUserChoice();
                    return;
                default:
                    ServiceProvider.wrongChoice.PrintWrongChoiceMessage();
                    break;
            }
        }
    }
}
