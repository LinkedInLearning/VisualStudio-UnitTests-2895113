using Xunit;
using SUT = BrokerageLib;

namespace BrokerageLib.XUnit.Tests.Financial {
	public class AnnualizedRateOfReturn_Should {
		[Theory]
		[InlineData(200.00, 250.00, 20.0, 2, 0.161895)]
		[Trait(name: "Category", value: "Theory-InlineData")]
		public void ReturnCorrectAnnualRate_GivenNormalParameters(decimal initialCost, decimal soldAmount, decimal dividendsEarned, int yearsHeld, decimal expectedRate) {
			// arrange
			var fin = new SUT.Financial();

			// act
			var calculatedRate = fin.GetAnnualizedRateOfReturn(initialCost, soldAmount, dividendsEarned, yearsHeld);
			// floating point comparisons are tricky, use the precision parameter to test 
			// precise number of decimal places.
			Assert.Equal(expected: expectedRate, 
										actual: calculatedRate, 
										precision: 6);
		}
	}

}
