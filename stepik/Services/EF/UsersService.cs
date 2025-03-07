public partial class UsersService
{
    /// <summary>
    /// Получение пользователя из таблицы users
    /// </summary>
    /// <param name="fullName">Полное имя пользователя</param>
    /// <returns>User</returns>    
    public User? Get(string fullName)
    {
        using ApplicationDbContext dbContext = new();
        return dbContext.Users
            .FirstOrDefault(u => u.full_name == fullName && u.is_active);
    }
}
