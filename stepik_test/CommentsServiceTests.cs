using stepik.Services;

public class CommentsServiceTests
{
    private readonly ICommentsService _commentsService = ServiceProvider.commentsService;

    [Fact]
    public void Get_ShouldReturnListOfComments_WhenCourseIdExists()
    {
        // Arrange
        var expectedComments = new List<Comment>
        {
            new Comment { Id = 8, Text = "Could use more examples.", Time = new DateTime(2023, 10, 8) },
            new Comment { Id = 6, Text = "Excellent content!", Time = new DateTime(2023, 10, 6) },
            new Comment { Id = 4, Text = "This step is a bit confusing.", Time = new DateTime(2023, 10, 4) },
            new Comment { Id = 2, Text = "I agree, very helpful.", Time = new DateTime(2023, 10, 2) }
        };

        // Act
        var resultComments = _commentsService.Get(1);

        // Assert
        for (int i = 0; i < expectedComments.Count; i++)
        {
            Assert.Equal(expectedComments[i].Id, resultComments[i].Id);
            Assert.Equal(expectedComments[i].Text, resultComments[i].Text);
            Assert.Equal(expectedComments[i].Time, resultComments[i].Time);
        }
    }

    [Fact]
    public void Get_ShouldReturnEmptyList_WhenCourseIdDoesNotExist()
    {
        // Arrange
        var expectedComments = new List<Comment>();

        // Act
        var resultComments = _commentsService.Get(0);

        // Assert
        Assert.Equal(expectedComments.Count, resultComments.Count);
    }

    [Fact]
    public void Delete_ShouldReturnTrue_WhenCommentExists()
    {
        // Arrange
        int commentIdToDelete = 1;

        // Act
        var result = _commentsService.Delete(commentIdToDelete);

        // Assert
        Assert.True(result);

        var commentsAfterDeletion = _commentsService.Get(1);
        Assert.DoesNotContain(commentsAfterDeletion, c => c.Id == commentIdToDelete);
    }
}