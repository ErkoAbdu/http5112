using BlogProject.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogProject.Controllers
{
    public class ArticleDataController : ApiController
    {
        //An instance of the blog database context to work with
        private BlogDbContext Blog = new BlogDbContext();
        [HttpGet]
        [Route("api/ArticleData/ListArticles")]
        public List<string> ListArticles()
        {
            //connect to the blog database
            MySqlConnection conn = Blog.AccessDatabase();

            //open a connection to the database
            conn.Open();

            //set up a string query "select * from articles"
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM articles";

            //execute the sql command
            MySqlDataReader Results = cmd.ExecuteReader();

            //loop through the result set
            List<string> Articles = new List<string>();
            while (Results.Read())
            {
                string Article = Results["articletitle"].ToString();
                Articles.Add(Article);
            }

            //add it to a list of artricles


            //return the list of articles
            conn.Close();
            return Articles;
        }
    }
}
