using stepik.Models;
using stepik.Services;

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
        var totalUsersCount = CoursesService.GetTotalCount();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine(@$"
        ************************************************
        * Добро пожаловать на онлайн платформу Stepik! *
        ************************************************
        Количество курсов на платформе: {totalCoursesCount}
        Количество пользователей на платформе: {totalUsersCount}

        Выберите действие (введите число и нажмите Enter):

        1. Войти
        2. Зарегистрироваться
        3. Закрыть приложение

        ************************************************

        ");
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

        User user = UsersService.Get(userName);

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
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@$"
        * {user.FullName} *

        Выберите действие (введите число и нажмите Enter):

        1. Посмотреть профиль
        2. Посмотреть курсы
        3. Выйти
        ");
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
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(@$"
        * {user.FullName} *

        Выберите действие (введите число и нажмите Enter):

        1. Назад

        Профиль пользователя: {user.FullName}
        Дата регистрации: {user.JoinDate}
        Описание профиля: {user.Details ?? "Не заполнено"}
        Фото профиля: {user.Avatar ?? "Не заполнено"}
        {UsersService.FormatUserMetrics(user.FollowersCount)} подписчиков
        {UsersService.FormatUserMetrics(user.Reputation)} репутация
        {UsersService.FormatUserMetrics(user.Knowledge)} знания
        ");
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
            string choice = Console.ReadLine();

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
        Console.WriteLine(@$"* Список курсов {fullName} *

        Выберите действие (введите число и нажмите Enter):

        0. Назад        
        ");

        if (courses.Count == 0)
        {
            Console.WriteLine("У пользователя еще нет курсов.");
        }
        else
        {
            Console.WriteLine("Для просмотра подробностей курса, введите его id.");
            foreach (var course in courses)
            {
                Console.WriteLine(@$"
                ______________________________________________
                id: {course.Id}
                Название: {course.Title}
                Описание: {course.Summary ?? "Отсутствует"}
                Фото: {course.Photo ?? "Отсутствует"}
                ______________________________________________");
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
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "0":
                    return;
                default:
                    if (commentsIds.Contains(choice))
                    {
                        var isCommentDeleted = CommentsService.Delete(id);
                        if (isCommentDeleted)
                        {
                            Console.WriteLine("Комментарий успешно удален");
                        }
                        else
                        {
                            Console.WriteLine("Ошибка удаления комментария");
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
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@$"* Комментарии к курсу {currentCourse.Title} *

        Выберите действие (введите число и нажмите Enter):

        0. Назад
        ");

        if (comments.Count == 0)
        {
            Console.WriteLine("У курса еще нет комментариев.");
        }
        else
        {
            Console.WriteLine("Чтобы удалить комментарий, введите его id.");
            foreach (var comment in comments)
            {
                Console.WriteLine(@$"
                ______________________________________________                
                {comment.Id}
                {comment.Time}
                {comment.Text}
                ______________________________________________");
            }
        }
        Console.ResetColor();
        return comments.Select(x => x.Id.ToString());
    }
}