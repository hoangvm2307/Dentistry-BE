using System.ComponentModel.DataAnnotations;
using DTOs.ClinicDtos;

namespace DTOs.ValidationsAttributes
{
  public class TimeValidation : ValidationAttribute
  {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      var clinic = (ClinicCreateDto)validationContext.ObjectInstance;

      if (clinic.OpeningHours >= clinic.ClosingHours)
      {
        return new ValidationResult("Closing hours must be after opening hours.");
      }

      return ValidationResult.Success;
    }
  }
}