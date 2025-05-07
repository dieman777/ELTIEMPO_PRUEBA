using APP_ELTIEMPO_PRUEBA.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;//Se intala este paquete
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace APP_ELTIEMPO_PRUEBA.Controllers
{
    public class LoginController : Controller
    {
        private readonly string apiUrl = "https://localhost:44380";//

        [HttpGet]
        public ActionResult Index()
        { 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(LoginViewModel  loginModel)
        {
            using (var cliente = new HttpClient())
            {
                var datos = new List<KeyValuePair<string, string>> { 
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", loginModel.usuario),
                    new KeyValuePair<string, string>("password", loginModel.contrasena)
                };

                var contenedor = new FormUrlEncodedContent(datos);
                var respuesta = await cliente.PostAsync($"{apiUrl}/token", contenedor);

                if (respuesta.IsSuccessStatusCode)
                {
                    var result = await respuesta.Content.ReadAsAsync<TokenResponse>();
                    //Decodifico el token para obtener el id del usuario
                    /*var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(result.AccessToken) as JwtSecurityToken;
                    var usuarioId = jsonToken?.Claims.FirstOrDefault(c => c.Type == "usuario_id")?.Value;
                    Session["usuario_id"] = usuarioId;*/

                    Session["access_token"] = result.AccessToken;
                    
                    return RedirectToAction("Registro", "OfertaEmpleo");
                }
                else
                {
                    ModelState.AddModelError("", "Usuario o contraseña incorrectos");
                    return View(loginModel);
                }
            }
        }

        public class TokenResponse
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }

            [JsonProperty("token_type")]
            public string TokenType { get; set; }

            [JsonProperty("expires_in")]
            public int ExpiresIn { get; set; }
        }
    }
}