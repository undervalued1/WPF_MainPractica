using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPFpractica3.Converters
{
    class ConverterDate :IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            if(value is DateTime dateOfBirth)
            {
                int age = DateTime.Now.Year - dateOfBirth.Year;

                if (DateTime.Now < dateOfBirth.AddYears(age))
                    age--;
                return age >= 18 
                    ? $"Возраст: {age}  Совершенолетний" :
                    $"Возраст: {age}  Несовершенолетний";
            }

            return "Некорректная дата";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
}
