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
        private readonly IArticleStore articleStore;
        public UserService(IUserStore userStore, IArticleStore articleStore)
        {
            this.userStore = userStore;
            this.articleStore = articleStore;
        }

        public User FindUserName(User user)
        {
            return userStore.Users.FirstOrDefault(_ => _.Name == user.Name);
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
            var foundUser = FindUserName(user);
            if (foundUser != null)
            {
                foundUser.Email = user.Email;
            }

            return foundUser;
        }

        public void UserRemove(User user)
        {
            userStore.Users.Remove(user);
        }

        public User UserGetByName(string name)
        {
            return userStore.Users.FirstOrDefault(_ => _.Name.ToLower() == name.ToLower());
        }

        public User DeleteUserAndAticles(string name)
        {
            var foundUser = UserGetByName(name);
            if (foundUser != null)
            {
                userStore.Users.Remove(foundUser);
                articleStore.Articles.RemoveAll(a => a.UserName == name);
            }

            return foundUser;
        }
    }
}
