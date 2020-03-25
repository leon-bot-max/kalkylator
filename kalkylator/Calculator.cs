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
        public char currentOperator = new char();
        public string latestPress = ""; //eq = equal, op = operator, kolla bara senast tryck om man ignorerar nummber och 1/x osv.
        public double temp = 0;

        public bool error = false;
        public bool updateDisplayOperand = false;  //När man trycker en operator många gånger visas resultatet från förra i operand
        public void equals()
        {
            Console.WriteLine(result + " " + currentOperator + " " + operand);
            if (latestPress != "eq" && currentOperator != new char())
            {
                temp = result;
                result = operand;
                operand = temp;
                Console.WriteLine("temp = result");
            }


            Console.WriteLine(result + " " + currentOperator + " " + operand);


            switch (currentOperator)
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
            Console.WriteLine(result + " " + currentOperator + " " + operand);
            Console.WriteLine("Latest oress: " + latestPress + " co: " + changeOperator);

            if (changeOperator)//Kolla om den ända förändringen är att byta operator. 
            { 
                currentOperator = op;
                latestPress = "op";
                return;
            }

            if (latestPress == "op") // inte första gången man trycker på en operator
            {
                equals();

                currentOperator = op;
                operand = result;

                updateDisplayOperand = true; //Vill skriva ut operand eftersom det är resultatet från förra uträkningen

            }

            else //Man trycker på en operatör för första gången
            {
                currentOperator = op;
                operand = result;
            }
            latestPress = "op";
           
        }

        public void clearAll()
        {
            result = 0;
            operand = 0;
            currentOperator = new char();
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
            { //Kan inte dividera med 0
                error = true;
            }
        }

        public void procent()
        {
            result /= 100;
        }


        public void sqrt()
        {
            if (result < 0)  //Kan inte ta roten ur negativa tal
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
