using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Server.IIS.Core;
using MiniBlog.Model;

namespace MiniBlog.Stores
{
    public interface IArticleStore
    {
        List<Article> Articles { get; }
    }

    public class TestArticleStore : IArticleStore
    {
        public List<Article> Articles 
        {
            get
            {
                throw new Exception();
            }
        }
    }

    public class ArticleStore : IArticleStore
    {
        public List<Article> Articles => ArticleStoreWillReplaceInFuture.Articles;
    }

    public class ArticleStoreWillReplaceInFuture
    {
        static ArticleStoreWillReplaceInFuture()
        {
            Init();
        }

        public static List<Article> Articles { get; private set; }

        /// <summary>
        /// This is for test only, please help resolve!
        /// </summary>
        public static void Init()
        {
            Articles = new List<Article>();
            Articles.Add(new Article(null, "Happy new year", "Happy 2021 new year"));
            Articles.Add(new Article(null, "Happy Halloween", "Halloween is coming"));
        }
    }
}