using stepik.Services;

public class MainMenu(ServiceProvider _serviceProvider)
{
    public void Display()
    {
        var totalCoursesCount = _serviceProvider.coursesService.GetTotalCount();
        var totalUsersCount = _serviceProvider.usersService.GetTotalCount();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("************************************************\n" +
                          "* Добро пожаловать на онлайн платформу Stepik! *\n" +
                          "************************************************\n" +
                          $"Количество курсов на платформе: {totalCoursesCount}\n" +
                          $"Количество пользователей на платформе: {totalUsersCount}\n\n" +
                          "Выберите действие (введите число и нажмите Enter):\n\n" +
                          "1. Войти\n" +
                          "2. Зарегистрироваться\n" +
                          "3. Рейтинг пользователей\n" +
                          "4. Закрыть приложение\n" +
                          "************************************************");
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
                    User user = _serviceProvider.usersProcessing.PerformLogin();
                    if (!string.IsNullOrEmpty(user?.full_name))
                    {
                        HandleUserMenu(user);
                    }
                    Display();
                    break;
                case "2":
                    User newUser = _serviceProvider.usersProcessing.PerformRegistration();
                    if (!string.IsNullOrEmpty(newUser?.full_name))
                    {
                        HandleUserMenu(newUser);
                    }
                    break;
                case "3":
                    HandleUserRatingMenu();
                    break;
                case "4":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("До свидания!\n");
                    Console.ResetColor();
                    Environment.Exit(0);
                    break;
                default:
                    _serviceProvider.wrongChoice.PrintWrongChoiceMessage();
                    break;
            }
        }
    }

    private void HandleUserMenu(User user)
    {
        var userMenu = new UserMenu(user, _serviceProvider);
        userMenu.Display();
        userMenu.HandleUserChoice();
    }

    private void HandleUserRatingMenu()
    {
        var ratingMenu = new RatingMenu(_serviceProvider);
        ratingMenu.Display();
        ratingMenu.HandleUserChoice();
    }
}
