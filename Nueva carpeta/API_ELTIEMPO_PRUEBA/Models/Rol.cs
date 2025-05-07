using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API_ELTIEMPO_PRUEBA.Models
{
    [Table("ROL")]
    public class Rol
    {
        [Column("ID")]
        public int ID { get; set; }
        [Column("NOMBRE")]
        public string NOMBRE { get; set; }
        public virtual ICollection<Usuario> USUARIOS { get; set; }
    }
}