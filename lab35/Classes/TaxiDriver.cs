using System;
using System.Collections.Generic;
using System.Text;

namespace lab35.Classes
{
    class TaxiDriver : Human, IStudy, IDrive
    {
        public TaxiDriver(string fname, string sname) : base(fname, sname)
        {

        }

        public bool Drive()
        {
            View.View.GenerateMessage($"{FirstName} {LastName} drives");
            return true;
        }

        public bool Study()
        {
            View.View.GenerateMessage($"{FirstName} {LastName} studies");
            return true;
        }
        public override string ToString()
        {
            return $"TaxiDriver {FirstName}{LastName}{{" +
                $"'fname':'{FirstName}', 'sname':'{LastName}'}}";
        }
    }
}
