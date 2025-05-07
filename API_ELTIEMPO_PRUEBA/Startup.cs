using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(API_ELTIEMPO_PRUEBA.Startup))]

namespace API_ELTIEMPO_PRUEBA
{
    public class Startup
    {
        public void Configuration(IAppBuilder appAutenticacion)
        {
            appAutenticacion.UseCors(CorsOptions.AllowAll);

            ConfiguracionOAuth(appAutenticacion);

            HttpConfiguration configuracion = new HttpConfiguration();
            WebApiConfig.Register(configuracion);
            appAutenticacion.UseWebApi(configuracion);
        }

        public void ConfiguracionOAuth(IAppBuilder appAutenticacion)
        {
            OAuthAuthorizationServerOptions oAuthAut = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                Provider = new LoginAutorizacionProveedor()
            };
            appAutenticacion.UseOAuthAuthorizationServer(oAuthAut);
            appAutenticacion.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    
    }
}