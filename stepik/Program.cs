using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main()
    {
        using var dbContext = new ApplicationDbContext();
        dbContext.Database.Migrate();
        var menu = new MainMenu();
        menu.Display();
        menu.HandleUserChoice();
    }
}
