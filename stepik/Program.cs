public class Program
{
    /// <summary>
    /// Обработка начального меню
    /// </summary>
    public static void Main()
    {
        DisplayMainMenu();

        while (true)
        {
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    User user = PerformLogin();
                    if (!string.IsNullOrEmpty(user?.FullName))
                    {
                        HandleUserMenu(user);
                    }
                    break;
                case "2":
                    User newUser = PerformRegistration();
                    if (!string.IsNullOrEmpty(newUser?.FullName))
                    {
                        HandleUserMenu(newUser);
                    }
                    break;
                case "3":
                    Console.WriteLine("До свидания!\n");
                    return;
                default:
                    PrintWrongChoiceMessage();
                    break;
            }
        }
    }

    /// <summary>
    /// Отображение главного меню приложения.
    /// </summary>
    public static void DisplayMainMenu()
    {
        Console.WriteLine(@"
************************************************
* Добро пожаловать на онлайн платформу Stepik! *
************************************************

Выберите действие (введите число и нажмите Enter):

1. Войти
2. Зарегистрироваться
3. Закрыть приложение

************************************************

");
    }

    /// <summary>
    /// Вывод сообщения об ошибке при неверном выборе.
    /// </summary>
    public static void PrintWrongChoiceMessage()
    {
        Console.WriteLine("Неверный выбор. Попробуйте снова.");
    }

    /// <summary>
    /// Регистрация нового пользователя.
    /// </summary>
    /// <returns>Возвращает объект пользователя, если регистрация успешна, иначе пустой объект.</returns>
    public static User PerformRegistration()
    {
        var userName = "";
        while (string.IsNullOrEmpty(userName))
        {
            Console.WriteLine("Введите имя и фамилию через пробел и нажмите Enter:");
            userName = Console.ReadLine();
        }

        var newUser = new User
        {
            FullName = userName
        };

        bool isAdditionSuccessful = UsersService.Add(newUser);

        if (isAdditionSuccessful)
        {
            Console.WriteLine($"Пользователь '{newUser.FullName}' успешно добавлен.\n");
            return newUser;
        }
        else
        {
            Console.WriteLine($"Произошла ошибка, произведен выход на главную страницу.\n");
            DisplayMainMenu();
            return new User();
        }
    }

    /// <summary>
    /// Вход пользователя в систему.
    /// </summary>
    /// <returns>Возвращает объект пользователя, если вход успешен, иначе пустой объект.</returns>
    public static User PerformLogin()
    {
        var userName = "";
        while (string.IsNullOrEmpty(userName))
        {
            Console.WriteLine("Введите имя и фамилию через пробел и нажмите Enter:");
            userName = Console.ReadLine();
        }

        User user = UsersService.Get(userName);

        if (!string.IsNullOrEmpty(user?.FullName))
        {
            Console.WriteLine($"Пользователь '{user.FullName}' успешно вошел.\n");
            return user;
        }
        else
        {
            Console.WriteLine($"Пользователь не найден, произведен выход на главную страницу.\n");
            DisplayMainMenu();
            return new User();
        }
    }

    /// <summary>
    /// Обрабатка меню пользователя после успешного входа.
    /// </summary>
    public static void HandleUserMenu(User user)
    {
        while (true)
        {
            DisplayUserMenu(user);
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    HandleProfileMenu(user);
                    break;
                case "2":
                    HandleUserCoursesMenu(user);
                    break;
                case "3":
                    DisplayMainMenu();
                    return;
                default:
                    PrintWrongChoiceMessage();
                    break;
            }
        }
    }

    /// <summary>
    /// Отображение меню пользователя.
    /// </summary>
    public static void DisplayUserMenu(User user)
    {
        Console.WriteLine(@$"
* {user.FullName} *

Выберите действие (введите число и нажмите Enter):

1. Посмотреть профиль
2. Посмотреть курсы
3. Выйти
");
    }

    /// <summary>
    /// Обработка меню профиля.
    /// </summary>
    public static void HandleProfileMenu(User user)
    {
        while (true)
        {
            DisplayProfileDetails(user);
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    return;
                default:
                    PrintWrongChoiceMessage();
                    break;
            }
        }
    }

    /// <summary>
    /// Отображение деталей профиля.
    /// </summary>
    public static void DisplayProfileDetails(User user)
    {
        Console.WriteLine(@$"
* {user.FullName} *

Выберите действие (введите число и нажмите Enter):

1. Назад

Профиль пользователя: {user.FullName}
Дата регистрации: {user.JoinDate}
Описание профиля: {user.Details ?? "Не заполнено"}
Фото профиля: {user.Avatar ?? "Не заполнено"}
");
    }

    /// <summary>
    /// Обработка меню курсов пользователя.
    /// </summary>
    public static void HandleUserCoursesMenu(User user)
    {
        while (true)
        {
            DisplayUserCourses(user.FullName);
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    return;
                default:
                    PrintWrongChoiceMessage();
                    break;
            }
        }
    }

    /// <summary>
    /// Отображение списка курсов пользователя.
    /// </summary>
    private static void DisplayUserCourses(string fullName)
    {
        List<Course> courses = CoursesService.Get(fullName);
        Console.WriteLine(@$"* Список курсов {fullName} *

Выберите действие (введите число и нажмите Enter):

1. Назад
");
        var count = 1;

        if (courses.Count == 0)
        {
            Console.WriteLine("У пользователя еще нет курсов.");
        }
        else
        {
            foreach (var course in courses)
            {
                Console.WriteLine(@$"
______________________________________________
{count}.
Название: {course.Title}
Описание: {course.Summary ?? "Отсутствует"}
Фото: {course.Photo ?? "Отсутствует"}
______________________________________________");
                count++;
            }
        }
    }
}