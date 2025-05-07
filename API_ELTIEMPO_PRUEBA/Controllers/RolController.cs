using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;

namespace API_ELTIEMPO_PRUEBA.Controllers
{
    public class RolController : ApiController
    {
        private ApiBdContext context = new ApiBdContext();

        public IHttpActionResult Get()
        {
            return Ok(context.Roles.ToList());
        }
    }
}
