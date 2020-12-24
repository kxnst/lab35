using System;
using System.IO;
using lab35.Controller;

namespace lab35
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            String Root = Directory.GetCurrentDirectory();

            Controller.Controller controller = new Controller.Controller();
        }
    }
}
