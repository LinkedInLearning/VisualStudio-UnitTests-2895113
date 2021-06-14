using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SUT = BrokerageLib;

namespace BrokerageLib.XUnit.Tests.Financial {
	[TestClass]
	public class RateOfReturn_Should {
		//[Theory]
		//[InlineData(200.00, 250.00, 20.0, 0.35)]
		[DataTestMethod]
		[DynamicData(nameof(GetRateOfReturnTestParameters), DynamicDataSourceType.Method)]
		public void ReturnCorrectRate_GivenNormalParameters(decimal initialCost, decimal soldAmount, decimal dividendsEarned, decimal expectedRate) {
			// arrange
			var fin = new SUT.Financial();

			// act
			var calculatedRate = fin.GetRateOfReturn(initialCost, soldAmount, dividendsEarned);

			Assert.AreEqual(expected: expectedRate, actual: calculatedRate);
		}
		private static IEnumerable<object[]> GetRateOfReturnTestParameters() {
			yield return new object[]
			{
				200.00M,
				250.00M,
				20.0M,
				0.35M
			};

		
			// Continue for each required test.
		}
	}

}
