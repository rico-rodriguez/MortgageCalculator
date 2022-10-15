namespace MortgageCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var loanAmount = 0.0;
            var interestRate = 2.5;
            var loanTerm = 30.0;
            var monthlyPayment = 0.0;
            var buyerIncome = 0.0;

            var purchasePrice = 0.0;
            var marketValue = 0.0;
            var downPayment = 0.0;
            var propertyTax = 1.25;
            var insurance = 0.0;
            var hoa = 0.0;
            var originationFee = 1.0;
            var taxAndClosingCosts = 2500.0;

            var hoaSet = 0.0;
            bool success = false;

            Console.WriteLine("Let's see if you qualify!");
            Console.WriteLine("We will be calculating for a [fixed rate] loan.");
            Console.WriteLine("");

            Console.WriteLine("Please enter the [Income] of the buyer: ");
            buyerIncome = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please enter the [market value]");
            marketValue = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please enter the [purchase price]");
            purchasePrice = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please enter the [down payment]");
            downPayment = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please enter the [interest rate]");
            interestRate = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please enter the [loan term]");
            loanTerm = Convert.ToDouble(Console.ReadLine());


            while (!success)
            {
                Console.WriteLine("If there are [HOA fees] please enter 1, if not enter 0");
                hoaSet = Convert.ToDouble(Console.ReadLine());

                if (hoaSet == 1)
                {
                    Console.WriteLine("Enter your Yearly HOA fee:");
                    hoa = Convert.ToDouble(Console.ReadLine());
                    hoa = (hoa / 12);
                    success = true;
                }
                else if (hoaSet == 0)
                    break;
                else
                {
                    Console.WriteLine("You have to enter an option to continue...");
                    continue;
                }
            }

           

            //Calculate total loan value
            loanAmount = (purchasePrice - downPayment) / 100 * (100 + originationFee) + taxAndClosingCosts;
            Console.WriteLine("Loan Amount: {0:C2}", loanAmount);

            //Curent equity value
            var currentEquityValue = (marketValue - loanAmount);

            var equityPercentage = currentEquityValue / marketValue * 100;
            Console.WriteLine("Equity percentage: " + Math.Round(equityPercentage, 2) + "%");

            ////display equity percentage
            //var equityPercentage = ((marketValue - purchasePrice) + downPayment) / marketValue * 100;
            //Console.WriteLine("Equity percentage: " + equityPercentage);


            //Calculate loan insurance
            if (equityPercentage < 10)
            {
                insurance = (loanAmount * .01) / 12;
                Console.WriteLine("Loan Insurance [required] at a rate of: {0:C2}", insurance);
            }



            // rate of interest and number of payments for monthly payments
            var rateOfInterest = interestRate / 1200;
            var numberOfPayments = loanTerm * 12;

            var monthlyPaymentDue = (rateOfInterest * loanAmount) / (1 - Math.Pow(1 + rateOfInterest, numberOfPayments * -1));


            var buyerIncomeInMonths = ((buyerIncome / 12) / 100) * 25;
            //System.Console.WriteLine("Buyer income in months {0:C2}", buyerIncomeInMonths);

            //Determine if payment is >=25% of income and approve or deny loan based on that result 
            if (monthlyPaymentDue >= (buyerIncomeInMonths))
            {
                Console.WriteLine("Loan [Denied!] Placing more money down and Look at buying a more affordable home.");
            }
            else
            {
                Console.WriteLine("You have been [approved] for a loan.");
            }

            propertyTax = ((propertyTax * loanAmount)/ loanTerm) / 12;

            Console.WriteLine("HOA Dues will be {0:C2}", hoa);
            Console.WriteLine("Origination fee will be {0:C2}", (purchasePrice - downPayment) * .01);
            Console.WriteLine("Closing costs will be {0:C2}", 2500.00);
            Console.WriteLine("You will have a monthly Payment of: {0:C2}", monthlyPaymentDue);
            Console.WriteLine("Taxes and Escrow due: {0:C2}", + (hoa+propertyTax));
        }
    }
}

