using CsvValidator.Models;

namespace CsvValidator.Services.PropertyValidators
{
    public class RequiredPropertyValidator : IPropertyValidator
    {
        public virtual bool Validate(PropertyModel propertyModel, out string failReason)
        {
            failReason = null;

            if (string.IsNullOrWhiteSpace(propertyModel.Value))
            {
                failReason = $"{propertyModel.PropertyName} is required field";
                return false;
            }

            return true;
        }
    }
}