using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Services
{
    public class ArticleService
    {
        private readonly IArticleStore articleStore;

        public ArticleService(IArticleStore articleStore)
        {
            this.articleStore = articleStore;
        }

        public void RemoveAllArticlesOfUser(User user)
        {
            articleStore.Articles.RemoveAll(a => a.UserName == user.Name);
        }

        public List<Article> GetAllArticles()
        {
            return articleStore.Articles;
        }

        public Article FindArticleById(Guid id)
        {
            return articleStore.Articles.FirstOrDefault(article => article.Id == id);
        }

        public void AddArticle(Article article)
        {
            articleStore.Articles.Add(article);
        }
    }
}
