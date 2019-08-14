using System.Collections.Generic;
using CsvValidator.Services.PropertyValidators;

namespace CsvValidator.Services
{
    public interface IPropertyValidatorsFactory
    {
        IEnumerable<IPropertyValidator> GetPropertyValidators(string propertyName);
    }
}
