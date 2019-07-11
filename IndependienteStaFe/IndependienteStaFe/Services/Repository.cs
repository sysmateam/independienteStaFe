using IndependienteStaFe.Helpers;
using IndependienteStaFe.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using static IndependienteStaFe.Models.News;

namespace IndependienteStaFe.Services
{
    public class Repository
    {

        MD5HashX2 mdpass = new MD5HashX2();

        /***********************Servicio Perfiles y Membrisia***************************************************/
        public Perfiles getPerfiles()
        {
            try
            {
                Perfiles perfiles;
                var URLWebAPI = "https://crmpuntos.oliviadirect.co/services/feature/profile.php";
                using (var Client = new System.Net.Http.HttpClient())
                {
                    var JSON = Client.GetStringAsync(URLWebAPI);
                    perfiles = Newtonsoft.Json.JsonConvert.DeserializeObject<Perfiles>(JSON.Result);
                }

                return perfiles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Membership getMembresia()
        {
            try
            {
                Membership membresia;
                var URLWebAPI = "https://crmpuntos.oliviadirect.co/services/content/membership.php";
                using (var Client = new System.Net.Http.HttpClient())
                {
                    var JSON = Client.GetStringAsync(URLWebAPI);
                    membresia = Newtonsoft.Json.JsonConvert.DeserializeObject<Membership>(JSON.Result);
                }

                return membresia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

          public async void PostBuymembership(Membership membresia)
        {
            HttpResponseMessage response = null;
            using (var Client = new System.Net.Http.HttpClient())
            {
                try
                {
                    var JSON = Newtonsoft.Json.JsonConvert.SerializeObject(membresia);
                    var content = new StringContent(JSON, System.Text.Encoding.UTF8, "application/json");
                    var URLWebAPI = "https://crmpuntos.oliviadirect.co/services/user/buy-membership.php	";
                    var token = CancellationToken.None;

                    response = await Client.PostAsync(URLWebAPI, content, token);
                    // 405 Method not allow
                    Debug.WriteLine(response.StatusCode);
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        throw new Exception();
                    }

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        /**************************************************************************/
        /***********************************Servicios de Ciudades, Videos, Noticias, TermCons y Poldatos***************************************/
        public Ciudades getCiudades()
        {
            try
            {
                Ciudades ciudades;
                var URLWebAPI = "https://crmpuntos.oliviadirect.co/services/feature/city.php";
                using (var Client = new System.Net.Http.HttpClient())
                {
                    var JSON = Client.GetStringAsync(URLWebAPI);
                    ciudades = Newtonsoft.Json.JsonConvert.DeserializeObject<Ciudades>(JSON.Result);
                }

                return ciudades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
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

        
        public async Task<NewsDetail> getNewsDetail(string newsId)
        {
            object param = new { newsId };
            var jsonObj = JsonConvert.SerializeObject(param);
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://crmpuntos.oliviadirect.co/services/content/detail-news.php"),
                    Method = HttpMethod.Post,
                    Content = content
                };
                //you can add headers                
                //request.Headers.Add("key", "value");
                var response = await client.SendAsync(request).ConfigureAwait(false);
                string dataResult = response.Content.ReadAsStringAsync().Result;
                NewsDetail result = JsonConvert.DeserializeObject<NewsDetail>(dataResult);
                return result;
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
        /**************************************************************************/
        /*********************************Usuario, Post Usuario, Update Usuario, Recuperar Pw, Login*****************************************/


        public async Task<Login> ConnectUser(string id, string password)
        {
            object userInfos = new { id = id, password = mdpass.MD5Hash(password)  };
            var jsonObj = JsonConvert.SerializeObject(userInfos);
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://crmpuntos.oliviadirect.co/services/user/login.php"),
                    Method = HttpMethod.Post,
                    Content = content
                };
                //you can add headers                
                //request.Headers.Add("key", "value");
                var response = await client.SendAsync(request).ConfigureAwait(false);
                string dataResult = response.Content.ReadAsStringAsync().Result;
                Login result = JsonConvert.DeserializeObject<Login>(dataResult);
                return result;
            }
        }

        public async Task<rememberPassword> PostRecuperarPw(string id, string email)
        {
            object userInfos = new { id = id,email=email};
            var jsonObj = JsonConvert.SerializeObject(userInfos);
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://crmpuntos.oliviadirect.co/services/user/remember-password.php"),
                    Method = HttpMethod.Post,
                    Content = content
                };
                //you can add headers                
                //request.Headers.Add("key", "value");
                var response = await client.SendAsync(request).ConfigureAwait(false);
                string dataResult = response.Content.ReadAsStringAsync().Result;
                rememberPassword result = JsonConvert.DeserializeObject<rememberPassword>(dataResult);
                return result;
            }
        }

        public async Task<userInfo> postUserInfo(string token)
        {
            object param = new { token };
            var jsonObj = JsonConvert.SerializeObject(param);
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://crmpuntos.oliviadirect.co/services/user/info.php"),
                    Method = HttpMethod.Post,
                    Content = content
                };
                //you can add headers                
                //request.Headers.Add("key", "value");
                var response = await client.SendAsync(request).ConfigureAwait(false);
                string dataResult = response.Content.ReadAsStringAsync().Result;
                userInfo result = JsonConvert.DeserializeObject<userInfo>(dataResult);
                
                return result;
            }
        }
        public async Task<userPuntos> getGetUserPoints(string token)
        {
            object userInfos = new { token };
            var jsonObj = JsonConvert.SerializeObject(userInfos);
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://crmpuntos.oliviadirect.co/services/user/points.php"),
                    Method = HttpMethod.Post,
                    Content = content
                };
                //you can add headers                
                //request.Headers.Add("key", "value");
                var response = await client.SendAsync(request).ConfigureAwait(false);
                string dataResult = response.Content.ReadAsStringAsync().Result;
                userPuntos result = JsonConvert.DeserializeObject<userPuntos>(dataResult);
                return result;
            }
        }

