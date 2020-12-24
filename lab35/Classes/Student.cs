using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using lab35.View;

namespace lab35.Classes
{
    class Student:Human,IStudy
    {
        protected string _studId;
        public string StudentId { get=>_studId; set=>_studId=value; }
        protected string _gender;
        public string Gender { get => _gender; set => _gender = value; }
        protected float _average;
        public string Country { get => _country; set => _country = value; }
        protected string _country;
        public float Average { get => _average; set => _average = (value > 5 ? 5 : (value > 1 ? value:1)); }

        public int Course { get => _course; set => _course = value>5?5:value<1?1:value; }
        protected int _course;
        public Student(string fname,string sname, string sId, string gender, string country, float average, int course) : base(fname, sname)
        {
            StudentId = sId;
            Gender = gender;
            Country = country;
            Average = average;
            Course = course;
        }
        public static Regex StudentIdValidation = new Regex(@"КВ[0-9]{6}");

        public bool Study()
        {
            View.View.GenerateMessage($"{FirstName} {LastName} studies");
            return true;
        }
        public override string ToString()
        {
            return $"Student {FirstName}{LastName}{{" +
                $"'fname':'{FirstName}'," +
                $"'sname':'{LastName}'," +
                $"'student_id':'{StudentId}'," +
                $"'gender':'{Gender}'," +
                $"'average':'{Average}'," +
                $"'country':'{Country}'" +
                $"'course':'{Course}'}}";
        }
    }
}
