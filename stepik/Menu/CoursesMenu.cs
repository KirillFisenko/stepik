using System.Data;

public record class CoursesMenu(User _user, WrongChoice _wrongChoice)
{
    private readonly CoursesService _coursesService = new();

    public void Display()
    {
        List<Course> courses = _coursesService.Get(_user.FullName);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n* Список курсов " + _user.FullName + " *\n\n" +
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
    }

    public void HandleUserChoice()
    {
        while (true)
        {
            List<Course> courses = _coursesService.Get(_user.FullName);
            var coursesIds = courses.Select(x => x.Id.ToString()).ToList();
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "0":
                    var userMenu = new UserMenu(_user, _wrongChoice);
                    userMenu.Display();
                    userMenu.HandleUserChoice();
                    return;
                default:
                    if (coursesIds.Contains(choice!))
                    {
                        var coursesId = Convert.ToInt32(choice);
                        HandleUserCommentsMenu(coursesId);
                    }
                    else
                    {
                        _wrongChoice.PrintWrongChoiceMessage();
                    }
                    break;
            }
        }
    }

    private void HandleUserCommentsMenu(int coursesId)
    {
        var commentsMenu = new CommentsMenu(coursesId, _user, _wrongChoice);
        commentsMenu.Display();
        commentsMenu.HandleUserChoice();
    }
}
