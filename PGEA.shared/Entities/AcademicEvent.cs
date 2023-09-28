using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace PGEA.shared.Entities
{
	public class AcademicEvent
    {
        public int Id { get; set; }


        [Display(Name = "Nombre de Evento")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede tener mas de un {1} Caracteres")]
        public String Name { get; set; } = null!;

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFinalizacion { get; set; }

        [Display(Name = "Ubicacion")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede tener mas de un {1} Caracteres")]
        public String Ubicacion { get; set; } = null!;

        [Display(Name = "Descripcion Evento")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [MaxLength(200, ErrorMessage = "El Campo {0} no puede tener mas de un {1} Caracteres")]
        public String Descripcion { get; set; } = null!;

        [Display(Name = "Tema Evento")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [MaxLength(200, ErrorMessage = "El Campo {0} no puede tener mas de un {1} Caracteres")]
        public String Tema { get; set; } = null!;

    }
}

