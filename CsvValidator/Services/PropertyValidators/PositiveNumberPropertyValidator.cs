using CsvValidator.Models;

namespace CsvValidator.Services.PropertyValidators
{
    public class PositiveNumberPropertyValidator : IPropertyValidator
    {
        public virtual bool Validate(PropertyModel propertyModel, out string failReason)
        {
            failReason = null;

            if (!decimal.TryParse(propertyModel.Value, out var number))
            {
                failReason = $"{propertyModel.PropertyName} is not a number";
                return false;
            }

            if (number <= 0)
            {
                failReason = $"{propertyModel.PropertyName} is not a positive number";
                return false;
            }

            return true;
        }
    }
}