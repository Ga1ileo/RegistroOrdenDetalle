using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace RegistroOrdenDetalle.Validacion
{
    public class ValidacionProductos : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string Mensaje = value as string;
            if (Mensaje != null)
            {
                if (Mensaje.Length <= 0)
                    return new ValidationResult(false, "Debes poner un Nombre");

                return ValidationResult.ValidResult;

            }
            return new ValidationResult(false, "Debes poner un Nombre");
        }
    }

    public class ValidacionCantidad : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                int cantidad = 0;
                try
                {
                    cantidad = Convert.ToInt32(value);
                }
                catch
                {
                    return new ValidationResult(false, "La cantidad debe ser un numero");
                }

                if (cantidad >= 1)
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "La cantidad debe mayor o igual a uno");

            }
            return new ValidationResult(false, "Debes poner una cantidad");
        }
    }

    public class ValidacionProductoId : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                int id = 0;
                try
                {
                    id = Convert.ToInt32(value);
                }
                catch
                {
                    return new ValidationResult(false, "La cantidad debe ser un numero");
                }

                if (id >= 1)
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "La cantidad debe mayor o igual a uno");

            }
            return new ValidationResult(false, "Debes poner una cantidad");
        }
    }
}
