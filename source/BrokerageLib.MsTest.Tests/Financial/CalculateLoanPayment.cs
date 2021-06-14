using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using SUT = BrokerageLib;

namespace BrokerageLib.XUnit.Tests.Financial {
	[TestClass]
	public class CalculatePayment_Should {
		//[Theory]
		//[InlineData(0.07, 360, 120_000, 798.36)]
		[DataTestMethod]
		[DataRow(0.07, 360, 120_000, 798.36)]
		[TestCategory("Data Driven Test")]
		public void ReturnCorrectAnnualRate_GivenNormalParameters(double annualInterestRate, int durationInMonths, double loanAmount, double expectedMonthlyPayment) {
			// arrange
			var fin = new SUT.Financial();

			// act
			var calculatedMonthlyPayment = fin.CalculateLoanPayment((decimal)annualInterestRate, durationInMonths,(decimal) loanAmount);
			
			// floating point comparisons are tricky, use the delta parameter to test 
			// precise number of decimal places.
			Assert.AreEqual(expected: expectedMonthlyPayment, 
									actual: Math.Round((double)calculatedMonthlyPayment,2)
								);
		}
		
	}
}
