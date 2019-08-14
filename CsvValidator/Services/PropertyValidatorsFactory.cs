using System;
using System.Collections.Generic;
using CsvValidator.Services.PropertyValidators;

namespace CsvValidator.Services
{
    public class PropertyValidatorsFactory : IPropertyValidatorsFactory
    {
        public IEnumerable<IPropertyValidator> GetPropertyValidators(string propertyName)
        {
            switch (propertyName)
            {
                case "ProductName":
                case "ProductId":
                case "CompanyName":
                    return new IPropertyValidator[]
                    {
                        new RequiredPropertyValidator()
                    };

                case "Barcode":
                    return new IPropertyValidator[]
                    {
                        new RequiredPropertyValidator(),
                        new DigitsOnlyPropertyValidator(),
                    };

                case "ProductPrice":
                    return new IPropertyValidator[]
                    {
                        new RequiredPropertyValidator(),
                        new PositiveNumberPropertyValidator()
                    };

                case "Description":
                    return new IPropertyValidator[] { };

                default:
                    throw new ArgumentOutOfRangeException();

            }
        }
    }
}