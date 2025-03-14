using Microsoft.AspNetCore.Mvc;
using stepik.Services;

[ApiController]
[Route("[controller]")]
public class CommentsController(ICommentsService _commentsService) : ControllerBase
{
    [HttpGet("GetCourseComments")]
    public IActionResult GetCourseComments(int id)
    {
        var comments = _commentsService.Get(id);
        return (comments != null && comments.Any()) ? Ok(comments) : NotFound("Комментариев не найдено");
    }

    [HttpDelete("DeleteComment")]
    public IActionResult DeleteComment(int id)
    {
        var result = _commentsService.Delete(id);
        return result ? Ok("Комментарий удален") : BadRequest("Не удалось удалить комментарий.");
    }
}
