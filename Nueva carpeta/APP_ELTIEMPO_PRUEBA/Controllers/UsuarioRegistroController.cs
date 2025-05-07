using APP_ELTIEMPO_PRUEBA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace APP_ELTIEMPO_PRUEBA.Controllers
{
    public class UsuarioRegistroController : Controller
    {
        private readonly HttpClient cliente = new HttpClient();
        private readonly string apiUrl = "https://localhost:44380/api/usuario";//




        // GET: Usuario
        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Registrar(RegistroUsuarioViewModel usuarioModel) {
            if (ModelState.IsValid)
            {
                usuarioModel.ROL_ID = 2;
                var respuesta = await cliente.PostAsJsonAsync(apiUrl, usuarioModel);

                if (respuesta.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ModelState.AddModelError("", "Error al registrar");
                    
                }
            }
            return View(usuarioModel);
        }




        
    }
}
