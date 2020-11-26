using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using MiniBlog.Model;
using MiniBlog.Services;
using MiniBlog.Stores;

namespace MiniBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;
        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Register(User user)
        {
            userService.UserRegister(user);

            return CreatedAtAction(nameof(GetByName), new { name = user.Name }, user);
        }

        [HttpGet]
        public List<User> GetAll()
        {
            return userService.UserGetAll();
        }

        [HttpPut]
        public User Update(User user)
        {
            return userService.UserUpdate(user);
        }

        [HttpDelete]
        public User Delete(string name)
        {
            return userService.DeleteUserAndAticles(name);
        }

        [HttpGet("{name}")]
        public User GetByName(string name)
        {
            return userService.UserGetByName(name);
        }
    }
}