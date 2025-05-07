using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API_ELTIEMPO_PRUEBA.Models
{
    [Table("OFERTA")]
    public class Oferta
    {
        [Column("ID")]
        public int ID { get; set; }
        [Column("CARGO")]
        public string CARGO { get; set; }
        [Column("DESCRIPCION")]
        public string DESCRIPCION { get; set; }
        [Column("UBICACION")]
        public string UBICACION { get; set; }
        [Column("SALARIO")]
        public string SALARIO { get; set; }
        [Column("FECHA_PUBLICACION")]
        public DateTime FECHA_PUBLICACION { get; set; }
        [Column("TIPO_CONTRATO_ID")]
        public int TIPO_CONTRATO_ID { get; set; }
        [ForeignKey("TIPO_CONTRATO_ID")]
        public virtual TipoContrato TIPOCONTRATO { get; set; }

        public virtual ICollection<AplicacionOferta> APLICACIONES { get; set; }
    }
}