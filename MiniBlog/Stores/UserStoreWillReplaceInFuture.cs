using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Server;
using MiniBlog.Model;

namespace MiniBlog.Stores
{
    public interface IUserStore
    {
        public List<User> Users { get; } 
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