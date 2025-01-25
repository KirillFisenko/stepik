public record class UserMenu(User _user, WrongChoice _wrongChoice)
{
    public void Display()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n* " + _user.FullName + " *\n\n" +
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

    private void HandleProfileMenu()
    {
        var profileMenu = new ProfileMenu(_user, _wrongChoice);
        profileMenu.Display();
        profileMenu.HandleUserChoice();
    }

    private void HandleUserCoursesMenu()
    {
        var coursesMenu = new CoursesMenu(_user, _wrongChoice);
        coursesMenu.Display();
        coursesMenu.HandleUserChoice();
    }

    private void HandleUserCertificateMenu()
    {
        var certificateMenu = new CertificateMenu(_user, _wrongChoice);
        certificateMenu.Display();
        certificateMenu.HandleUserChoice();
    }
}
