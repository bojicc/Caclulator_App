using CalculatorApp.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace CalculatorApp.Localization
{
    public class StringLocalization
    {
        private static Resources resource = new Resources();
        public Resources Resources => resource;
    }
}
