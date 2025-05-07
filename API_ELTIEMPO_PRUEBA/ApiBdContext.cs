using API_ELTIEMPO_PRUEBA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API_ELTIEMPO_PRUEBA
{
    public class ApiBdContext : DbContext
    {
        //Llamo la conexión
        public ApiBdContext() : base("name=ElTiempoConnection")
        {
            Database.SetInitializer<ApiBdContext>(null);
        }

        //Se referencian para mapear las tablas de la base de datos
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<TipoContrato> TiposContrato { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<AplicacionOferta> AplicacionesOferta { get; set; }
    }
}