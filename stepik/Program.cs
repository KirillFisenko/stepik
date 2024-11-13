public class Program
{
    public static void Main()
    {
        bool continueProgram = true;

        while (continueProgram)
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

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    LoginUser();
                    break;
                case "2":
                    RegisterUser();
                    break;
                case "3":
                    Console.WriteLine("До свидания!");
                    continueProgram = false;
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    public static void RegisterUser()
    {
        Console.WriteLine("Введите имя и фамилию через пробел и нажмите Enter:");
        var userName = Console.ReadLine();
        var newUser = new User()
        {
            FullName = userName
        };

        var isAdditionSuccessful = UsersService.Add(newUser);

        if (isAdditionSuccessful)
        {
            Console.WriteLine($"Пользователь '{newUser.FullName}' успешно добавлен {newUser.JoinDate}\n");
        }
        else
        {
            Console.WriteLine($"Произошла ошибка, произведен выход на главную страницу\n");
        }
    }

    public static void LoginUser()
    {
        Console.WriteLine("Введите имя и фамилию через пробел и нажмите Enter:");
        var userName = Console.ReadLine();
        var user = UsersService.Get(userName);

        if (user.FullName != null)
        {
            Console.WriteLine($"Пользователь '{user.FullName}' успешно вошел {DateTime.Now}\n");
        }
        else
        {
            Console.WriteLine($"Пользователь не найден, произведен выход на главную страницу\n");
        }
    }
}