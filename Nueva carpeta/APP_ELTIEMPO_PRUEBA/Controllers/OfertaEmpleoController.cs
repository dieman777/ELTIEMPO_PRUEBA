using APP_ELTIEMPO_PRUEBA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace APP_ELTIEMPO_PRUEBA.Controllers
{
    public class OfertaEmpleoController : Controller
    {
        private readonly string apiUrl = "https://localhost:44380/api";//

        [HttpGet]
        public async Task<ActionResult> Registro(int ? id)
        {
            var modelo = new OfertaEmpleoViewModel
            {
                FECHA_PUBLICACION = DateTime.Now
            };

            using (var cliente = new HttpClient())
            {
                var token = Session["access_token"]?.ToString();
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var tiposContratoRespuestas = await cliente.GetAsync($"{apiUrl}/TipoContrato");
                if (tiposContratoRespuestas.IsSuccessStatusCode)
                {
                    var tiposContrato = await tiposContratoRespuestas.Content.ReadAsAsync<List<TipoContratoViewModel>>();
                    modelo.TiposContrato = tiposContrato.Select(tc => new SelectListItem
                    {
                        Value = tc.ID.ToString(),
                        Text = tc.DESCRIPCION
                    });

                }

                if (id.HasValue)
                {
                    var respuestaOferta = await cliente.GetAsync($"{apiUrl}/Oferta/{id}");
                    if (respuestaOferta.IsSuccessStatusCode)
                    {
                        var oferta = await respuestaOferta.Content.ReadAsAsync<OfertaEmpleoViewModel>();
                        oferta.TiposContrato = modelo.TiposContrato;
                        modelo = oferta;
                        return View("Registro", oferta);
                    }
                }

            }
            return View("Registro", modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Guardar(OfertaEmpleoViewModel ofertaEmpleModel)
        {
            using (var cliente = new HttpClient()) {
                var token = Session["access_token"]?.ToString();
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                ofertaEmpleModel.FECHA_PUBLICACION = DateTime.Now;
                HttpResponseMessage response;
                if (ofertaEmpleModel.ID == 0)
                {
                    
                    response = await cliente.PostAsJsonAsync($"{apiUrl}/Oferta", ofertaEmpleModel);
                }
                else
                {
                    response = await cliente.PutAsJsonAsync($"{apiUrl}/Oferta/{ofertaEmpleModel.ID}", ofertaEmpleModel);
                }

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Error guardando oferta");
                    await CargarTiposContrato(ofertaEmpleModel);
                    return View("Registro", ofertaEmpleModel);
                }
            }
        }

        private async Task CargarTiposContrato(OfertaEmpleoViewModel model)
        {
            using (var client = new HttpClient())
            {
                var token = Session["access_token"]?.ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await client.GetAsync($"{apiUrl}/TipoContrato");
                if (response.IsSuccessStatusCode)
                {
                    var tipos = await response.Content.ReadAsAsync<List<TipoContratoViewModel>>();
                    model.TiposContrato = tipos.Select(tc => new SelectListItem
                    {
                        Value = tc.ID.ToString(),
                        Text = tc.DESCRIPCION
                    });
                }
            }
        }

        

        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            List<OfertaEmpleoViewModel> ofertas = new List<OfertaEmpleoViewModel>();

            using (var cliente = new HttpClient())
            {
                var token = Session["access_token"]?.ToString();
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var respuesta = await cliente.GetAsync($"{apiUrl}/Oferta");
                if (respuesta.IsSuccessStatusCode)
                {
                    ofertas = await respuesta.Content.ReadAsAsync<List<OfertaEmpleoViewModel>>();
                }
            }

            return View(ofertas);
        }
    }
}
