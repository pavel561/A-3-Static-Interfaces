using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_3_Static_Interface
{
    public partial class Lesson
    {  
        public static void SurfaceExample()
        {
            SampleClass sc = new SampleClass();
            IControl ctrl = (IControl)sc;
            ISurface srfc = (ISurface)sc;

            // The following lines all call the same method.
            sc.Paint();
            ctrl.Paint();
            srfc.Paint();
        }
    }   

    interface IControl
    {
        void Paint();
    }

    interface ISurface
    {
        void Paint();
    }

    class SampleClass : IControl, ISurface
    {
        // Both ISurface.Paint and IControl.Paint call this method. 
        public void Paint()
        {
            Console.WriteLine("Paint method in SampleClass");
        }
    }
    
}
