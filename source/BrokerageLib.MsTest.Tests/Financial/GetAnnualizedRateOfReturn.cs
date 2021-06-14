using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SUT = BrokerageLib;

namespace BrokerageLib.XUnit.Tests.Financial {
	[TestClass]
	public class AnnualizedRateOfReturn_Should {
		//[Theory]
		//[InlineData(200.00, 250.00, 20.0, 2, 0.161895)]

		//MSTEST cannot use Decimal in datarow 
		// unless in .NET Core projects
		// change test method paramters to double, then convert in method
	
		[DataTestMethod]
		[DataRow(200.00, 250.00, 20.00, 2, 0.161895)]
		[TestCategory("Data Driven Test")]
		public void ReturnCorrectAnnualRate_GivenNormalParameters(double initialCost, double soldAmount, double dividendsEarned, int yearsHeld, double expectedRate) {
			// arrange
			var fin = new SUT.Financial();

			// act
			var calculatedRate = fin.GetAnnualizedRateOfReturn((decimal)initialCost, (decimal)soldAmount, (decimal)dividendsEarned, yearsHeld);
			// floating point comparisons are tricky, use the precision parameter to test 
			// precise number of decimal places.
			//Assert.Equal(expected: expectedRate, 
			//							actual: calculatedRate, 
			//							precision: 6);

			Assert.AreEqual(expected: expectedRate,
									actual: Math.Round((double)calculatedRate,6));
		}
	}

}
