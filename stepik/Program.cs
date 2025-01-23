using System.Data;

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
            string? choice = Console.ReadLine();

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
                    HandleUserRatingMenu();
                    break;
                case "4":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("До свидания!\n");
                    Console.ResetColor();
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
        var totalCoursesCount = CoursesService.GetTotalCount();
        var totalUsersCount = UsersService.GetTotalCount();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("************************************************\n" +
                          "* Добро пожаловать на онлайн платформу Stepik! *\n" +
                          "************************************************\n" +
                          "Количество курсов на платформе: " + totalCoursesCount + "\n" +
                          "Количество пользователей на платформе: " + totalUsersCount + "\n\n" +
                          "Выберите действие (введите число и нажмите Enter):\n\n" +
                          "1. Войти\n" +
                          "2. Зарегистрироваться\n" +
                          "3. Рейтинг пользователей\n" +
                          "4. Закрыть приложение\n" +
                          "************************************************");
        Console.ResetColor();
    }

    /// <summary>
    /// Вывод сообщения об ошибке при неверном выборе.
    /// </summary>
    public static void PrintWrongChoiceMessage()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Неверный выбор. Попробуйте снова.");
        Console.ResetColor();
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Пользователь '{newUser.FullName}' успешно добавлен.\n");
            Console.ResetColor();
            return newUser;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Произошла ошибка, произведен выход на главную страницу.\n");
            Console.ResetColor();
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

        User? user = UsersService.Get(userName);

        if (user != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Пользователь '{user.FullName}' успешно вошел.\n");
            Console.ResetColor();
            return user;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Пользователь не найден, произведен выход на главную страницу.\n");
            Console.ResetColor();
            DisplayMainMenu();
            return new User();
        }
    }

    /// <summary>
    /// Обработка меню пользователя после успешного входа.
    /// </summary>
    public static void HandleUserMenu(User user)
    {
        while (true)
        {
            DisplayUserMenu(user);
            string? choice = Console.ReadLine();

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
    /// Обработка меню рейтинга пользователей.
    /// </summary>
    public static void HandleUserRatingMenu()
    {
        while (true)
        {
            DisplayUserRating();
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayMainMenu();
                    return;
                default:
                    PrintWrongChoiceMessage();
                    break;
            }
        }
    }

    /// <summary>
    /// Отображение рейтинга пользователей.
    /// </summary>
    public static void DisplayUserRating()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n* Рейтинг пользователей *\n\n" +
                          "Выберите действие (введите число и нажмите Enter):\n" +
                          "1. Назад\n");

        var dataSet = UsersService.GetUserRating();

        if (dataSet.Tables.Count == 0 || dataSet.Tables[0].Rows.Count == 0)
        {
            Console.WriteLine("На платформе еще нет пользователей");
            return;
        }

        var indent = 22;
        var separatorCount = 56;

        Console.WriteLine(new string('-', separatorCount));
        Console.WriteLine($"{"Пользователь".PadRight(indent)} {"Знания".PadRight(indent)} {"Репутация".PadRight(indent)}");
        Console.WriteLine(new string('-', separatorCount));

        foreach (DataRow row in dataSet.Tables[0].Rows)
        {
            Console.WriteLine($"{row["full_name"]?.ToString()?.PadRight(indent)} {row["knowledge"]?.ToString()?.PadRight(indent)} {row["reputation"]?.ToString()?.PadRight(indent)}");
        }

        Console.WriteLine(new string('-', separatorCount));
        Console.ResetColor();
    }

    /// <summary>
    /// Отображение меню пользователя.
    /// </summary>
    public static void DisplayUserMenu(User user)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n* " + user.FullName + " *\n\n" +
                          "Выберите действие (введите число и нажмите Enter):\n" +
                          "1. Посмотреть профиль\n" +
                          "2. Посмотреть курсы\n" +
                          "3. Выйти");
        Console.ResetColor();
    }

    /// <summary>
    /// Обработка меню профиля.
    /// </summary>
    public static void HandleProfileMenu(User user)
    {
        while (true)
        {
            DisplayProfileDetails(user);
            string? choice = Console.ReadLine();

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
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n* " + user.FullName + " *\n\n" +
                          "Выберите действие (введите число и нажмите Enter):\n" +
                          "1. Назад\n\n" +
                          "Профиль пользователя: " + user.FullName + "\n" +
                          "Дата регистрации: " + user.JoinDate + "\n" +
                          "Описание профиля: " + (user.Details ?? "Не заполнено") + "\n" +
                          "Фото профиля: " + (user.Avatar ?? "Не заполнено") + "\n" +
                          UsersService.FormatUserMetrics(user.FollowersCount) + " подписчиков\n" +
                          UsersService.FormatUserMetrics(user.Reputation) + " репутация\n" +
                          UsersService.FormatUserMetrics(user.Knowledge) + " знания");
        Console.ResetColor();
    }

    /// <summary>
    /// Обработка меню курсов пользователя.
    /// </summary>
    public static void HandleUserCoursesMenu(User user)
    {
        while (true)
        {
            var coursesIds = DisplayUserCourses(user.FullName);
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "0":
                    return;
                default:
                    if (coursesIds.Contains(choice))
                    {
                        HandleUserCommentsMenu(Convert.ToInt32(choice), user);
                    }
                    else
                    {
                        PrintWrongChoiceMessage();
                    }
                    break;
            }
        }
    }

    /// <summary>
    /// Отображение списка курсов пользователя.
    /// </summary>
    private static IEnumerable<string> DisplayUserCourses(string fullName)
    {
        List<Course> courses = CoursesService.Get(fullName);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n* Список курсов " + fullName + " *\n\n" +
                          "Выберите действие (введите число и нажмите Enter):\n" +
                          "0. Назад");

        if (courses.Count == 0)
        {
            Console.WriteLine("У пользователя еще нет курсов.");
        }
        else
        {
            Console.WriteLine("Для просмотра подробностей курса, введите его id.\n");
            foreach (var course in courses)
            {
                Console.WriteLine("______________________________________________\n" +
                                  "id: " + course.Id + "\n" +
                                  "Название: " + course.Title + "\n" +
                                  "Описание: " + (course.Summary ?? "Отсутствует") + "\n" +
                                  "Фото: " + (course.Photo ?? "Отсутствует") + "\n" +
                                  "______________________________________________");
            }
        }
        Console.ResetColor();
        return courses.Select(x => x.Id.ToString());
    }

    /// <summary>
    /// Обработка меню комментариев пользователя.
    /// </summary>
    public static void HandleUserCommentsMenu(int id, User user)
    {
        while (true)
        {
            var commentsIds = DisplayUserComments(id, user);
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "0":
                    return;
                default:
                    if (commentsIds.Contains(choice))
                    {
                        var isCommentDeleted = CommentsService.Delete(Convert.ToInt32(choice));
                        if (isCommentDeleted)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Комментарий успешно удален");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка удаления комментария");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        PrintWrongChoiceMessage();
                    }
                    break;
            }
        }
    }

    /// <summary>
    /// Отображение комментариев к курсам пользователя.
    /// </summary>
    private static IEnumerable<string> DisplayUserComments(int id, User user)
    {
        List<Course> courses = CoursesService.Get(user.FullName);
        var currentCourse = courses.FirstOrDefault(x => x.Id == id);
        List<Comment> comments = CommentsService.Get(id);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("\n* Комментарии к курсу " + currentCourse?.Title + " *\n\n" +
                          "Выберите действие (введите число и нажмите Enter):\n" +
                          "0. Назад");

        if (comments.Count == 0)
        {
            Console.WriteLine("У курса еще нет комментариев.");
        }
        else
        {
            Console.WriteLine("Чтобы удалить комментарий, введите его id.");
            foreach (var comment in comments)
            {
                Console.WriteLine("______________________________________________\n" +
                                  comment.Id + "\n" +
                                  comment.Time + "\n" +
                                  comment.Text + "\n" +
                                  "______________________________________________");
            }
        }
        Console.ResetColor();
        return comments.Select(x => x.Id.ToString());
    }
}