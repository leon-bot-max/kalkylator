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
        public string latestPress = ""; //eq = equal, op = operator, num = number
        public double temp = 0;

        public bool error = false;
        public bool updateDisplayOperand = false;
        public void equals()
        {
            Console.WriteLine(result + " " + prevOperator + " " + operand);
            if (latestPress != "eq" && prevOperator != new char())
            {
                temp = result;
                result = operand;
                operand = temp;
                Console.WriteLine("temp = result");
            }
            //double temp = result;
            //temp = result;

            Console.WriteLine(result + " " + prevOperator + " " + operand);


            switch (prevOperator)
            {
                case '*':
                    result *= operand;// * result;
                    break;
                case '+':
                    result += operand;// + result;
                    break;
                case '-':
                    result -= operand;// - result;
                    break;
                case '/':
                    if (operand == 0)
                    {
                        Console.WriteLine("Div by zero");
                        error = true;
                    }
                    else
                    {
                        result /= operand;// / result;
                    }
                    break;

            }

            latestPress = "eq";


        }

        public void operate()
        {

        }

        public void operatorPressed(char op)
        {
            //1 + 1 +2 -3s
            Console.WriteLine(result + " " + prevOperator + " " + operand);


            if (latestPress == "op")
            {
                equals();
                updateDisplayOperand = true;
                //skriv result nu

                prevOperator = op;
                operand = result;
                result = 0;
                Console.WriteLine(result);
            }
            else
            {
                prevOperator = op;
                operand = result;
                result = 0;
            }
            latestPress = "op";
            /*
            Console.WriteLine(numberCalc2 + " " + numberString2);
            if (operattor == "None")
                operattor = op;


            if (numberString2 != "" && numberString2 != "0")
            {
                equals();
                updateNumber2Display();
                updateDisplay();
            }

            operattor = op;

            numberString2 = numberString1;
            numberString1 = "0";
            updateNumber2Display();

    */
        }

        public void clearAll()
        {
            result = 0;
            operand = 0;
            prevOperator = new char();
            latestPress = "";
            temp = 0;
            error = false;

        }

        public void clearEntry()
        {
            result = 0;
        }
        public void inverse()
        {
            if (result != 0)
            {
                result = 1 / result;
            }
            else
            {
                error = true;
            }
        }









    }
}
