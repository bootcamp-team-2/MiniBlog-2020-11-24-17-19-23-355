using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Services
{
    public class UserService
    {
        private readonly IUserStore userStore;
        public UserService(IUserStore userStore)
        {
            this.userStore = userStore;
        }

        public void UserRegister(User user)
        {
            if (!userStore.Users.Exists(_ => user.Name.ToLower() == _.Name.ToLower()))
            {
                userStore.Users.Add(user);
            }
        }

        public List<User> UserGetAll()
        {
            return userStore.Users;
        }

        public User UserUpdate(User user)
        {
            var foundUser = userStore.Users.FirstOrDefault(_ => _.Name == user.Name);
            if (foundUser != null)
            {
                foundUser.Email = user.Email;
            }

            return foundUser;
        }
    }
}
