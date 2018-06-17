using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects.Data;
using Objects.Data.FrameworkExtensions;

using static System.Console;

namespace BusinessArchTest
{
    public enum TestEnum
    {
        ValEnum1,
        ValueEnumTest,
        YeeHaNinjaCowboy
    }

    class Program
    {
        static void Main(string[] args)
        {
            Camera c = Camera.GetMockInstance();
            CameraManager c2 = CameraManager.GetMockInstance();
            Console.WriteLine("This is a string literal".ToXmlCDataString());

            TestEnum e1 = EnumExtensions.FromName<TestEnum>("ValueEnumTest");
            TestEnum e2 = EnumExtensions.FromLabel<TestEnum>("Yee Ha Ninja Cowboy");
            e2.ToSqlParameter("EnumVar1");
            DateTime.Now.ToSqlParameter("DT");

            Console.WriteLine(EnumExtensions.ToLabel(e1));
            Console.WriteLine(EnumExtensions.ToName(e2));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.ReadKey();


        }
    }
}
