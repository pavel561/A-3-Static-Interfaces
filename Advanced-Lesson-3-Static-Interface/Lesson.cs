using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_3_Static_Interface
{
    public partial class Lesson
    {
        public static void StaticVsInstanceExample()
        {
            string text1 = "Hello World!";
            string text2 = "Hello Minks!";

            int theSameInstance = text1.CompareTo(text2);
            int theSameStatic = string.Compare(text1, text2);
        }

        public static void CarExample()
        {
            Car car = new Car();
            ITransport transport = new Car();

            car.Move(2);
            car.FillUp(2);

            transport.Move(2);
            //transport.FillUp(2);  не компилируется
            (transport as Car)?.FillUp(2);
        }

    }

    public class ClassWithStaticConstructor
    {
        //Static variable that must be initialized at run time.
        static readonly long baseline;

        //Static constructor is called at most one time,
        //before any instance constructor is invoked or
        //member is accessed.
        static ClassWithStaticConstructor()
        {
            baseline = DateTime.Now.Ticks;
        }
    }

    public interface ITransport
    {
        double MileAge { get; set; }
        void Move(double km);
    }

    public class Car : ITransport
    {
        public double MileAge { get; set; }
        public double Fuel { get; set; }

        public void Move(double km)
        {
            this.MileAge += km;
        }

        public void FillUp(double liters)
        {
            this.Fuel += liters;
        }
    }

    public class Marine : ITransport
    {
        public double MileAge { get; set; }
        public double Draft { get; set; }

        public void Move(double km)
        {
            this.MileAge += km;
        }
    }

}
