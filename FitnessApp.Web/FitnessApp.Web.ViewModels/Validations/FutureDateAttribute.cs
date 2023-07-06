using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Web.ViewModels.Models.Goal
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime targetDate)
            {
                if (targetDate.Date < DateTime.Today)
                {
                    return new ValidationResult("Target Date must be in the future.");
                }
            }

            return ValidationResult.Success;
        }
    }
}