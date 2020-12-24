using lab35.Classes;
using lab35.Models;
using System;

namespace lab35.Controller
{
    class Controller
    {
        public Model model;
        public Controller()
        {
            model = new Model("DataBase.txt");
            init();
        }
        public void init()
        {
            string startMenu = @"Enter command:
print - print all
create - create new
select - select all first course foreigners
";
            string method = View.View.GetData(startMenu); ;
            switch (method.ToLower())
            {
                case "print":
                    model.PrintAll();
                    init();
                    break;
                case "create":
                    CreateStrudent();
                    break;
                case "select":
                    Select();
                    init();
                    break;
                default:
                    init();
                    break;
            }
        }
        public void SelectClass()
        {
            string menu = "select class (0-student, 1-taxi driver, 2-teacher)";
            string result = View.View.GetData(menu);
            switch (result.ToLower())
            {
                case "0":
                    CreateStrudent();
                    init();
                    break;
                case "1":
                    CreateTaxiDriver();
                    init();
                    break;
                case "2":
                    CreateTeacher();
                    init();
                    break;
                default:
                    SelectClass();
                    init();
                    break;
            }
        }
        public void CreateTaxiDriver()
        {
            string fname;
            while (true)
            {
                fname = View.View.GetData("Enter first name");
                if (model.ValidateField(fname, Human.nameValidation))
                    break;
            }
            string sname;
            while (true)
            {
                sname = View.View.GetData("Enter last name");
                if (model.ValidateField(sname, Human.nameValidation))
                    break;
            }
            Human taxiDriver = new TaxiDriver(fname, sname);
            model.Write(taxiDriver.ToString());
        }
        public void CreateTeacher()
        {

            string fname;
            while (true)
            {
                fname = View.View.GetData("Enter first name");
                if (model.ValidateField(fname, Human.nameValidation))
                    break;
            }
            string sname;
            while (true)
            {
                sname = View.View.GetData("Enter last name");
                if (model.ValidateField(sname, Human.nameValidation))
                    break;
            }
            Human teacher = new Teacher(fname, sname);
            model.Write(teacher.ToString());

        }
        public void CreateStrudent()
        {
            string fname;
            while (true)
            {
                fname = View.View.GetData("Enter first name");
                if (model.ValidateField(fname, Human.nameValidation))
                    break;
            }
            string sname;
            while (true)
            {
                sname = View.View.GetData("Enter last name");
                if (model.ValidateField(sname, Human.nameValidation))
                    break;
            }
            string sId;
            while (true)
            {
                sId = View.View.GetData("Enter student id (КВ + 6 numbers)");
                if (model.ValidateField(sId, Student.StudentIdValidation))
                    break;
            }
            string gender;
            while (true)
            {
                gender = View.View.GetData("Enter gender");//European localization
                if (model.ValidateField(gender, Human.nameValidation))
                    break;
            }
            float avg;
            while (true)
            {
                string r = View.View.GetData("Enter average");
                try
                {
                    avg = Convert.ToSingle(r);
                    break;
                }
                catch (Exception) { };
            }
            string country;
            while (true)
            {
                country = View.View.GetData("Enter country");
                if (model.ValidateField(country, Human.nameValidation))
                    break;
            }
            int course;
            while (true)
            {
                string r = View.View.GetData("Enter course");
                try
                {
                    course = Convert.ToInt32(r);
                    break;
                }
                catch (Exception) { };
            }
            Human student = new Student(fname, sname, sId, gender,country,avg,course);
            model.Write(student.ToString());
        }
        public void Select()
        {
            model.Select();
        }
    }
}
