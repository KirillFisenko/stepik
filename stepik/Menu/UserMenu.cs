using stepik.Services;

public record class UserMenu(User _user, ServiceProvider _serviceProvider)
{
    public void Display()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n* " + _user.full_name + " *\n\n" +
                          "Выберите действие (введите число и нажмите Enter):\n" +
                          "1. Посмотреть профиль\n" +
                          "2. Посмотреть курсы\n" +
                          "3. Посмотреть сертификаты\n" +
                          "4. Выйти");
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
                    HandleProfileMenu();
                    break;
                case "2":
                    HandleUserCoursesMenu();
                    break;
                case "3":
                    HandleUserCertificateMenu();
                    break;
                case "4":
                    var mainMenu = new MainMenu(_serviceProvider);
                    mainMenu.Display();
                    mainMenu.HandleUserChoice();
                    return;
                default:
                    _serviceProvider.wrongChoice.PrintWrongChoiceMessage();
                    break;
            }
        }
    }

    private void HandleProfileMenu()
    {
        var profileMenu = new ProfileMenu(_user, _serviceProvider);
        profileMenu.Display();
        profileMenu.HandleUserChoice();
    }

    private void HandleUserCoursesMenu()
    {
        var coursesMenu = new CoursesMenu(_user, _serviceProvider);
        coursesMenu.Display();
        coursesMenu.HandleUserChoice();
    }

    private void HandleUserCertificateMenu()
    {
        var certificateMenu = new CertificateMenu(_user, _serviceProvider);
        certificateMenu.Display();
        certificateMenu.HandleUserChoice();
    }
}
