using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using PGEA.shared.Validation;

namespace PGEA.shared.Entities
{
	public class Attendee
	{
        [Display(Name = "Cedula Parcipante")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        public int Cedula { get; set; }

        [Display(Name = "Nombre Parcipante")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede tener mas de un {1} Caracteres")]

        public String Name { get; set; } = null!;

        [Display(Name = "Afiliacion Institucional")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede tener mas de un {1} Caracteres")]

        public String Afiliacion { get; set; } = null!;

        [Display(Name = "Area De Interes")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [MaxLength(200, ErrorMessage = "El Campo {0} no puede tener mas de un {1} Caracteres")]

        public String Area { get; set; } = null!;

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [MaxLength(50, ErrorMessage = "El Campo {0} no puede tener mas de un {1} Caracteres")]
        [RolValido]
        public String Rol { get; set; } = null!;

    }
}

