using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace BankKata
    {
    public class OutputWriter
    {
        public virtual void Print(string output)
        {
            Console.WriteLine(output);
        }
    }
}
