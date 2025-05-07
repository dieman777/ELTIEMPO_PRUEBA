using Microsoft.Owin.Security.OAuth;//Nuevo: Se instala este paquete libreria para autorizaciones
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace API_ELTIEMPO_PRUEBA
{
    public class LoginAutorizacionProveedor : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext autorizacionServer)
        {
            //autorizacionServer.();
            autorizacionServer.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext contextoCedrencial)
        {
            System.Diagnostics.Debug.WriteLine("Ejecutando GrantResourceOwnerCredentials...");

            contextoCedrencial.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*"});

            using (var db = new ApiBdContext())
            {
                var login = db.Usuarios.Include("Rol").FirstOrDefault(u=>u.USUARIO == contextoCedrencial.UserName && u.CONTRASENA == contextoCedrencial.Password);

                if (login == null)
                {
                    contextoCedrencial.SetError("invalid_grant", "Usuario o contraseña no son correctos ");
                    return;
                }

                var identidad = new ClaimsIdentity(contextoCedrencial.Options.AuthenticationType);
                identidad.AddClaim(new Claim(ClaimTypes.Name, login.USUARIO));
                identidad.AddClaim(new Claim(ClaimTypes.Role, login.ROL.NOMBRE));
                identidad.AddClaim(new Claim("usuario_id", login.ID.ToString()));

                contextoCedrencial.Validated(identidad);
            };
        }
    }
}