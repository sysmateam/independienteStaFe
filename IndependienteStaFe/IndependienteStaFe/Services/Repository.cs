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
        public async  Task<Login> getLogin(string pid, string pass)
        {
            
            try
            {

                var param = JsonConvert.SerializeObject(new
                {
                    id = pid,
                    password = mdpass.MD5Hash(pass)

                });
                Task<Login> login;
                var URLWebAPI = "https://crmpuntos.oliviadirect.co/services/user/login.php?";
                using (var Client = new System.Net.Http.HttpClient())
                {
                    //+HttpUtility.UrlEncode(request)
                    HttpContent content = new StringContent(param, Encoding.UTF8, "application/json");

                    var resp = await Client.PostAsync(URLWebAPI, content);
                    if (resp.IsSuccessStatusCode)
                    {
                         login = JsonConvert.DeserializeObject<Task<Login>>(resp.Content.ReadAsStringAsync().Result);
                        return await login;
                    }
                  //  login = Newtonsoft.Json.JsonConvert.DeserializeObject<Login>(JSON.Result);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User getGetUser()
        {
            try
            {
                User usuario;
                var URLWebAPI = "https://crmpuntos.oliviadirect.co/services/user/info.php";
                using (var Client = new System.Net.Http.HttpClient())
                {
                    var JSON = Client.GetStringAsync(URLWebAPI);
                    usuario = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(JSON.Result);
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void PostUser(User usuario)
        {
            HttpResponseMessage response = null;
            using (var Client = new System.Net.Http.HttpClient())
            {
                try
                {
                    var JSON = Newtonsoft.Json.JsonConvert.SerializeObject(usuario);
                    var content = new StringContent(JSON, System.Text.Encoding.UTF8, "application/json");
                    var URLWebAPI = "https://crmpuntos.oliviadirect.co/services/user/create.php";
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

        public async void PostRecuperarPw(string id, string email)
        {
            HttpResponseMessage response = null;
            using (var Client = new System.Net.Http.HttpClient())
            {
                try
                {
                    User usuario = new User();
                    var JSON = Newtonsoft.Json.JsonConvert.SerializeObject(usuario);
                    var content = new StringContent(JSON, System.Text.Encoding.UTF8, "application/json");
                    var URLWebAPI = "https://crmpuntos.oliviadirect.co/services/user/remember-password.php?id="+id+"&email="+email;
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
        public async void PostUpdateUser(User user)
        {
            HttpResponseMessage response = null;
            using (var Client = new System.Net.Http.HttpClient())
            {
                try
                {

                    var JSON = Newtonsoft.Json.JsonConvert.SerializeObject(user);
                    var content = new StringContent(JSON, System.Text.Encoding.UTF8, "application/json");
                    var URLWebAPI = "https://crmpuntos.oliviadirect.co/services/user/update.php";
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
        /*******************************Productos, Registro Pago, Redenciones*******************************************/
        public Product getProductos()
        {
            try
            {
                Product product;
                var URLWebAPI = "https://crmpuntos.oliviadirect.co/services/product/list.php";
                using (var Client = new System.Net.Http.HttpClient())
                {
                    var JSON = Client.GetStringAsync(URLWebAPI);
                    product = Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(JSON.Result);
                }

                return product;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ProductInfo getProductosInfo()
        {
            try
            {
                ProductInfo product;
                var URLWebAPI = "https://crmpuntos.oliviadirect.co/services/product/info.php";
                using (var Client = new System.Net.Http.HttpClient())
                {
                    var JSON = Client.GetStringAsync(URLWebAPI);
                    product = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductInfo>(JSON.Result);
                }

                return product;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductStock getProductosStock()
        {
            try
            {
                ProductStock product;
                var URLWebAPI = "https://crmpuntos.oliviadirect.co/services/product/stock-product.php";
                using (var Client = new System.Net.Http.HttpClient())
                {
                    var JSON = Client.GetStringAsync(URLWebAPI);
                    product = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductStock>(JSON.Result);
                }

                return product;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Redencion getRedencion()
        {
            try
            {
                Redencion redencion;
                var URLWebAPI = "https://crmpuntos.oliviadirect.co/services/product/redemption.php";
                using (var Client = new System.Net.Http.HttpClient())
                {
                    var JSON = Client.GetStringAsync(URLWebAPI);
                    redencion = Newtonsoft.Json.JsonConvert.DeserializeObject<Redencion>(JSON.Result);
                }

                return redencion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RegisterPay getRegisterPay()
        {
            try
            {
                RegisterPay registerpay;
                var URLWebAPI = "https://crmpuntos.oliviadirect.co/services/product/register-pay.php";
                using (var Client = new System.Net.Http.HttpClient())
                {
                    var JSON = Client.GetStringAsync(URLWebAPI);
                    registerpay = Newtonsoft.Json.JsonConvert.DeserializeObject<RegisterPay>(JSON.Result);
                }

                return registerpay;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /**************************************************************************/


    }
}
