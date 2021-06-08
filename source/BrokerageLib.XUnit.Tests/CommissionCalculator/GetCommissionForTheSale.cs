using System;
using System.Linq;
using Xunit;
using SUT = BrokerageLib;

namespace BrokerageLib.XUnit.Tests.CommissionCalculator {
	public class GetCommissionForTheSale_Should {
		// Theories are tests which are only true for a particular set of data.
		[Theory]
		[InlineData(1, 1.00)] // low units sold, low total sale
		[InlineData(399, 1)] // 1 below unit threshold (edge case)
		[InlineData(1, 11_999)] // 1 below sales threshold (edge case)
		public void ReturnStandardCommission_WhenAmountsAreBelowThresholds(int unitsSold, decimal unitPrice) {
			// Arrange
			var calculator = new SUT.CommissionCalculator();

			// Act
			decimal calculatedCommission = calculator.GetCommissionForTheSale(unitsSold, unitPrice);

			// Assert
			decimal expectedCommission = (unitsSold * unitPrice) *
																	 SUT.Constants.CommissionRate.Standard;
			Assert.Equal(expectedCommission, calculatedCommission);
		}


		[Theory]
		[InlineData(600, 1.00)]
		[InlineData(1, 15_000.00)]
		//[InlineData(1, 150.00)] //failing test
		public void ReturnEpicCommission_WhenAmountsOverEpicThreshold(int unitsSold, decimal unitPrice) {
			// Arrange
			var calculator = new SUT.CommissionCalculator();

			// Act
			decimal calculatedCommission = calculator.GetCommissionForTheSale(unitsSold, unitPrice);

			// Assert
			decimal expectedCommission = (unitsSold * unitPrice) *
																	 SUT.Constants.CommissionRate.Epic;
			Assert.Equal(expectedCommission, calculatedCommission);
		}



		[Theory]
		[InlineData(400, 1)]
		[InlineData(1, 12_000)]
		// [InlineData(601, 1)] // failing test
		public void ReturnEarnerCommission_WhenAmountsOverEarnerThreshold(int unitsSold, decimal unitPrice) {
			// Arrange
			var calculator = new SUT.CommissionCalculator();

			// Act
			decimal calculatedCommission = calculator.GetCommissionForTheSale(unitsSold, unitPrice);

			// Assert
			decimal expectedCommission = (unitsSold * unitPrice) *
																	 SUT.Constants.CommissionRate.Earner;
			Assert.Equal(expectedCommission, calculatedCommission);
		}



		[Fact]
		public void ThrowArgumentOutOfRangeException_WhenNegativeUnitsSold() {
			// Arrange
			var unitsSold = -1;
			var unitPrice = 120.00M;
			var calculator = new SUT.CommissionCalculator();

			// Act and Assert
			var argException = Assert.Throws<ArgumentOutOfRangeException>(() => calculator.GetCommissionForTheSale(unitsSold, unitPrice));
			Record.Exception(() => calculator.GetCommissionForTheSale(unitsSold, unitPrice));
		}
		[Fact]
		public void ThrowArgumentOutOfRangeException_WhenNegativePrice() {
			// Arrange

			var unitsSold = 10;
			var unitPrice = -120.00M;
			var calculator = new SUT.CommissionCalculator();

			// Act
			var argException = Record.Exception(() => calculator.GetCommissionForTheSale(unitsSold, unitPrice));

			// Assert

			Assert.NotNull(argException);
			Assert.IsType<ArgumentOutOfRangeException>(argException);
		}
	}
}
