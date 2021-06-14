using System.Threading.Tasks;
using Xunit;
using SUT = BrokerageLib;

namespace BrokerageLib.XUnit.Tests.Financial {
	public class RateOfReturn_Should {
		[Theory]
		[InlineData(200.00, 250.00, 20.0, 0.35)]
		public  async void ReturnCorrectRate_GivenNormalParameters(decimal initialCost, decimal soldAmount, decimal dividendsEarned, decimal expectedRate) {
			// arrange
			var fin = new SUT.Financial();
			await Task.Delay(1400);
			// act
			var calculatedRate = fin.GetRateOfReturn(initialCost, soldAmount, dividendsEarned);

			Assert.Equal(expected: expectedRate, actual: calculatedRate);
		}
	}

}
