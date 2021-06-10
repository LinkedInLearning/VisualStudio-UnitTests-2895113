using System;
using System.Collections.Generic;
using Xunit;
using SUT = BrokerageLib;

namespace BrokerageLib.XUnit.Tests.CommissionCalculator {
	public class GetCommissionForTheSale_Should {

		// Theories are tests which are only true for a particular set of data.
		// old method signature
		// public void ReturnStandardCommission_WhenAmountsAreBelowThresholds(int unitsSold, decimal unitPrice)

		[Theory]
		[ClassData (typeof(TestData.CommissionStandardParameters))]
		[Trait(name: "Category", value: "Theory-ClassData")]
		[Trait(name: "Sprint", value: "12")]
		public void ReturnStandardCommission_WhenAmountsAreBelowThresholds(TestData.CommissionTestModel model) {
			// Arrange
			var calculator = new SUT.CommissionCalculator();

			// Act
			decimal calculatedCommission = calculator.GetCommissionForTheSale(model.UnitsSold, model.UnitPrice);

			// Assert
			decimal expectedCommission = (model.UnitsSold * model.UnitPrice) *
																	 SUT.Constants.CommissionRate.Standard;
			Assert.Equal(expected: expectedCommission, actual: calculatedCommission);
		}


		[Theory]
		[InlineData(600, 1.00)]
		[InlineData(1, 15_000.00)]
		
		[Trait(name: "Category", value: "Theory-InlineData")]
		public void ReturnEpicCommission_WhenAmountsOverEpicThreshold(int unitsSold, decimal unitPrice) {
			// Arrange
			var calculator = new SUT.CommissionCalculator();

			// Act
			decimal calculatedCommission = calculator.GetCommissionForTheSale(unitsSold, unitPrice);

			// Assert
			decimal expectedCommission = (unitsSold * unitPrice) *
																	 SUT.Constants.CommissionRate.Epic;
			Assert.Equal(expected: expectedCommission, actual: calculatedCommission);
		}



		[Theory]
		[InlineData(400, 1)]
		[InlineData(1, 12_000)]
	
		[Trait(name: "Category", value: "Theory-InlineData")]
		public void ReturnEarnerCommission_WhenAmountsOverEarnerThreshold(int unitsSold, decimal unitPrice) {
			// Arrange
			var calculator = new SUT.CommissionCalculator();

			// Act
			decimal calculatedCommission = calculator.GetCommissionForTheSale(unitsSold, unitPrice);

			// Assert
			decimal expectedCommission = (unitsSold * unitPrice) *
																	 SUT.Constants.CommissionRate.Earner;
			Assert.Equal(expected: expectedCommission, actual: calculatedCommission);
		}


		[Fact]
		[Trait(name: "Category", value: "Exceptions")]
		public void ThrowArgumentOutOfRangeException_WhenNegativeUnitsSold() {
			// Arrange
			var unitsSold = -1;
			var unitPrice = 120.00M;
			var calculator = new SUT.CommissionCalculator();

			// Act and Assert happens in same line
			// We assert that an ArgumentOutOfRangeException is thrown in the MUT
			Assert.Throws<ArgumentOutOfRangeException>(() => calculator.GetCommissionForTheSale(unitsSold, unitPrice));

			// optional, capture the exception (but use Record.Exception instead).
			var argException = Assert.Throws<ArgumentOutOfRangeException>(() => calculator.GetCommissionForTheSale(unitsSold, unitPrice));


		}
		[Fact]
		[Trait(name: "Category", value: "Exceptions")]
		public void ThrowArgumentOutOfRangeException_WhenNegativePrice() {
			// Arrange

			var unitsSold = 10;
			var unitPrice = -120.00M;
			var calculator = new SUT.CommissionCalculator();

			// Act
			// Record.Exception does not assert anything
			// It gathers any exception, if thrown.
			// Returns null if no exceptions
			var argException = Record.Exception(() => calculator.GetCommissionForTheSale(unitsSold, unitPrice));

			// Assert
			// Now we can assert whatever we need to with the captured information
			Assert.NotNull(argException);
			Assert.IsType<ArgumentOutOfRangeException>(argException);
		}
	}
}
