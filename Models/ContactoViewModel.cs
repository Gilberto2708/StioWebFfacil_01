using System.ComponentModel.DataAnnotations;

namespace WebFFACIL.Models
{
    public class ContactoViewModel
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        [Display(Name = "Nombre Completo")]
        public string Nombre { get; set; }

        [StringLength(100, ErrorMessage = "El nombre de la empresa no puede exceder 100 caracteres")]
        [Display(Name = "Empresa")]
        public string? Empresa { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [Phone(ErrorMessage = "El formato del teléfono no es válido")]
        [StringLength(20, ErrorMessage = "El teléfono no puede exceder 20 caracteres")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un tipo de consulta")]
        [Display(Name = "Tipo de Consulta")]
        public string TipoConsulta { get; set; }

        [Display(Name = "Producto de Interés")]
        public string? ProductoInteres { get; set; }

        [Required(ErrorMessage = "El mensaje es obligatorio")]
        [StringLength(1000, ErrorMessage = "El mensaje no puede exceder 1000 caracteres")]
        [MinLength(10, ErrorMessage = "El mensaje debe tener al menos 10 caracteres")]
        [Display(Name = "Mensaje")]
        public string Mensaje { get; set; }

        [Required(ErrorMessage = "Debe aceptar el aviso de privacidad")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Debe aceptar el aviso de privacidad")]
        [Display(Name = "Acepto el Aviso de Privacidad")]
        public bool AceptaPrivacidad { get; set; }
    }
}
