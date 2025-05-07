using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API_ELTIEMPO_PRUEBA.Models
{
    [Table("TIPOCONTRATO")]
    public class TipoContrato
    {
        [Column("ID")]
        public int ID { get; set; }
        [Column("DESCRIPCION")]
        public string DESCRIPCION { get; set; }
        [JsonIgnore]
        public virtual ICollection<Oferta> OFERTAS { get; set; }
    }
}