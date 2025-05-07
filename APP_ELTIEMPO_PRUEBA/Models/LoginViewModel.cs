using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APP_ELTIEMPO_PRUEBA.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "usuario")]
        public string usuario { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string contrasena { get; set; }
    }
}