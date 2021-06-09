using Xunit;
using SUT = BrokerageLib;

namespace BrokerageLib.XUnit.Tests.Financial {
	public class CalculatePayment_Should {
		[Theory]
		[InlineData(0.07, 360, 120_000, 798.36)]

		public void ReturnCorrectAnnualRate_GivenNormalParameters(decimal annualInterestRate, int durationInMonths, decimal loanAmount, decimal expectedMonthlyPayment) {
			// arrange
			var fin = new SUT.Financial();

			// act
			var calculatedMonthlyPayment = fin.CalculateLoanPayment(annualInterestRate, durationInMonths, loanAmount);
			// floating point comparisons are tricky, use the precision parameter to test 
			// precise number of decimal places.
			Assert.Equal(expected: expectedMonthlyPayment, 
									actual: calculatedMonthlyPayment, 
									precision: 2);
		}
	}
}
