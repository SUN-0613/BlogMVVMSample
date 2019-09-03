using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace BlogMVVMSample.Converter
{

    /// <summary>
    /// BitmapをBitmapSourceへ変換
    /// </summary>
    [ValueConversion(typeof(Bitmap), typeof(BitmapSource))]
    public class BitmapConverter : IValueConverter
    {

        /// <summary>
        /// メモリ解放
        /// </summary>
        /// <param name="hObject"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);

        /// <summary>
        /// Bitmap -> BitmapSource
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>string</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
         
            if (value is Bitmap bitmap)
            {

                var handle = bitmap.GetHbitmap();

                try
                {
                    return Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                }
                finally
                {
                    DeleteObject(handle);
                }

            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// 今回は使用しない
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
