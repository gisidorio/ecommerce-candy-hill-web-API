using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Util
{
    public static class ConversorHelper
    {
        public static decimal ConverterParaDecimal(string value)
        {
            if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
            {
                return result;
            }
            throw new FormatException("Número inválido.");
        }
    }
}
