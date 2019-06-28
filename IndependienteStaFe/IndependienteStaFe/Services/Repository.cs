using IndependienteStaFe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using static IndependienteStaFe.Models.News;

namespace IndependienteStaFe.Services
{
    public class Repository
    {
        public Videos getVideos()
        {
            try
            {
                Videos videos;
                var URLWebAPI = "https://crmpuntos.oliviadirect.co/services/content/list-video.php";
                using (var Client = new System.Net.Http.HttpClient())
                {
                    var JSON = Client.GetStringAsync(URLWebAPI);
                    videos = Newtonsoft.Json.JsonConvert.DeserializeObject<Videos>(JSON.Result);
                }

                return videos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public News getNews()
        {
            try
            {
                News news;
                var URLWebAPI = "https://crmpuntos.oliviadirect.co/services/content/list-news.php";
                    using (var Client = new System.Net.Http.HttpClient())
                    {
                        var JSON =  Client.GetStringAsync(URLWebAPI);
                            news = Newtonsoft.Json.JsonConvert.DeserializeObject<News>(JSON.Result);
                    }

                return news;
                }
                catch (Exception ex)
            {
                throw ex;
            }
        }

        public TermConds getTermConds()
        {
            try
            {
                TermConds termconds;
                var URLWebAPI = "https://crmpuntos.oliviadirect.co/services/content/terms-and-conditions.php";
                using (var Client = new System.Net.Http.HttpClient())
                {
                    var JSON = Client.GetStringAsync(URLWebAPI);
                    termconds = Newtonsoft.Json.JsonConvert.DeserializeObject<TermConds>(JSON.Result);
                }

                return termconds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Poldatos getPolDatos()
        {
            try
            {
                Poldatos poldatos;
                var URLWebAPI = "https://crmpuntos.oliviadirect.co/services/content/data-policy.php";
                using (var Client = new System.Net.Http.HttpClient())
                {
                    var JSON = Client.GetStringAsync(URLWebAPI);
                    poldatos = Newtonsoft.Json.JsonConvert.DeserializeObject<Poldatos>(JSON.Result);
                }

                return poldatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string getLogin(string usu, string pass)
        {
            try
            {
                String login;
                var URLWebAPI = "https://crmpuntos.oliviadirect.co/services/user/login.php?id=" + usu + "&Password =" + pass;
                using (var Client = new System.Net.Http.HttpClient())
                {
                    var JSON = Client.GetStringAsync(URLWebAPI);
                    login = JSON.Result;
                }

                return login;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
