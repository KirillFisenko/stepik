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

1. Зарегистрироваться
2. Закрыть приложение

************************************************
");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RegisterUser();
                    break;
                case "2":
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

        var result = UsersService.Add(newUser);

        if (result == 1)
        {
            Console.WriteLine($"Пользователь '{newUser.FullName}' успешно добавлен {newUser.JoinDate}\n");
        }
        else
        {
            Console.WriteLine($"Произошла ошибка, произведен выход на главную страницу\n");
        }
    }
}