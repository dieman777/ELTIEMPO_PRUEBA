using API_ELTIEMPO_PRUEBA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace API_ELTIEMPO_PRUEBA.Controllers
{
    public class UsuarioController : ApiController
    {
        private ApiBdContext context = new ApiBdContext();

        public IEnumerable<Usuario> Get()
        {
            return context.Usuarios.ToList();
        }

        public IHttpActionResult Post(Usuario usuario)
        {
            context.Usuarios.Add(usuario);
            context.SaveChanges();
            return CreatedAtRoute("EMPLEO", new { id = usuario.ID }, usuario);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, Usuario usuario) {
            var existeusuario = context.Usuarios.Find(id);
            if (existeusuario == null)
            {
                return BadRequest($"No se encontró el usuario {usuario.NOMBRE}");
            }
            existeusuario.USUARIO = usuario.USUARIO;
            existeusuario.NOMBRE = usuario.NOMBRE;
            existeusuario.ROL_ID = usuario.ROL_ID;

            context.SaveChanges();
            return Ok(new { mensaje = "Usuario modificado"});
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        { 
            var usuario = context.Usuarios.Find(id);
            if (usuario == null)
            {
                return BadRequest($"No se encontró el usuario");
            }
            context.Usuarios.Remove(usuario);
            context.SaveChanges();
            return Ok(usuario);
        }
    }
}
