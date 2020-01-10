using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WebApplication.Models.Entities;
using MySql.Data.MySqlClient;
using Dapper;

namespace WebApplication.Helpers
{
    public class DatabaseHelper
    {
        private static string ConnectionString =
            ConfigurationManager.ConnectionStrings["Database"].ConnectionString; //personalizzare la set per gestire l'eccezione

        public static List<Article> GetAllArticles()
        {
            var articles = new List<Article>();
            using (var connection = new MySqlConnection(ConnectionString))
            {
                var sql = "select * from article";
                articles = connection.Query<Article>(sql).ToList();
            }
            return articles;
        }

        public static Article GetArticleByid(int id)
        {
            var article = new Article();
            using (var connection = new MySqlConnection(ConnectionString))
            {
                var sql = "select * from article where id = @id";
                article = connection.Query<Article>(sql, new { id }).FirstOrDefault();
            }
            return article;
        }


    }
}