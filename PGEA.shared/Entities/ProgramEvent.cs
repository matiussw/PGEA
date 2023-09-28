using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace PGEA.shared.Entities
{
	public class ProgramEvent
	{
        public int Id { get; set; }

        [Display(Name = "Nombre Evento")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede tener mas de un {1} Caracteres")]

        public String Name { get; set; } = null!;

        public DateTime FechaInicio { get; set; }

        [Display(Name = "Sesiones")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [MaxLength(200, ErrorMessage = "El Campo {0} no puede tener mas de un {1} Caracteres")]

        public int Sesiones { get; set; }

        [Display(Name = "Ponente")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [MaxLength(50, ErrorMessage = "El Campo {0} no puede tener mas de un {1} Caracteres")]
        public String Ponente { get; set; } = null!;


        [Display(Name = "Temas Tratados")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [MaxLength(50, ErrorMessage = "El Campo {0} no puede tener mas de un {1} Caracteres")]
        public String Temas { get; set; } = null!;

    }
}

