using System.Text.RegularExpressions;
using CsvValidator.Models;

namespace CsvValidator.Services.PropertyValidators
{
    public class DigitsOnlyPropertyValidator : IPropertyValidator
    {
        public virtual bool Validate(PropertyModel propertyModel, out string failReason)
        {
            failReason = null;

            var regex = new Regex(@"^[0-9]+$");
            if (!regex.IsMatch(propertyModel.Value))
            {
                failReason = $"{propertyModel.PropertyName} does not contains digits only";
                return false;
            }

            return true;
        }
    }
}
