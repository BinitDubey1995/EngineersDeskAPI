using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Helper
{
    /// <summary>
    /// Global Function
    /// </summary>
    public static class CheckEmptyString
    {
        public static bool CheckEmptyStringForName( string name)
        {
            if (name=="")
            {
                return true;
            }
            return false;
        }

        public static bool CheckEmptyStringForCity(String city)
        {
            if (city == "")
            {
                return true;
            }
            return false;
        }
    }
}
