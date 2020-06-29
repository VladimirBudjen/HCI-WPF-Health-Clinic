using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HealthClinic.View.ErrorCheck
{
    public static class Checker
    {
        public static Regex nameRegex = new Regex(@"^[A-Z][a-z]+$");
        public static Regex jmbgRegex = new Regex(@"^[0-9]+$");

      
    }
}
