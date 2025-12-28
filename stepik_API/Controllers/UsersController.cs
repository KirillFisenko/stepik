using Microsoft.AspNetCore.Mvc;
using System.Data;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly UsersService _usersService;

    public UsersController(UsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpPost("AddUser")]
    public IActionResult AddUser(User user)
    {
        var result = _usersService.Add(user);
        return result ? Ok("Пользователь добавлен.") : BadRequest("Не удалось добавить пользователя.");
    }

    [HttpGet("GetUser")]
    public IActionResult GetUser(string fullName)
    {
        var user = _usersService.Get(fullName);
        return user != null ? Ok(user) : NotFound("Пользователь не найден.");
    }

    [HttpGet("GetTotalCount")]
    public IActionResult GetTotalCount()
    {
        var totalCount = _usersService.GetTotalCount();
        return Ok(totalCount);
    }

    [HttpGet("FormatUserMetrics")]
    public IActionResult FormatUserMetrics(int number)
    {
        var formattedNumber = _usersService.FormatUserMetrics(number);
        return Ok(formattedNumber);
    }

    [HttpGet("GetUserRating")]
    public IActionResult GetUserRating()
    {
        var dataSet = _usersService.GetUserRating();
        var userRatings = dataSet.Tables[0].Rows.Cast<DataRow>().Select(row => new
        {
            FullName = row["full_name"].ToString(),
            Knowledge = Convert.ToInt32(row["knowledge"]),
            Reputation = Convert.ToInt32(row["reputation"])
        }).ToList();

        return Ok(userRatings);
    }

    [HttpGet("GetUserSocialInfo")]
    public IActionResult GetUserSocialInfo(string userName)
    {
        var dataSet = _usersService.GetUserSocialInfo(userName);
        var socialInfo = dataSet.Tables[0].Rows.Cast<DataRow>().Select(row => new
        {
            ProviderName = row["name"].ToString(),
            ConnectUrl = row["connect_url"].ToString()
        }).ToList();

        return Ok(socialInfo);
    }
}
