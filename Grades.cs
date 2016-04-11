using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradebookDB
{
    class Grades
    {
        public int getAverage(int a, int b, int c)
        {
            int d = (a + b + c) / 3;
            return d;
        }

        public char getLetterGrade(int a)
        {
            if (a >= 90 && a <= 100)
            {
                a = Convert.ToChar('A');
            }
            else if (a >= 80 && a <= 89)
            {
                a = Convert.ToChar('B');
            }
            else if (a >= 70 && a <= 79)
            {
                a = Convert.ToChar('C');
            }
            else if (a >= 60 && a <= 69)
            {
                a = Convert.ToChar('D');
            }
            else
            {
                a = Convert.ToChar('F');
            }
            return Convert.ToChar(a);
        }
    }
}
