using API_ELTIEMPO_PRUEBA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_ELTIEMPO_PRUEBA.Controllers
{
    [Authorize]
    public class OfertaController : ApiController
    {
        private ApiBdContext context = new ApiBdContext();

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(context.Ofertas.ToList());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var oferta = context.Ofertas.Find(id);
            if (oferta == null)
            {
                return NotFound();
            }
            return Ok(oferta);
        }
        

        [HttpPost]
        public IHttpActionResult Post([FromBody]Oferta oferta)
        {
            context.Ofertas.Add(oferta);
            context.SaveChanges();
            return Ok(oferta);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Oferta oferta)
        {
            var existeOferta = context.Ofertas.Find(id);
            if (existeOferta == null)
            {
                return NotFound();
            }

            existeOferta.CARGO = oferta.CARGO;
            existeOferta.DESCRIPCION = oferta.DESCRIPCION;
            existeOferta.UBICACION = oferta.UBICACION;
            existeOferta.SALARIO = oferta.SALARIO;
            existeOferta.FECHA_PUBLICACION = oferta.FECHA_PUBLICACION;
            existeOferta.TIPO_CONTRATO_ID = oferta.TIPO_CONTRATO_ID;

            context.SaveChanges();
            return Ok(existeOferta);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var oferta = context.Ofertas.Find(id);
            if (oferta == null)
            {
                return NotFound();
            }

            context.Ofertas.Remove(oferta);
            context.SaveChanges();
            return Ok();
        }
    }
}
