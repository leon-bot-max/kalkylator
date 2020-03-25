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
        public void equals()
        {
            if (latestPress != "eq" && currentOperator != new char()) //Om man trycker på "=" första gågnen ska result = operand, och operand = result
            {                                                         // eftersom result är det senaste man skrev in och det som står på displayn
                temp = result;
                result = operand;
                operand = temp;
            }


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
                    if (operand == 0)  //Man kan inte dividera med 0
                    {
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


        public void operatorPressed(char op, bool changeOperator = false)
        {

            if (changeOperator)//Kolla om den ända förändringen är att byta operator. 
            {
                if (currentOperator == op)  //Om man trycker på samma operator 2 gånger tar man bort den
                    currentOperator = new char();
                else
                    currentOperator = op;

                latestPress = "op";
                return;
            }

            if (latestPress == "op") // inte första gången man trycker på en operator, man har t.ex. tryckt "5 + 5 + "
                equals(); //Räknar ut det man tryckte in innan t.ex 5+5, result = 10


            
            currentOperator = op;
            operand = result; //Result är antingen det som stod på skärmen eller det som räknades ut av equals om latestPress = "op"
                              //och sparas i operand så att nytt tal kan skrivas in
            
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
