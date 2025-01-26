using System.Data;

public class UsersServiceTests
{
    private readonly UsersService _usersService = new();

    [Fact]
    public void Add_ShouldReturnTrue_WhenUserIsAdded()
    {
        // Arrange
        var newUser = new User
        {
            FullName = "Add_ShouldReturnTrue_WhenUserIsAdded",
            Details = "Описание нового пользователя",
            JoinDate = DateTime.Now,
            Avatar = "https://example.com/new_avatar.jpg",
            IsActive = true,
            Knowledge = 0,
            Reputation = 0,
            FollowersCount = 0
        };

        // Act
        var result = _usersService.Add(newUser);

        // Assert
        Assert.True(result);
        var addedUser = _usersService.Get("Add_ShouldReturnTrue_WhenUserIsAdded");
        Assert.NotNull(addedUser);
        Assert.Equal(newUser.FullName, addedUser.FullName);
        Assert.Equal(newUser.Details, addedUser.Details);
        Assert.Equal(newUser.JoinDate.Date, addedUser.JoinDate);
        Assert.Equal(newUser.Avatar, addedUser.Avatar);
        Assert.Equal(newUser.IsActive, addedUser.IsActive);
        Assert.Equal(newUser.Knowledge, addedUser.Knowledge);
        Assert.Equal(newUser.Reputation, addedUser.Reputation);
        Assert.Equal(newUser.FollowersCount, addedUser.FollowersCount);
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
}