using BlogMVVMSample.Data;
using System;
using System.Globalization;
using System.Windows.Data;

namespace BlogMVVMSample.Converter
{

    /// <summary>
    /// enumの対象valueが選択されているかbool判定
    /// </summary>
    [ValueConversion(typeof(JobStatus), typeof(bool))]
    public class EnumToBoolConverter : IValueConverter
    {

        /// <summary>
        /// enum -> bool
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>string</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value is JobStatus selectedValue
                && parameter is JobStatus specifiedValue)
            {
                return selectedValue.Equals(specifiedValue);
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// bool -> enum
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>enum</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
