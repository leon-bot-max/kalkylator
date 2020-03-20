using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace kalkylator
{
    public partial class Form1 : Form
    {



        Calculator calc = new Calculator();
        string resultString = "";
        string operandString = "";

        bool lastPressedNum = false;
    

        public Form1()
        {
            InitializeComponent();
            display.Text = resultString;
            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void numberButtonListener(object sender, EventArgs e)
        {
            lastPressedNum = true;
            //latestPressEqual = false;
            if (calc.latestPress == "eq")   //Ta väck nuvarande operator
            {
                Console.WriteLine("eq was katest");
                calc.prevOperator = new char();
                calc.operand = 0;
            }


            //calc.latestPress = "num";
            Button senderButton = (Button)sender;
            nyttTal(senderButton.Text);
            updateDisplay();

        }

        private void mathButtonListener(object sender, EventArgs e)
        {




            Button senderButton = (Button)sender;

            /*
            if (senderButton != buttonEquals)
            {
                latestPressEqual = false;
            }
            */

            if (sender == buttonDel)
            {
                raderaTal();
                lastPressedNum = false;

            }
            else if (sender == buttonComma)
            {
                if (!resultString.Contains(","))
                {
                    nyttTal(",");
                    updateDisplay();
                    Console.WriteLine(resultString);
                    updateDisplay();
                    updateNumber2Display();
                    lastPressedNum = false;

                    return;
                }
                lastPressedNum = false;

            }
            else if (sender == buttonPlus)
            {
                calc.operatorPressed('+', !lastPressedNum);
                lastPressedNum = false;

            }
            else if (sender == buttonDiv)
            {
                calc.operatorPressed('/', !lastPressedNum);
                lastPressedNum = false;

            }
            else if (sender == buttonMin)
            {
                calc.operatorPressed('-', !lastPressedNum);
                lastPressedNum = false;

            }
            else if (sender == buttonMult)
            {
                calc.operatorPressed('*', !lastPressedNum);
                lastPressedNum = false;

            }
            else if (sender == buttonEquals)
            {
                if (!lastPressedNum && calc.latestPress != "eq" && calc.prevOperator != new char()) //Om man trycker lika med efter tryckt på t.ex / ska man dividera med talet själv
                {
                    calc.result = calc.operand;
                }
                calc.equals();
                Console.WriteLine("result " + " " + calc.result);
                konverteraTillString();
                updateDisplay();
                updateNumber2Display();
                resultString = "0";
                lastPressedNum = false;

                return;

            }
            else if (sender == buttonC) //Clear all
            {
                calc.clearAll();
                konverteraTillString();
                updateDisplay();
                updateNumber2Display();
                lastPressedNum = false;

            }
            else if (sender == buttonCE) //Clear det du skriver på nu
            {
                calc.clearEntry();
                konverteraTillString();
                updateDisplay();
                updateNumber2Display();
                lastPressedNum = false;

            }
            else if (sender == buttonInverse)
            {
                calc.inverse();
                konverteraTillString();
                updateDisplay();
                updateNumber2Display();
            }
            else if (sender == buttonProcent)
            {
                calc.procent();
                konverteraTillString();
                updateDisplay();
            }
            else if (sender == buttonPlusMinus)
            {
                calc.teckenByte();
                konverteraTillString();

                updateDisplay();
            }
            else if (sender == buttonSqrt)
            {
                calc.sqrt();
                konverteraTillString();
                updateDisplay();
            }
            konverteraTillString();
            if (calc.updateDisplayOperand)
            {
                Console.WriteLine("calc.update " + calc.result + " operand: " + calc.operand);
                updateDisplay(true);
                calc.updateDisplayOperand = false;
            }
            Console.WriteLine("result " + " " + calc.result);

            //updateDisplay();
            //konverteraTillString();
            //updateDisplay();
            konverteraTillString();
            updateNumber2Display();


        }
 
        private void konverteraTillString()
        {
            
            resultString = calc.result.ToString();
            operandString = calc.operand.ToString();
            Console.WriteLine("Till string");

        }


        private void koverteraTillResult()
        {
            if (resultString[resultString.Length - 1] == ',')
            {
                Console.WriteLine(resultString + "  --<-<- resultString innan +0");
                string r = resultString + "0";
                calc.result = double.Parse(r);
                Console.WriteLine("Efter parse: " + double.Parse(r));
            }
            else
                calc.result = double.Parse(resultString);



        }
        private void nyttTal(string tal)
        {
            if (tal == "," && resultString == "")
            {

                resultString += "0" + tal;
                koverteraTillResult();
                return;

            }

            if (resultString == "0")
            {

                resultString = tal;
                koverteraTillResult();
                return;
            }
            resultString += tal;
            koverteraTillResult();

        }
        private void raderaTal()
        {
            char[] arrayNumbers = resultString.ToCharArray();
            string newNumberString = "";

            for (int i = 0; i < arrayNumbers.Length - 1; i++)
            {
                newNumberString += arrayNumbers[i];
            }
            if (newNumberString == "")
            {
                newNumberString = "0";
            }
            resultString = newNumberString;
            koverteraTillResult();

            updateDisplay();
            updateNumber2Display();




        }

        private void updateDisplay(bool withOperand = false)
        {

            //konverteraTillString();


            string attSkriva = resultString;
            if (withOperand)
            {
                attSkriva = operandString;
            }

            if (calc.error == true)
            {
                Console.WriteLine("Error found");
                display.Text = "Fel";
                display.SelectionAlignment = HorizontalAlignment.Right;
                calc.clearAll();
                return;
            }
            display.Text = attSkriva;
            display.SelectionAlignment = HorizontalAlignment.Right;

        }

        private void updateNumber2Display()
        {
            //konverteraTillString();
            number2Display.Text = operandString + " " + calc.prevOperator;
        }





    }
}

