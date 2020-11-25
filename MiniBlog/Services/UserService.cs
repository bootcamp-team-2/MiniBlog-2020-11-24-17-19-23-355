using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniBlog.Model;
using MiniBlog.Services;
using MiniBlog.Stores;

namespace MiniBlog
{
    public class UserService
    {
        private readonly IUserStore userStore;
        public UserService(IUserStore userStore)
        {
            this.userStore = userStore;
        }

        public User FindUserByName(string name)
        {
            return userStore.Users.FirstOrDefault(_ => _.Name.ToLower() == name.ToLower());
        }

        public void RegisterUser(string name, string email = "anonymous@unknow.com")
        {
            if (FindUserByName(name) == null)
            {
                userStore.Users.Add(new User(name, email));
            }
        }

        public List<User> GetAllUsers()
        {
            return userStore.Users;
        }

        public User UpdateUser(User user)
        {
            var foundUser = FindUserByName(user.Name);
            if (foundUser != null)
            {
                foundUser.Email = user.Email;
            }

            return foundUser;
        }

        public void RemoveUser(User user)
        {
            userStore.Users.Remove(user);
        }
    }
}