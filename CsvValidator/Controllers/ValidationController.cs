using System.Threading.Tasks;
using CsvValidator.Models;
using CsvValidator.Services;
using Microsoft.AspNetCore.Mvc;

namespace CsvValidator.Controllers
{
    [ApiController]
    public class ValidationController : ControllerBase
    {
        private readonly IValidationService _validationService;

        public ValidationController(IValidationService validationService)
        {
            _validationService = validationService;
        }

        [Route("api/validation")]
        [HttpPost]
        public async Task<ValidationResponseModel> Validate(ValidationRequestModel model)
        {
            var isValid = await _validationService.Validate(model.Rows);

            return new ValidationResponseModel
            {
                IsValid = isValid
            };
        }
    }
}
