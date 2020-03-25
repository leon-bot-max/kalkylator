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
        string resultString = "0";
        string operandString = "0";

        bool lastPressedOperator = false;
        bool replaceCurrentNum = true;

        public Form1()
        {
            InitializeComponent();
            display.Text = resultString;
            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void numberButtonListener(object sender, EventArgs e)
        {
            lastPressedOperator = false;
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
                lastPressedOperator = false;

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
                    lastPressedOperator = false;

                    return;
                }
                lastPressedOperator = false;

            }
            else if (sender == buttonPlus)
            {
                calc.operatorPressed('+', lastPressedOperator);
                replaceCurrentNum = true;
                lastPressedOperator = true;

            }
            else if (sender == buttonDiv)
            {
                calc.operatorPressed('/', lastPressedOperator);
                replaceCurrentNum = true;
                lastPressedOperator = true;

            }
            else if (sender == buttonMin)
            {
                calc.operatorPressed('-', lastPressedOperator);
                replaceCurrentNum = true;
                lastPressedOperator = true;

            }
            else if (sender == buttonMult)
            {
                calc.operatorPressed('*', lastPressedOperator);
                replaceCurrentNum = true;
                lastPressedOperator = true;

            }
            else if (sender == buttonEquals)
            {

                calc.equals();
                Console.WriteLine(calc.result + " " + calc.operand);
                konverteraTillString();
                updateDisplay();
                updateNumber2Display();
                replaceCurrentNum = true;
                lastPressedOperator = false;

                return;

            }
            else if (sender == buttonC) //Clear all
            {
                calc.clearAll();
                konverteraTillString();
                updateDisplay();
                updateNumber2Display();
                lastPressedOperator = false;

            }
            else if (sender == buttonCE) //Clear det du skriver på nu
            {
                calc.clearEntry();
                konverteraTillString();
                updateDisplay();
                updateNumber2Display();
                lastPressedOperator = false;

            }
            else if (sender == buttonInverse)
            {
                calc.inverse();
                konverteraTillString();
                updateDisplay();
                updateNumber2Display();
                lastPressedOperator = false;

            }
            else if (sender == buttonProcent)
            {
                calc.procent();
                konverteraTillString();
                updateDisplay();
                lastPressedOperator = false;

            }
            else if (sender == buttonPlusMinus)
            {
                calc.teckenByte();
                konverteraTillString();

                updateDisplay();
                lastPressedOperator = false;

            }
            else if (sender == buttonSqrt)
            {
                calc.sqrt();
                konverteraTillString();
                updateDisplay();
                lastPressedOperator = false;

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
            if (tal == ",")
            {
                if (resultString == "")
                {
                    resultString = "0";
                }
                resultString += tal;
                koverteraTillResult();
                return;

            }

            if (resultString == "0" || replaceCurrentNum)
            {
                replaceCurrentNum = false;
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
            //int maxLängd = 10;

            string attSkriva = resultString;

            //if (attSkriva.Length > maxLängd)
            //{
            //    attSkriva = attSkriva.Substring(0, maxLängd) + "...";
            //}
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
            if (calc.latestPress == "eq") //Om man senast tryckte lika med visar display2 hur talet i rutan kommer förändras
            {
                number2Display.Text = calc.prevOperator  + " " + operandString;
                return;

            }
            number2Display.Text = operandString + " " + calc.prevOperator;
        }





    }
}

