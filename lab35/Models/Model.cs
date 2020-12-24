using lab35.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace lab35.Models
{
    public class Model
    {
        public static Regex FullMemberMatch = new Regex(@"[A-Za-z]+[\ ][A-Za-z]+\{[a-zA-zа-яА-Я0-9\'\""\:\,\.\s]+\}");
        public static Regex GetMemberType = new Regex(@"([A-Za-z]+)[\ ]");
        public static Regex GetVarName = new Regex(@"([A-Za-z]+)[\{]");
        public static Regex GetVarParams = new Regex(@"\{[a-zA-zа-яА-Я\'\""\:\,\s]+\}");
        public static Regex KeyValuePair = new Regex(@"\'([a-zA-z0-9а-яА-Я]+)\'\:\'([a-zA-z0-9а-яА-Я]+)\'");
        public static Regex CountryValidation = new Regex(@"'country':'([a-zA-Zа-яА-Я]+)'");
        public static Regex CourseValidation = new Regex(@"'course':'([0-9])'");
        public static Regex AvgValidation = new Regex(@"'average':'([0-9\,\.]+)'");
        public string file;
        public Model(string path)
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            string Root = Directory.GetCurrentDirectory();
            file = Path.Combine(Root,@"..\..\..\"+path);
        }
        public bool ValidateField(string value, Regex regex)
        {   
            return regex.IsMatch(value);
        }
        public bool Write(string text)
        {
            using(StreamWriter writer = File.AppendText(file))
            {
                writer.WriteLine((@text));
            }
            return true;
        }
        public void PrintAll()
        {
            string str;
            using (StreamReader reader = new StreamReader(file))
            {
                str = reader.ReadToEnd();
                foreach (Match tmp in FullMemberMatch.Matches(str))
                {
                    string res = tmp.Value;
                    View.View.GenerateMessage(GetMemberType.Match(res) + " " + GetVarName.Match(res).Groups[1]);

                    foreach (Match keyValue in KeyValuePair.Matches(res))
                    {
                        View.View.GenerateMessage("\t"+keyValue.Value);
                    }                    
                }
                
            }
        }
        public void Select()
        {
            string str;
            using (StreamReader reader = new StreamReader(file))
            {
                str = reader.ReadToEnd();
                foreach (Match tmp in FullMemberMatch.Matches(str))
                {
                    string res = tmp.Value;
                    if (GetMemberType.Match(res).Value.Trim()!="Student")
                        continue;
                    if ((CountryValidation.Match(res).Groups[1].Value.ToLower() == "ukraine") || (CountryValidation.Match(res).Groups[1].Value.ToLower() == "україна"))
                        continue;
                    if (CourseValidation.Match(res).Groups[1].Value != "1")
                        continue;
                    string course = AvgValidation.Match(res).Groups[1].Value.Trim();
                    if (Convert.ToSingle(AvgValidation.Match(res).Groups[1].Value.Trim()) < 4)
                        continue;
                    View.View.GenerateMessage(GetMemberType.Match(res) + " " + GetVarName.Match(res).Groups[1]);

                    foreach (Match keyValue in KeyValuePair.Matches(res))
                    {
                        View.View.GenerateMessage("\t" + keyValue.Value);
                    }
                }

            }
        }
    }
}