        public async Task<userCreate> postUserCreate(User user)
        {
            object userInfos = new { user };
            var jsonObj = JsonConvert.SerializeObject(userInfos);
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://crmpuntos.oliviadirect.co/services/user/create.php"),
                    Method = HttpMethod.Post,
                    Content = content
                };
                //you can add headers                
                //request.Headers.Add("key", "value");
                var response = await client.SendAsync(request).ConfigureAwait(false);
                string dataResult = response.Content.ReadAsStringAsync().Result;
                userCreate result = JsonConvert.DeserializeObject<userCreate>(dataResult);
                return result;
            }
        }


        public async Task<userCreate> PostUpdateUser(UserUpdate user)
        {
            object userInfos = new { user };
            var jsonObj = JsonConvert.SerializeObject(userInfos);
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://crmpuntos.oliviadirect.co/services/user/update.php"),
                    Method = HttpMethod.Post,
                    Content = content
                };
                //you can add headers                
                //request.Headers.Add("key", "value");
                var response = await client.SendAsync(request).ConfigureAwait(false);
                string dataResult = response.Content.ReadAsStringAsync().Result;
                userCreate result = JsonConvert.DeserializeObject<userCreate>(dataResult);
                return result;
            }
        }

        public async Task<userLogOut> LogOut(string token)
        {
            object userInfos = new { token };
            var jsonObj = JsonConvert.SerializeObject(userInfos);
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://crmpuntos.oliviadirect.co/services/user/logout.php"),
                    Method = HttpMethod.Post,
                    Content = content
                };
                //you can add headers                
                //request.Headers.Add("key", "value");
                var response = await client.SendAsync(request).ConfigureAwait(false);
                string dataResult = response.Content.ReadAsStringAsync().Result;
                userLogOut result = JsonConvert.DeserializeObject<userLogOut>(dataResult);
                return result;
            }
        }


        /**************************************************************************/
        /*******************************Productos, Registro Pago, Redenciones*******************************************/
        public async Task<Product> getProductos (string token)
        {
            object param = new { token };
            var jsonObj = JsonConvert.SerializeObject(param);
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://crmpuntos.oliviadirect.co/services/product/list.php"),
                    Method = HttpMethod.Post,
                    Content = content
                };
                //you can add headers                
                //request.Headers.Add("key", "value");
                var response = await client.SendAsync(request).ConfigureAwait(false);
                string dataResult = response.Content.ReadAsStringAsync().Result;
                Product result = JsonConvert.DeserializeObject<Product>(dataResult);
                return result;
            }
        }

        public async Task<ProductInfo>  getProductosInfo(string token, string productId)
        {
            object param = new { token, productId };
            var jsonObj = JsonConvert.SerializeObject(param);
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://crmpuntos.oliviadirect.co/services/product/info.php"),
                    Method = HttpMethod.Post,
                    Content = content
                };
                //you can add headers                
                //request.Headers.Add("key", "value");
                var response = await client.SendAsync(request).ConfigureAwait(false);
                string dataResult = response.Content.ReadAsStringAsync().Result;
                ProductInfo result = JsonConvert.DeserializeObject<ProductInfo>(dataResult);
                return result;
            }
        }

        public async Task<ProductStock>  getProductosStock(string productId)
        {
            object param = new {productId };
            var jsonObj = JsonConvert.SerializeObject(param);
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://crmpuntos.oliviadirect.co/services/product/stock-product.php"),
                    Method = HttpMethod.Post,
                    Content = content
                };
                //you can add headers                
                //request.Headers.Add("key", "value");
                var response = await client.SendAsync(request).ConfigureAwait(false);
                string dataResult = response.Content.ReadAsStringAsync().Result;
                ProductStock result = JsonConvert.DeserializeObject<ProductStock>(dataResult);
                return result;
            }
        }
        public async Task<Redencion> getRedencion(string token,string productId, string attribute, string quantity)
        {
            object param = new { token, productId, attribute, quantity };
            var jsonObj = JsonConvert.SerializeObject(param);
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://crmpuntos.oliviadirect.co/services/product/redemption.php"),
                    Method = HttpMethod.Post,
                    Content = content
                };
                //you can add headers                
                //request.Headers.Add("key", "value");
                var response = await client.SendAsync(request).ConfigureAwait(false);
                string dataResult = response.Content.ReadAsStringAsync().Result;
                Redencion result = JsonConvert.DeserializeObject<Redencion>(dataResult);
                return result;
            }
        }

        public async Task<RegisterPay> getRegisterPay(string token, string productId, string attribute, string quantity, string dateHourPayment, string statusPayment)
        {
            object param = new { token, productId, attribute, quantity, dateHourPayment, statusPayment };
            var jsonObj = JsonConvert.SerializeObject(param);
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://crmpuntos.oliviadirect.co/services/product/register-pay.php"),
                    Method = HttpMethod.Post,
                    Content = content
                };
                //you can add headers                
                //request.Headers.Add("key", "value");
                var response = await client.SendAsync(request).ConfigureAwait(false);
                string dataResult = response.Content.ReadAsStringAsync().Result;
                RegisterPay result = JsonConvert.DeserializeObject<RegisterPay>(dataResult);
                return result;
            }
        }

      
        /**************************************************************************/


    }
}
