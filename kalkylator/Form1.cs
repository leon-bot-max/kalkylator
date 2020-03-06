using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



/*
 ---------Att Göra------------------------
 0, <---?
 alla knappar
     
     
     
 */
namespace kalkylator
{
    public partial class Form1 : Form
    {



        Calculator calc = new Calculator();
        //double numberCalc1 = 0;
        string resultString = "";
        //double numberCalc2 = 0;
        string operandString = "";
        //string operattor = "None";
        //bool latestPressEqual = false;
        //double latestNumber = 0;
        //bool waitingForNum = true;

        public Form1()
        {
            InitializeComponent();

            //display.SelectionAlignment = HorizontalAlignment.Right;


            //numberString1 = numberCalc1.ToString();
            display.Text = resultString;


            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void numberButtonListener(object sender, EventArgs e)
        {
            //latestPressEqual = false;
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
            }
            else if (sender == buttonComma)
            {
                if (!resultString.Contains(","))
                {
                    nyttTal(",");
                    updateDisplay();
                    Console.WriteLine(resultString);
                }
            }
            else if (sender == buttonPlus)
            {
                calc.operatorPressed('+');

            }
            else if (sender == buttonDiv)
            {
                calc.operatorPressed('/');
            }
            else if (sender == buttonMin)
            {
                calc.operatorPressed('-');
            }
            else if (sender == buttonMult)
            {
                calc.operatorPressed('*');
            }
            else if (sender == buttonEquals)
            {
                calc.equals();
                konverteraTillString();
                updateDisplay();
            }
            konverteraTillString();
            //updateDisplay();
            updateNumber2Display();

        }
        /*

        private void equals()
        {
            konverteraTillDouble();

            Console.WriteLine(numberCalc2 + " " + numberCalc1 + " " + operattor + " " + latestPressEqual);
            if (latestPressEqual)
            {
                numberCalc2 = latestNumber;
            }
            if (operattor == "+")
                numberCalc2 += numberCalc1;
            else if (operattor == "-")
                numberCalc2 -= numberCalc1;
            else if (operattor == "*")
                numberCalc2 *= numberCalc1;
            else if (operattor == "/")
                numberCalc2 /= numberCalc1;


            //Trycker lika med 2 ggr ger problem

            double temp = numberCalc1;
            numberCalc1 = numberCalc2;
            if (!latestPressEqual)
            {
                latestNumber = temp;
            }
            //numberCalc2 = 0;
            //numberString2 = "";
            latestPressEqual = true;

            konverteraTillString();

        }


        private void operationPressed(string op)
        {

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


            
        }


        private void plus()
        {
            Console.Beep();

        }
       
        private void konverteraTillDouble()
        {
            Console.WriteLine(numberString2);
            numberCalc1 = Convert.ToDouble(numberString1);
            numberCalc2 = Convert.ToDouble(numberString2);
        }*/
        private void konverteraTillString()
        {
            /*
            numberString1 = numberCalc1.ToString();
            numberString2 = numberCalc2.ToString();
            if (numberString2 == "0")
            {
                numberString2 = "";
            }*/
            resultString = calc.result.ToString();
            operandString = calc.operand.ToString();

        } 
        private void nyttTal(string tal)
        {
            

            if (resultString == "0")
            {
                if (tal == ",")
                {
                    resultString += tal;
                    calc.result = double.Parse(resultString);
                    return;
                }
                resultString = tal;
                calc.result = double.Parse(resultString);
                return;
            }
            resultString += tal;
            calc.result = double.Parse(resultString);

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
            calc.result = double.Parse(resultString);

            updateDisplay();
            updateNumber2Display();




        }

        private void updateDisplay()
        {

            display.Text = resultString;
            display.SelectionAlignment = HorizontalAlignment.Right;

        }

        private void updateNumber2Display()
        {
            number2Display.Text = operandString + " " + calc.prevOperator;
        }





    }
}
