public class CoursesServiceTests
{
    private readonly CoursesService _coursesService = new();

    [Fact]
    public void Get_ShouldReturnListOfCourses_WhenUserExists()
    {
        // Arrange
        var expectedCourses = new List<Course>
        {
            new Course { Id = 3, Title = "PHP для начинающих", Summary = "Курс по созданию динамических сайтов", Photo = "https://example.com/course6.jpg" },
            new Course { Id = 2, Title = "Введение в HTML и CSS", Summary = "Курс по верстке сайтов", Photo = "https://example.com/course5.jpg" },
            new Course { Id = 1, Title = "JavaScript для начинающих", Summary = "Курс для начинающих веб-разработчиков", Photo = "https://example.com/course4.jpg" }
        };

        // Act
        var resultCourses = _coursesService.Get("Петр Васильев");

        // Assert
        for (int i = 0; i < expectedCourses.Count; i++)
        {
            Assert.Equal(expectedCourses[i].Id, resultCourses[i].Id);
            Assert.Equal(expectedCourses[i].Title, resultCourses[i].Title);
            Assert.Equal(expectedCourses[i].Summary, resultCourses[i].Summary);
            Assert.Equal(expectedCourses[i].Photo, resultCourses[i].Photo);
        }
    }

    [Fact]
    public void Get_ShouldReturnEmptyList_WhenUserDoesNotExist()
    {
        // Arrange
        var expectedCourses = new List<Course>();

        // Act
        var resultCourses = _coursesService.Get("Несуществующий Пользователь");

        // Assert
        Assert.Equal(expectedCourses.Count, resultCourses.Count);
    }

    [Fact]
    public void GetTotalCount_ShouldReturnCorrectCount()
    {
        // Arrange
        var expectedTotalCount = 32;

        // Act
        var resultTotalCount = _coursesService.GetTotalCount();

        // Assert
        Assert.Equal(expectedTotalCount, resultTotalCount);
    }
}