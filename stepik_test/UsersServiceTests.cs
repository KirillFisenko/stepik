using stepik.Services;
using System.Data;

public class UsersServiceTests
{
    private readonly IUsersService _usersService = new stepik.Services.ADO.NET.UsersService();

    [Fact]
    public void Add_ShouldReturnTrue_WhenUserIsAdded()
    {
        // Arrange
        var randomName = Guid.NewGuid().ToString();
        var newUser = new User
        {
            full_name = randomName,
            details = "Описание нового пользователя",
            join_date = DateTime.Now,
            avatar = "https://example.com/new_avatar.jpg",
            is_active = true,
            knowledge = 0,
            reputation = 0,
            followers_count = 0
        };

        // Act
        var result = _usersService.Add(newUser);

        // Assert
        Assert.True(result);
        var addedUser = _usersService.Get(randomName);
        Assert.NotNull(addedUser);
        Assert.Equal(newUser.full_name, addedUser.full_name);
        Assert.Equal(newUser.details, addedUser.details);
        Assert.Equal(newUser.join_date.Date, addedUser.join_date.Date);
        Assert.Equal(newUser.avatar, addedUser.avatar);
        Assert.Equal(newUser.is_active, addedUser.is_active);
        Assert.Equal(newUser.knowledge, addedUser.knowledge);
        Assert.Equal(newUser.reputation, addedUser.reputation);
        Assert.Equal(newUser.followers_count, addedUser.followers_count);
    }

    [Fact]
    public void Get_ShouldReturnNull_WhenUserDoesNotExist()
    {
        // Arrange
        var nonExistentUserName = "Несуществующий Пользователь";

        // Act
        var resultUser = _usersService.Get(nonExistentUserName);

        // Assert
        Assert.Null(resultUser);
    }

    [Fact]
    public void FormatUserMetrics_ShouldReturnFormattedNumber()
    {
        // Arrange
        var number = 1500;
        var expectedFormattedNumber = "1.5K";

        // Act
        var resultFormattedNumber = _usersService.FormatUserMetrics(number);

        // Assert
        Assert.Equal(expectedFormattedNumber, resultFormattedNumber);
    }

    [Fact]
    public void GetUserRating_ShouldReturnDataSet_WhenUsersExist()
    {
        // Arrange
        var expectedDataSet = new DataSet();
        var expectedTable = new DataTable();
        expectedTable.Columns.Add("full_name", typeof(string));
        expectedTable.Columns.Add("knowledge", typeof(int));
        expectedTable.Columns.Add("reputation", typeof(int));

        expectedTable.Rows.Add("Александр Александров", 521, 100);
        expectedTable.Rows.Add("Михаил Борисов", 275, 135);
        expectedTable.Rows.Add("Владислав Петров", 275, 135);

        expectedDataSet.Tables.Add(expectedTable);

        // Act
        var resultDataSet = _usersService.GetUserRating();

        // Assert
        for (int i = 0; i < 3; i++)
        {
            var expectedRow = expectedDataSet.Tables[0].Rows[i];
            var resultRow = resultDataSet.Tables[0].Rows[i];

            Assert.Equal(expectedRow["full_name"], resultRow["full_name"]);
            Assert.Equal(expectedRow["knowledge"], resultRow["knowledge"]);
            Assert.Equal(expectedRow["reputation"], resultRow["reputation"]);
        }
    }

    [Fact]
    public void GetUserSocialInfo_ShouldReturnDataSet()
    {
        // Arrange
        var userName = "Петр Васильев";
        var expectedDataSet = new DataSet();
        var expectedTable = new DataTable();
        expectedTable.Columns.Add("name", typeof(string));
        expectedTable.Columns.Add("connect_url", typeof(string));

        expectedTable.Rows.Add("Coursera", "https://www.coursera.org/user/user1");
        expectedTable.Rows.Add("edX", "https://courses.edx.org/u/user1");
        expectedTable.Rows.Add("Facebook", "https://www.facebook.com/user1");
        expectedTable.Rows.Add("GitHub", "https://github.com/user1");
        expectedTable.Rows.Add("Instagram", "https://www.instagram.com/user1");
        expectedTable.Rows.Add("Twitter", "https://twitter.com/user1");
        expectedTable.Rows.Add("VK", "https://vk.com/user1");

        expectedDataSet.Tables.Add(expectedTable);

        // Act
        var resultDataSet = _usersService.GetUserSocialInfo(userName);

        // Assert
        for (int i = 0; i < expectedDataSet.Tables[0].Rows.Count; i++)
        {
            var expectedRow = expectedDataSet.Tables[0].Rows[i];
            var resultRow = resultDataSet.Tables[0].Rows[i];
            Assert.Equal(expectedRow["name"], resultRow["name"]);
            Assert.Equal(expectedRow["connect_url"], resultRow["connect_url"]);
        }
    }
}
