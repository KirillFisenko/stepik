public class Program
{
    public static void Main()
    {
        using var dbContext = new ApplicationDbContext();
        var menu = new MainMenu();
        menu.Display();
        menu.HandleUserChoice();
    }
}
