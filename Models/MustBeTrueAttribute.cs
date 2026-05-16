using System.ComponentModel.DataAnnotations;

namespace WebFFACIL.Models
{
    public class MustBeTrueAttribute : ValidationAttribute
    {
        public MustBeTrueAttribute()
        {
            ErrorMessage = "Debe aceptar el aviso de privacidad";
        }

        public override bool IsValid(object? value)
        {
            return value is bool b && b;
        }
    }
}
