using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace MiguelGondresPA2.Validacion
{
    public class Validacion : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            string mensajeDeError = value as string;
            if(mensajeDeError != null)
            {
                if (mensajeDeError.Length <= 0)
                    return new ValidationResult(false, "Hay algun campo Vacio");
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Ningun Campo se puede dejar Vacio");
        }
    }
}
