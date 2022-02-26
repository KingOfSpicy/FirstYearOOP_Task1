using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP_CheWeiHsu_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Change the culture to get the "right" delimiter
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            bool stillMore = false;
            double amountOfLoan = -1.0;
            double annualInterestRate = -1.0;
            double monthlyInterestRate = 0;
            double monthlyPayment = 0;
            double totoalAmountPaid = 0;
            double totalInterestPaid = 0;
            int numberOfYears = -1;
            int numberOfPayments = 0;
            do
            {
                Console.Write("Enter the amount of loan:");
                //with ReadLine() you always get a string
                string receivedValue = Console.ReadLine();
                //Check the datatype first
                while (!Double.TryParse(receivedValue, out amountOfLoan) || amountOfLoan < 0)
                {
                    Console.Write("Not valid, try again: ");
                    receivedValue = Console.ReadLine();
                }
                Console.WriteLine("You gave " + amountOfLoan + " as amount of loan."); 
                //記得要在上面加註是給了什麼!
                //新章節
                Console.Write("Enter the annual interest rate in decimal format: ");
                string receivedValue2;
                receivedValue2 = Console.ReadLine();
                //Check the datatype first
                while (!Double.TryParse(receivedValue2, out annualInterestRate) || annualInterestRate < 0)
                {
                    Console.Write("Not valid, try again: ");
                    receivedValue2 = Console.ReadLine();
                }
                Console.WriteLine("You gave " + annualInterestRate + " as annual interest rate.");
                //記得要在上面加註是給了什麼!
                //新章節
                Console.Write("Enter the number of year: ");
                string receivedValue3;
                receivedValue3 = Console.ReadLine();
                //Check the datatype first
                while (!Int32.TryParse(receivedValue3, out numberOfYears) || numberOfYears < 0)
                {
                    Console.Write("Not valid, try again: ");
                    receivedValue3 = Console.ReadLine();
                }
                Console.WriteLine("You gave " + numberOfYears + " as number of years.");
                //記得要在上面加註是給了什麼!
                //Monthly interest rate:
                monthlyInterestRate = annualInterestRate / 12;
                //How many months:
                numberOfPayments = 12 * numberOfYears;
                //calculate the amount of monthly payment:
                monthlyPayment = ((monthlyInterestRate * Math.Pow((1 + monthlyInterestRate), numberOfPayments))/ (Math.Pow((1 + monthlyInterestRate), numberOfPayments)-1)*amountOfLoan);
                //math.pow(double, double)指數方法，以上是作業中的所求算式
                //calculate the total amount paid to bank:
                totoalAmountPaid = numberOfPayments * monthlyPayment;
                //calculate total interest paid to bank:
                totalInterestPaid = totoalAmountPaid - amountOfLoan;
                
                //Inform user:
                Console.WriteLine("Loan amount: {0}", amountOfLoan);
                Console.WriteLine("Monthly interest rate: {0}", monthlyInterestRate);
                Console.WriteLine("Number of payments: {0}", numberOfPayments);
                Console.WriteLine("Monthly payment: {0:F2}", monthlyPayment);
                Console.WriteLine("Total amount paid to bank: {0:F3}", totoalAmountPaid);
                Console.WriteLine("Total interest paid to bank: {0:F3}", totalInterestPaid);
                //:F2可以使其數字四捨五入


                Console.Write("More loan values to process (Y/N)?: ");
                string moreOfThis = Console.ReadLine().ToUpper();
                if (moreOfThis.StartsWith("Y"))
                    stillMore = true;
                else if (moreOfThis.StartsWith("N"))
                    stillMore = false;
                else
                {
                    Console.WriteLine("Dear customer, we do not know you would like to continue or not, but we will shut down this window and thank you for using.");
                    stillMore = false;
                }



            } while (stillMore);
        }
    }
}
