using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API_ELTIEMPO_PRUEBA.Models
{
    [Table("USUARIO")]
    public class Usuario
    {
        [Column("ID")]
        public int ID { get; set; }
        [Column("USUARIO")]
        public string USUARIO { get; set; }
        [Column("CONTRASENA")]
        public string CONTRASENA { get; set; }
        [Column("NOMBRE")]
        public string NOMBRE { get; set; }
        [Column("CORREO")]
        public string CORREO { get; set; }
        [Column("ROL_ID")]
        public int ROL_ID { get; set; }
        [ForeignKey("ROL_ID")]
        public virtual Rol ROL { get; set; }

        //public virtual ICollection<AplicacionOferta> APLICACIONES { get; set; }
    }
}