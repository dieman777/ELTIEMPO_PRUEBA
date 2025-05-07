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
    public class TipoContratoController : ApiController
    {
        private ApiBdContext context = new ApiBdContext();

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(context.TiposContrato.ToList());
        }
    }
}
