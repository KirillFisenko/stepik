using Microsoft.AspNetCore.Mvc;
using stepik.Services;

[ApiController]
[Route("[controller]")]
public class CoursesController(ICoursesService _coursesService) : ControllerBase
{
    [HttpGet("GetUserCourses")]
    public IActionResult GetUserCourses(string fullName)
    {
        var courses = _coursesService.Get(fullName);
        return (courses != null && courses.Any()) ? Ok(courses) : NotFound("У пользователя не найдено курсов");
    }

    [HttpGet("GetTotalCoursesCount")]
    public IActionResult GetTotalCoursesCount()
    {
        var totalCount = _coursesService.GetTotalCount();
        return Ok(totalCount);
    }
}
