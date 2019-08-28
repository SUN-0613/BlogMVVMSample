using BlogMVVMSample.Data;
using System;
using System.Globalization;
using System.Windows.Data;

namespace BlogMVVMSample.Converter
{

    /// <summary>
    /// enumのvalueをstringに変換
    /// </summary>
    [ValueConversion(typeof(JobStatus), typeof(string))]
    public class JobStatusConverter : IValueConverter
    {

        /// <summary>
        /// enum -> string
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>string</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if (value is JobStatus job)
            {

                switch (job)
                {

                    case JobStatus.NotOrdered:
                        return "未注";

                    case JobStatus.Ordered:
                        return "受注";

                    case JobStatus.Delivery:
                        return "納品";

                    case JobStatus.Finished:
                        return "完了";

                    default:
                        return "";

                }

            }
            else
            {
                return "";
            }

        }

        /// <summary>
        /// string -> enum
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>enum</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if (value is string str)
            {

                switch (str)
                {

                    case "受注":
                        return JobStatus.Ordered;

                    case "納品":
                        return JobStatus.Delivery;

                    case "完了":
                        return JobStatus.Finished;

                    default:
                        return JobStatus.NotOrdered;

                }

            }
            else
            {
                return JobStatus.NotOrdered;
            }

        }

    }

}
