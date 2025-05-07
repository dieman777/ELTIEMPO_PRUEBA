using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APP_ELTIEMPO_PRUEBA.Models
{
    public class OfertaEmpleoViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "El cargo es obligatorio.")]
        [StringLength(100, ErrorMessage = "El cargo no puede exceder los 100 caracteres.")]
        [Display(Name = "Cargo")]
        public string CARGO { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [Display(Name = "Descripción")]
        public string DESCRIPCION { get; set; }

        [Required(ErrorMessage = "La ubicación es obligatoria.")]
        [Display(Name = "Ubicación")]
        public string UBICACION { get; set; }

        [Required(ErrorMessage = "El salario es obligatorio.")]
        [Display(Name = "Salario")]
        public string SALARIO { get; set; }

        [Display(Name = "Fecha de Publicación")]
        [DataType(DataType.Date)]
        public DateTime FECHA_PUBLICACION { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un tipo de contrato.")]
        [Display(Name = "Tipo de Contrato")]
        public int TIPO_CONTRATO_ID { get; set; }

        [Display(Name = "Tipo de Contrato")]
        public string TipoContratoNombre { get; set; } // Para mostrar el nombre en la vista

        // Esto se usa para un dropdown en la vista
        public IEnumerable<System.Web.Mvc.SelectListItem> TiposContrato { get; set; }

        public OfertaEmpleoViewModel()
        {
            TiposContrato = new List<SelectListItem>();
        }

    }
}