using CsvValidator.Models;

namespace CsvValidator.Services.PropertyValidators
{
    public interface IPropertyValidator
    {
        bool Validate(PropertyModel propertyModel, out string failReason);
    }
}