public record class ProfileMenu(User _user, WrongChoice _wrongChoice)
{
    private readonly UsersService _usersService = new();
    public void Display()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n* " + _user.FullName + " *\n\n" +
                          "Выберите действие (введите число и нажмите Enter):\n" +
                          "1. Назад\n\n" +
                          "Профиль пользователя: " + _user.FullName + "\n" +
                          "Дата регистрации: " + _user.JoinDate + "\n" +
                          "Описание профиля: " + (_user.Details ?? "Не заполнено") + "\n" +
                          "Фото профиля: " + (_user.Avatar ?? "Не заполнено") + "\n" +
                          _usersService.FormatUserMetrics(_user.FollowersCount) + " подписчиков\n" +
                          _usersService.FormatUserMetrics(_user.Reputation) + " репутация\n" +
                          _usersService.FormatUserMetrics(_user.Knowledge) + " знания");
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
                    var userMenu = new UserMenu(_user, _wrongChoice);
                    userMenu.Display();
                    userMenu.HandleUserChoice();
                    return;
                default:
                    _wrongChoice.PrintWrongChoiceMessage();
                    break;
            }
        }
    }
}
