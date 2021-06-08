using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerageLib
{
	public class Financial
	{
		public decimal GetRateOfReturn(decimal initialCost, decimal soldAmount, decimal dividendsEarned)
		{
			//  (soldAmount + dividendsEarned - initialCost) / initialCost
			// = (($250 + $20 – $200) / $200) x 100 = 35%
			//  no guard clauses or exceptions for parameters in this example

			return (soldAmount + dividendsEarned - initialCost) / initialCost;
		}

		public decimal GetAnnualizedRateOfReturn(decimal initialCost, decimal soldAmount, decimal dividendsEarned, int yearsHeld)
		{
			// simple formula is wrong
			// GetRateOfReturn(initialCost, soldAmount, dividendsEarned) / yearsHeld;
			// instead of dividing by  years held
			// it should be (x)  to power 1/yearsHeld
			var calculatedReturn = (soldAmount + dividendsEarned) / initialCost;

			return (decimal)Math.Pow((double)calculatedReturn, (.5)) - 1;

		}
		public decimal CalculateLoanPayment(decimal annualInterestRate, int durationInMonths, decimal loanAmount)
		{

			decimal monthlyRate = (decimal)annualInterestRate / 12;
			decimal denominator =(decimal) Math.Pow((1 + (double) monthlyRate), durationInMonths) - 1;

			return (monthlyRate + (monthlyRate / denominator)) * loanAmount; ;
		}


	}
}
