﻿using System;
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

        private const string _andIsConfirmed = " and isconfirmed=1";

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

        public static Article GetArticleById(int id)
        {
            var article = new Article();
            using (var connection = new MySqlConnection(ConnectionString))
            {
                var sql = "select * from article where id = @id";
                article = connection.Query<Article>(sql, new { id }).FirstOrDefault();
            }
            return article;
        }

        public static User Login(string username, string password)
        {
            var user = new User();
            using (var connection = new MySqlConnection(ConnectionString))
            {
                var sql = "select * from user where username = @username and password = @password " + _andIsConfirmed;
                user = connection.Query<User>(sql, new { username, password }).FirstOrDefault();
            }

            return user;
        }

        public static User GetUserById(int id)
        {
            var user = new User();
            using (var connection = new MySqlConnection(ConnectionString))
            {
                var sql = "select * from user where id = @id " + _andIsConfirmed;
                user = connection.Query<User>(sql, new { id }).FirstOrDefault();
            }
            return user;
        }

        public static User GetUserByIdNotConfirmed(int id)
        {
            var user = new User();
            using (var connection = new MySqlConnection(ConnectionString))
            {
                var sql = "select * from user where id = @id and isConfirmed=0";
                user = connection.Query<User>(sql, new { id }).FirstOrDefault();
            }
            return user;
        }

        public static User GetUserByEmail(string email)
        {
            var user = new User();
            using (var connection = new MySqlConnection(ConnectionString))
            {
                var sql = "select * from user where email = @email " + _andIsConfirmed;
                user = connection.Query<User>(sql, new { email }).FirstOrDefault();
            }
            return user;
        }

        public static User GetUserByUsername(string username)
        {
            var user = new User();
            using (var connection = new MySqlConnection(ConnectionString))
            {
                var sql = "select * from user where username = @username " + _andIsConfirmed;
                user = connection.Query<User>(sql, new { username }).FirstOrDefault();
            }
            return user;
        }

        public static User Save(User user)
        {
            if (user.Id == 0)
                return Insert(user);
            return Update(user);
        }

        private static User Update(User user)
        {
            try
            {
                user.LastModifiedDate = DateTime.Now;
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    var sql = "UPDATE user SET Username=@Username, Password=@Password," +
                                "Name=@Name, Email=@Email, IsConfirmed=@IsConfirmed," +
                                "LastModifiedDate=@LastModifiedDate " +
                                "WHERE Id=@Id; ";

                    int updatedRows = connection.Execute(sql, user);
                    if (updatedRows != 1) //deve essere aggiornata una sola riga, altrimenti errore
                        return null;
                }
            }
            catch (Exception ex)
            {
                //errore
                return null;
            }
            return user;

        }

        private static User Insert(User user)
        {
            try
            {
                user.RegistrationDate = DateTime.Now;
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    var sql = "INSERT INTO user (username,name,password,email,registrationdate) " +
                        " VALUES (@username,@name,@password,@email,@registrationdate); " +
                        " SELECT CAST(LAST_INSERT_ID() as int)";

                    user.Id = connection.Query<int>(sql, user).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                //errore
                return null;
            }
            return user;
        }
    }
}