using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components.Server;
using MiniBlog.Model;

namespace MiniBlog.Stores
{
    public interface IUserStore
    {
        public List<User> Users { get; }
        public User FindUserByName(string name);
    }

    public class UserStore : IUserStore
    {
        public List<User> Users
        {
            get
            {
                return UserStoreWillReplaceInFuture.Users;
            }
        }

        public User FindUserByName(string name) => Users.FirstOrDefault(user => user.Name.ToLower() == name.ToLower());
    }

    public class UserStoreWillReplaceInFuture
    {
        static UserStoreWillReplaceInFuture()
        {
            Users = new List<User>();
        }

        public static List<User> Users { get; private set; }

        /// <summary>
        /// This is for test only, please help resolve!
        /// </summary>
        public static void Init()
        {
            Users = new List<User>();
        }
    }
}