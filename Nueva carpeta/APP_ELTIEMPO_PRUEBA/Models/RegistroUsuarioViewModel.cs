using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APP_ELTIEMPO_PRUEBA.Models
{
    public class RegistroUsuarioViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Usuario")]
        public string USUARIO { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string CONTRASENA { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string NOMBRE { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        [Display(Name = "Correo")]
        public string CORREO { get; set; }

        [Required]
        [Display(Name = "Rol")]
        public int ROL_ID { get; set; }

    }
}