using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GradebookDB
{
    class Reflection
    {
        public Reflection()
        {

            Console.WriteLine(Enumerable.Range(1, 1000).Where(a => a % 3 == 0 || a % 5 == 0).Sum());

        }



    }
}
