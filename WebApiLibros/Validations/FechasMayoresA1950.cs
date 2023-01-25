using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiLibros.Validations
{
    public class FechasMayoresA1950:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            DateTime fecha = Convert.ToDateTime(value);

            if (!(fecha.Year < 1950 && fecha.Day < 1 && fecha.Month < 1))
            {
                return new ValidationResult("La fecha es menor a 01/01/1950");
            }
            return ValidationResult.Success;


        }
    }
}
