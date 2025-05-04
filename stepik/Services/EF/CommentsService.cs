using Microsoft.EntityFrameworkCore;

namespace stepik.Services.EF;

public class CommentsService : ICommentsService
{
    /// <summary>
    /// Получение всех комментариев к курсу
    /// </summary>
    /// <param name="id">id курса</param>
    /// <returns>Список комментариев</returns>  
    public List<Comment> Get(int id)
    {
        using ApplicationDbContext dbContext = new();

        var comments = dbContext.Comments
            .AsNoTracking()
            .Where(c =>
                c.ReplyCommentId == null &&
                dbContext.UnitLessons
                    .Any(ul => ul.LessonId == c.StepId && ul.Unit.CourseId == id)
            )
            .OrderByDescending(c => c.Time)
            .ToList();

        return comments;
    }

    /// <summary>
    /// Удаление комментария пользователя
    /// </summary>
    /// <param name="id">id комментария</param>
    /// <returns>Удалось ли удалить комментарий</returns>
    public bool Delete(int id)
    {
        try
        {
            using ApplicationDbContext dbContext = new();

            using var transaction = dbContext.Database.BeginTransaction();

            var courseReviews = dbContext.CourseReviews.Where(cr => cr.CommentId == id);
            dbContext.CourseReviews.RemoveRange(courseReviews);

            var replies = dbContext.Comments.Where(c => c.ReplyCommentId == id);
            dbContext.Comments.RemoveRange(replies);

            var comment = dbContext.Comments.FirstOrDefault(c => c.Id == id);
            if (comment != null)
            {
                dbContext.Comments.Remove(comment);
            }

            dbContext.SaveChanges();
            transaction.Commit();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
