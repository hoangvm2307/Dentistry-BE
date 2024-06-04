using System.ComponentModel.DataAnnotations;

namespace DTOs.ValidationsAttributes
{
  public class CustomDateRangeAttribute : ValidationAttribute
  {
    public override bool IsValid(object value)
    {
      if (value == null)
        return true;

      var date = value as DateTime? ?? new DateTime();
      return date >= DateTime.Today;
    }
  }

  // Custom validation attribute to ensure one date is greater than another
  public class DateGreaterThanAttribute : ValidationAttribute
  {
    private readonly string _comparisonProperty;
    public bool AllowEqualDates { get; set; } = false;

    public DateGreaterThanAttribute(string comparisonProperty)
    {
      _comparisonProperty = comparisonProperty;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      if (value == null)
        return ValidationResult.Success;

      var currentValue = (DateTime)value;

      var comparisonProperty = validationContext.ObjectType.GetProperty(_comparisonProperty);

      if (comparisonProperty == null)
        throw new ArgumentException("Property with this name not found");

      var comparisonValue = (DateTime)comparisonProperty.GetValue(validationContext.ObjectInstance);

      if (AllowEqualDates ? currentValue >= comparisonValue : currentValue > comparisonValue)
        return ValidationResult.Success;

      return new ValidationResult(ErrorMessage);
    }
  }
}