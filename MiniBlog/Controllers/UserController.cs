using System.Collections.Generic;
using System.Linq;
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
        private readonly ArticleService articleService;

        public UserController(UserService userService, ArticleService articleService)
        {
            this.userService = userService;
            this.articleService = articleService;
        }

        [HttpPost]
        public ActionResult<User> Register(User user)
        {
            userService.RegisterUser(user.Name, user.Email);

            return CreatedAtAction(nameof(GetByName), new { name = user.Name }, user);
        }

        [HttpGet]
        public List<User> GetAll()
        {
            return userService.GetAllUsers();
        }

        [HttpPut]
        public User Update(User user)
        {
            var updatedUser = userService.UpdateUser(user);
            return updatedUser;
        }

        [HttpDelete]
        public User Delete(string name)
        {
            var foundUser = userService.FindUserByName(name);

            if (foundUser != null)
            {
                userService.RemoveUser(foundUser);
                articleService.RemoveAllArticlesOfUser(foundUser);
            }

            return foundUser;
        }

        [HttpGet("{name}")]
        public User GetByName(string name)
        {
            return userService.FindUserByName(name);
        }
    }
}