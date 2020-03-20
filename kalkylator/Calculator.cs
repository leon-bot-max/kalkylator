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

        public void operatorPressed(char op, bool changeOperator = false)
        {
            //1 + 1 +2 -3s
            Console.WriteLine(result + " " + prevOperator + " " + operand);

            if (changeOperator)
            {
                prevOperator = op;
                latestPress = "op";

                return;
            }

            if (latestPress == "op") // inte första gången man trycker på en operator
            {
                equals();
                updateDisplayOperand = true; //Vill skriva ut operand eftersom det är resultatet från förra uträkningen

                prevOperator = op;
                operand = result;
                result = 0;
                Console.WriteLine(result);
            }
            else //Man trycker på en operatör för första gången
            {
                prevOperator = op;
                operand = result;
                result = 0;
            }
            latestPress = "op";
           
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

        public void procent()
        {
            result /= 100;
        }


        public void sqrt()
        {
            if (result < 0)
            {
                error = true;
                return;
            }
            result = Math.Sqrt(result);
        }


        public void teckenByte()
        {
            result *= -1;
        }






    }
}
