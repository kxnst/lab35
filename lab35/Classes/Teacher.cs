using System;
using System.Collections.Generic;
using System.Text;

namespace lab35.Classes
{
    class Teacher : Human, IStudy, ITeach
    {
        public Teacher(string fname, string sname) : base(fname, sname)
        {

        }
        public bool Teach()
        {
            View.View.GenerateMessage($"{FirstName} {LastName} teaches");
            return true;
        }

        public bool Study()
        {
            View.View.GenerateMessage($"{FirstName} {LastName} studies");
            return true;
        }
        public override string ToString()
        {
            return @$"Teacher {FirstName}{LastName}{{'fname':'{FirstName}', 'sname':'{LastName}'}}";
        }
    }
}
