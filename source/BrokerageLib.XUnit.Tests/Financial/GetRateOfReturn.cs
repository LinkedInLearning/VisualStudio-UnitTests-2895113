using Xunit;
using SUT = BrokerageLib;

namespace BrokerageLib.XUnit.Tests.Financial {
	public class RateOfReturn_Should {
		[Theory]
		[InlineData(200.00, 250.00, 20.0, 0.35)]
		[Trait(name: "Category", value: "Theory-InlineData")]
		public void ReturnCorrectRate_GivenNormalParameters(decimal initialCost, decimal soldAmount, decimal dividendsEarned, decimal expectedRate) {
			// arrange
			var fin = new SUT.Financial();

			// act
			var calculatedRate = fin.GetRateOfReturn(initialCost, soldAmount, dividendsEarned);

			Assert.Equal(expected: expectedRate, actual: calculatedRate);
		}
	}

}
