using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace CsvValidator.Domain
{
    /// <summary>
    /// Failed property validation.
    /// </summary>
    public class FailedPropertyValidation
    {
        [UsedImplicitly]
        protected FailedPropertyValidation()
        {

        }

        /// <summary>
        /// Create instance of failed property validation.
        /// </summary>
        /// <param name="propertyName">Name of validating property.</param>
        /// <param name="rawValue">Raw property value.</param>
        /// <param name="failReason">Reason of failed validation.</param>
        public FailedPropertyValidation(string propertyName, string rawValue, string failReason)
        {
            PropertyName = propertyName;
            RawValue = rawValue;
            FailReason = failReason;
        }

        [Key]
        public int Id { get; protected set; }

        public string PropertyName { get; protected set; }

        public string RawValue { get; protected set; }

        public string FailReason { get; protected set; }
    }
}
