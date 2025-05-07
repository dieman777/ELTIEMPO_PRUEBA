using API_ELTIEMPO_PRUEBA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ELTIEMPO_PRUEBA.Interfaces
{
    internal interface IApiBdContext : IDisposable
    {
        DbSet<Oferta> Ofertas { get; set; }
    }
}
