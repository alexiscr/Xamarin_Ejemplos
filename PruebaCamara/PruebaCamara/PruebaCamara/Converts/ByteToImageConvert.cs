using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace PruebaCamara.Converts
{
    public class ByteToImageConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {       
           // Realizamos una conversion de datos del objeto recivido
            var imagen = (byte[])value;

            // Devolvemos una fuente de imagen a partir de los byte obtenidos
            return ImageSource.FromStream(() => new MemoryStream(imagen)); 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
