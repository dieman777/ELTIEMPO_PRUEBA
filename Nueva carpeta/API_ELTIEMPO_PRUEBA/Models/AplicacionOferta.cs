using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API_ELTIEMPO_PRUEBA.Models
{
    [Table("APLICACIONOFERTA")]
    public class AplicacionOferta
    {
        [Column("ID")]
        public int ID { get; set; }
        [Column("OFERTA_ID")]
        public int OFERTA_ID { get; set; }
        [ForeignKey("OFERTA_ID")]
        public virtual Oferta OFERTA { get; set; }
        [Column("USUARIO_ID")]
        public int USUARIO_ID { get; set; }
        [ForeignKey("USUARIO_ID")]
        public virtual Usuario USUARIO { get; set; }
        [Column("FECHA_APLICACION")]
        public DateTime FECHA_APLICACION { get; set; }
    }
}