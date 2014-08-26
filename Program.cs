using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDisposingAndDeconstructionSample
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("--Disposing and Deconstructing sample by Omar Ajerray 2014--");
            Console.WriteLine("Opening in cmd/Powershell/etc. will stop the window from closing before showing the deconstruction messages.");
            
            TestClass tcUpper = new TestClass("tc A");
            
            //using sample which disposes automatically after leaving the using.
            using (TestClass tc = new TestClass("tc B"))
            {
                tc.Action();
            }

            tcUpper.Action();
            
            using (TestClass tc = new TestClass("tc C"))
            {
                tc.Action();
            }

            tcUpper.Dispose();   
        }

        public static void PrintContinue()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey(true);
        }
    }

    class TestClass : IDisposable
    {
        private string Name { set; get; }

        public TestClass(string argName)
        {
            this.Name = argName;

            Console.WriteLine("Constructing class \"{0}\"!", this.Name);
            Program.PrintContinue();            
        }

        ~TestClass()
        {
            Console.WriteLine("Deconstructing class \"{0}\"!", this.Name);
            Program.PrintContinue();
        }

        public void Dispose()
        {
            Console.WriteLine("Disposing class \"{0}\"!", this.Name);
            Program.PrintContinue();
        }

        public void Action()
        {
            Console.WriteLine("Action in \"{0}\"!", this.Name);
            Program.PrintContinue();
        }    
    }
}
