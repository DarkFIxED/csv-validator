using System.Collections.Generic;
using System.Threading.Tasks;
using CsvValidator.Models;

namespace CsvValidator.Services
{
    public interface IValidationService
    {
        Task<bool> Validate(List<RowModel> rows);
    }
}