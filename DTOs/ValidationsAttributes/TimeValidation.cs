using System.ComponentModel.DataAnnotations;
using DTOs.ClinicDtos;

namespace DTOs.ValidationsAttributes
{
  public class TimeGreaterThanAttribute : ValidationAttribute
  {
    private readonly string _comparisonProperty;

    public TimeGreaterThanAttribute(string comparisonProperty)
    {
      _comparisonProperty = comparisonProperty;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      if (value == null) return ValidationResult.Success;

      var currentValue = (DateTime)value;

      var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
      if (property == null)
      {
        return new ValidationResult($"Unknown property: {_comparisonProperty}");
      }

      var comparisonValue = (DateTime)property.GetValue(validationContext.ObjectInstance);

      if (currentValue <= comparisonValue)
      {
        return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} must be after {_comparisonProperty}");
      }

      return ValidationResult.Success;
    }
  }
}