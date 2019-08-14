using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvValidator.Domain;
using CsvValidator.Models;
using CsvValidator.Repository;

namespace CsvValidator.Services
{
    public class ValidationService : IValidationService
    {
        private readonly IPropertyValidatorsFactory _propertyValidatorsFactory;
        private readonly ApplicationContext _context;

        public ValidationService(IPropertyValidatorsFactory propertyValidatorsFactory, ApplicationContext context)
        {
            _propertyValidatorsFactory = propertyValidatorsFactory;
            _context = context;
        }

        public async Task<bool> Validate(List<RowModel> rows)
        {
            if (rows == null)
                throw new ArgumentNullException();

            var isValidationSucceed = true;

            rows.ForEach(row =>
            {
                if (row.Properties == null) 
                    throw new ArgumentNullException();

                row.Properties.ForEach(property =>
                {
                    var propertyValidators = _propertyValidatorsFactory.GetPropertyValidators(property.PropertyName).ToList();

                    propertyValidators.ForEach(validator =>
                    {
                        if (!validator.Validate(property, out var failReason))
                        {
                            isValidationSucceed = false;
                            var failedPropertyValidation =
                                new FailedPropertyValidation(property.PropertyName, property.Value, failReason);

                            _context.FailedPropertyValidations.Add(failedPropertyValidation);
                        }
                    });
                });
            });

            await _context.SaveChangesAsync();
            return isValidationSucceed;
        }
    }
}