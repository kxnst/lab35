using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace lab35.Classes
{
    abstract class Human
    {
        protected string _fname;
        protected string _sname;
        public string FirstName { get=>_fname; set=>_fname = value; }
        public string LastName { get=>_sname; set=>_sname=value; }
        public Human(string fname, string sname)
        {
            FirstName = fname;
            LastName = sname;
        }
        public static Regex nameValidation = new Regex(@"^[a-zA-Z]+$");
        public override string ToString()
        {
            return $"Human {FirstName}{LastName}{{" +
                $"'fname':'{FirstName}', 'sname':'{LastName}'}}";
        }
    }
}
