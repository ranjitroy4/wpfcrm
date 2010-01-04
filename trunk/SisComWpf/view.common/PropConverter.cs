using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;

namespace SisComWpf.view.common {
    public class PropConverter : IValueConverter {
        
        public object Convert(object value,
                       Type targetType,
                       object parameter,
                       CultureInfo culture) {
            
            if (value != null) {
            //    List<DateTime> myList = (List<DateTime>)value;
            //    return myList[0].ToString("dd MMM yyyy");
                return value.ToString();
            } else {
                return String.Empty;
            }
        }

        public object ConvertBack(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture) {
            if (value != null) {
                return (List<DateTime>)value;
            }
            return null;
        }
    }
}