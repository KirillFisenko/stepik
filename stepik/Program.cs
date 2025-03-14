using stepik.Services;

public class Program
{
    public static void Main()
    {
        ServiceProvider serviceProvider = new();
        var menu = new MainMenu(serviceProvider);
        menu.Display();
        menu.HandleUserChoice();
    }
}
