using System.Data;

public record class CommentsMenu(int _courseId, User _user, WrongChoice _wrongChoice)
{
    private readonly CoursesService _coursesService = new();
    private readonly CommentsService _commentsService = new();

    public void Display()
    {
        List<Comment> comments = _commentsService.Get(_courseId);
        List<Course> courses = _coursesService.Get(_user.FullName);
        var currentCourse = courses.FirstOrDefault(x => x.Id == _courseId);
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
    }

    public void HandleUserChoice()
    {
        while (true)
        {
            List<Comment> comments = _commentsService.Get(_courseId);
            var commentsIds = comments.Select(x => x.Id.ToString()).ToList();
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "0":
                    var coursesMenu = new CoursesMenu(_user, _wrongChoice);
                    coursesMenu.Display();
                    coursesMenu.HandleUserChoice();
                    return;
                default:
                    if (commentsIds.Contains(choice!))
                    {
                        var commentId = Convert.ToInt32(choice);
                        var isCommentDeleted = _commentsService.Delete(commentId);
                        if (isCommentDeleted)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Комментарий успешно удален");
                            Console.ResetColor();
                            Display();
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
                        _wrongChoice.PrintWrongChoiceMessage();
                    }
                    break;
            }
        }
    }
}
