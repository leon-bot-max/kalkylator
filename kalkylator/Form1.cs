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
        string resultString = "0";  //string av result i calc
        string operandString = "0"; // string av operand i calc

        bool lastPressedOperator = false;
        bool replaceCurrentNum = true; //Numret som står i resulString ska bytas ut om en siffra trycks

        public Form1()
        {
            InitializeComponent();
            updateDisplay();
            updateNumber2Display();
        }

        private void numberButtonListener(object sender, EventArgs e)
        {
            lastPressedOperator = false;



            Button senderButton = (Button)sender;
            nyttTal(senderButton.Text);
            updateDisplay();

        }

        private void mathButtonListener(object sender, EventArgs e)
        {




            Button senderButton = (Button)sender;



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
                    updateNumber2Display();                 
                }
                lastPressedOperator = false;
                return; //Gå ut ur funktion efter man inte vill kovertera till string. Då skulle kommatecknet försvinna
            }
            else if (sender == buttonPlus)
            {
                operatorPress('+');
                return;  //hoppa ut från funnktion efter varje operator eftersom lastPressedOperator blir false annars
            }
            else if (sender == buttonDiv)
            {
                operatorPress('/');
                return;
            }
            else if (sender == buttonMin)
            {
                operatorPress('-');
                return;
            }
            else if (sender == buttonMult)
            {
                operatorPress('*');
                return;
            }
            else if (sender == buttonEquals)
            {
                calc.equals();
                replaceCurrentNum = true;
            }
            else if (sender == buttonC) //Clear all
            {
                calc.clearAll();
            }
            else if (sender == buttonCE) //Clear på det du skriver på nu
            {
                calc.clearEntry();
                konverteraTillString();
                updateDisplay();
                updateNumber2Display();
                lastPressedOperator = true;
                return; //Return efter som man inte vill ändra  lastPressedOperator till false
            }
            else if (sender == buttonInverse)
            {
                calc.inverse();
            }
            else if (sender == buttonProcent)
            {
                calc.procent();
            }
            else if (sender == buttonPlusMinus)
            {
                calc.teckenByte();
            }
            else if (sender == buttonSqrt)
            {
                calc.sqrt();
            }
            lastPressedOperator = false;
            konverteraTillString();
            updateDisplay();
            updateNumber2Display();

        }
 

        private void operatorPress(char op)
        {
            calc.operatorPressed(op, lastPressedOperator);
            replaceCurrentNum = true;
            lastPressedOperator = true;

            if (calc.updateDisplayOperand) //Fall man trycker på operator många gånger är svaret från förra uträkning i operand
            {
                updateDisplay(true);
                calc.updateDisplayOperand = false;
            }

            konverteraTillString();
            updateDisplay();
            updateNumber2Display();
        }
        private void konverteraTillString()
        {
            resultString = calc.result.ToString();
            operandString = calc.operand.ToString();
        }


        private void koverteraTillResult()
        {
            if (resultString[resultString.Length - 1] == ',')
            {
                string r = resultString + "0";  //om det t.ex står 5, ändras det til 5,0
                calc.result = double.Parse(r);
            }
            else
                calc.result = double.Parse(resultString);



        }
        private void nyttTal(string tal)
        {
            if (tal == ",")
            {
                if (resultString == "" || replaceCurrentNum) //Det ska i detta fall skrivas 0,
                {
                    replaceCurrentNum = false;
                    resultString = "0";
                }
                resultString += tal;
                koverteraTillResult();
                return;
            }

            if (resultString == "0" || replaceCurrentNum)  //Resulstring ska helt bytas till tal
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
            if (replaceCurrentNum) //Om man trycker radera ett tal och hela talet ska replacas tas hela talet väck
            {
                resultString = "0";
                replaceCurrentNum = false;
            }
            else
            {
                char[] arrayNumbers = resultString.ToCharArray();
                string newNumberString = "";

                for (int i = 0; i < arrayNumbers.Length - 1; i++) //Lägger tillbaka alla siffror förutom den sista i result string
                {
                    newNumberString += arrayNumbers[i];
                }

                if (newNumberString == "")
                {
                    newNumberString = "0";
                }
                resultString = newNumberString;
            }
            koverteraTillResult();
            updateDisplay();
            updateNumber2Display();
        }

        private void updateDisplay(bool withOperand = false)
        {

            

            string attSkriva = resultString;
            /*
            int maxLängd = 10;
            if (attSkriva.Length > maxLängd)
            {
                attSkriva = attSkriva.Substring(0, maxLängd) + "...";
            }
            */
            if (withOperand)
            {
                attSkriva = operandString;
            }

            if (calc.error == true) //Visa att det är en error
            {
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
            if (calc.currentOperator == new char())
            {
                number2Display.Text = "";
                return;
            }
                
            if (calc.latestPress == "eq") //Om man senast tryckte lika med visar display2 hur talet i rutan kommer förändras
            {
                number2Display.Text = "x " + calc.currentOperator + " " + operandString;
                return;
            }
            number2Display.Text = operandString + " " + calc.currentOperator;
        }





    }
}

