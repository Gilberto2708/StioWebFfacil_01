using System.ComponentModel.DataAnnotations;

namespace WebFFACIL.Models
{
    public class DistribuidorViewModel
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        [Display(Name = "Nombre Completo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [Phone(ErrorMessage = "El formato del teléfono no es válido")]
        [StringLength(20, ErrorMessage = "El teléfono no puede exceder 20 caracteres")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La ciudad es obligatoria")]
        [StringLength(100, ErrorMessage = "La ciudad no puede exceder 100 caracteres")]
        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [StringLength(100, ErrorMessage = "El nombre de la empresa no puede exceder 100 caracteres")]
        [Display(Name = "Empresa (Opcional)")]
        public string? Empresa { get; set; }

        [Display(Name = "Experiencia en Ventas")]
        public string? ExperienciaVentas { get; set; }

        [StringLength(500, ErrorMessage = "El mensaje no puede exceder 500 caracteres")]
        [Display(Name = "¿Por qué quieres ser distribuidor?")]
        public string? Motivacion { get; set; }

        [Required(ErrorMessage = "Debe aceptar los términos y condiciones")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Debe aceptar los términos y condiciones")]
        [Display(Name = "Acepto los Términos y Condiciones")]
        public bool AceptaTerminos { get; set; }

        public string Mensaje { get; set; } 
    }
}
