using NUnit.Framework;
using lab35.Models;
using System;

namespace test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void Test_Write_Passed_Non_existing_excepted_true()
        {
            Model model = new Model("not.existing");
            bool excepted = model.Write("asd");
            Assert.AreEqual(excepted,true);
        }
        [Test]
        public void Test_Regex_Passed_Avg_Expected_true()
        {
            Model model = new Model("not.existing");
            bool excepted = model.ValidateField("'average':'4.5'", Model.AvgValidation);
            Assert.AreEqual(excepted, true);
        }
        [Test]
        public void Test_Regex_Passed_Avg_Expected_false()
        {
            Model model = new Model("not.existing");
            bool excepted = model.ValidateField("'average':'4a.5'", Model.AvgValidation);
            Assert.AreEqual(excepted, false);
        }
        [Test]
        public void Test_Print_All_Empty_Expected_Ok()
        {
            Model model = new Model("not.existing");
            Assert.DoesNotThrow(() => model.PrintAll());
        }
        [Test]
        public void Test_Select_Empty_Expected_Ok()
        {
            Model model = new Model("not.existing");
            Assert.DoesNotThrow(() => model.Select());
        }
        [Test]
        public void Test_Print_All_Not_Empty_Expected_Ok()
        {
            Model model = new Model("DataBase.txt");
            Assert.DoesNotThrow(() => model.PrintAll());
        }
        [Test]
        public void Test_Select_Not_Empty_Expected_Ok()
        {
            Model model = new Model("DataBase.txt");
            Assert.DoesNotThrow(() => model.Select());

        }
    }
}