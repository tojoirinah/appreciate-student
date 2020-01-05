using System.ComponentModel.DataAnnotations;

namespace Appreciation.Manager.Utils.Attributes
{
    public class IdentityValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return ((long)value) > 0;
        }
    }
}
