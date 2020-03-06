using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalkylator
{
    class Calculator
    {

        public double result = 0;
        public double operand = 0;
        public char prevOperator = new char();

        public void equals()
        {
            Console.WriteLine(result + " " + prevOperator + " " + operand);
            double temp = result;
            if (prevOperator == '*')
                result = operand * result;

            //operand = temp;
        }

        public void operate()
        {

        }

        public void operatorPressed(char op)
        {
            //1 + 1 +2 -3s
            Console.WriteLine(result + " " + prevOperator + " " + operand);

            prevOperator = op;
            operand = result;
            result = 0;
            equals();

        }

        public void clearAll()
        {

        }









    }
}
