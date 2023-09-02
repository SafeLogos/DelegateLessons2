using DelegateLessons2.Models;
using DelegateLessons2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DelegateLessons2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public IActionResult Index() => Ok("asasdasd");

        [HttpGet("[action]")]
        public IActionResult GetUsers() => Ok(_usersService.GetUsers());
        [HttpGet("[action]")]
        public IActionResult GetUsers2()
        {
            UserModel user = new UserModel("Аня", 30);
            Test(user);
            return Ok(user);
            //throw new Exception("Ошибка");
        }


        public void Test(UserModel model)
        {
            model.Name = "sdfsdfsdf";
            model = new UserModel("Test", 50);
        }

    }
}
