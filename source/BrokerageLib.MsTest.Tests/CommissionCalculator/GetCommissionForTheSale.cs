using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SUT = BrokerageLib;

namespace BrokerageLib.MsTest.Tests.CommissionCalculator
{

	[TestClass]
	
	public class GetCommissionForTheSale_Should
	{
		// for this demo, this test method does not use
		// data parameters, see the financial tests for details
		// on how to use [DataRow] and [DynamicData] attributes
		[TestMethod]

		public void ReturnStandardCommission_WhenAmountsAreBelowThresholds()
		{
			// Arrange

			var unitsSold = 90;
			var unitPrice = 50.00M;
			var calculator = new SUT.CommissionCalculator();

			// Act
			decimal calculatedCommission = calculator.GetCommissionForTheSale(unitsSold, unitPrice);

			// Assert
			decimal expectedCommission = (unitsSold * unitPrice) *
																	 SUT.Constants.CommissionRate.Standard;
			Assert.AreEqual(expectedCommission, calculatedCommission);
		}

		[TestMethod]

		public void ReturnEpicCommission_WhenUnitAmountOverEpicThreshold()
		{
			// Arrange

			var unitsSold = 401;
			var unitPrice = 50.00M;
			var calculator = new SUT.CommissionCalculator();

			// Act
			decimal calculatedCommission = calculator.GetCommissionForTheSale(unitsSold, unitPrice);

			// Assert
			decimal expectedCommission = (unitsSold * unitPrice) *
																	 SUT.Constants.CommissionRate.Epic;
			Assert.AreEqual(expectedCommission, calculatedCommission);
		}

		[TestMethod]


		public void ReturnEpicCommission_WhenGrossSaleAmountOverEpicThreshold()
		{
			// Arrange

			var unitsSold = 101;
			var unitPrice = 150.00M;
			var calculator = new SUT.CommissionCalculator();

			// Act
			decimal calculatedCommission = calculator.GetCommissionForTheSale(unitsSold, unitPrice);

			// Assert
			decimal expectedCommission = (unitsSold * unitPrice) *
																	 SUT.Constants.CommissionRate.Epic;
			Assert.AreEqual(expectedCommission, calculatedCommission);
		}

		[TestMethod]
		public void ReturnEarnerCommission_WhenUnitAmountOverEarnerThreshold()
		{
			// Arrange

			var unitsSold = 401;
			var unitPrice = 1.00M;
			var calculator = new SUT.CommissionCalculator();

			// Act
			decimal calculatedCommission = calculator.GetCommissionForTheSale(unitsSold, unitPrice);

			// Assert
			decimal expectedCommission = (unitsSold * unitPrice) *
																	 SUT.Constants.CommissionRate.Earner;
			Assert.AreEqual(expectedCommission, calculatedCommission);
		}

		[TestMethod]

		public void ReturnEarnerCommission_WhenGrossSaleAmountOverEarnerThreshold()
		{
			// Arrange
			var unitsSold = 1;
			var unitPrice = 12_001.00M;
			var calculator = new SUT.CommissionCalculator();

			// Act
			decimal calculatedCommission = calculator.GetCommissionForTheSale(unitsSold, unitPrice);

			// Assert
			decimal expectedCommission = (unitsSold * unitPrice) *
																	 SUT.Constants.CommissionRate.Earner;
			Assert.AreEqual(expectedCommission, calculatedCommission);
		}


		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]

		public void ThrowArgumentOutOfRangeException_WhenNegativeUnitsSold()
		{
			// Arrange
			var unitsSold = -1;
			var unitPrice = 120.00M;
			var calculator = new SUT.CommissionCalculator();

			// Act
			decimal calculatedCommission = calculator.GetCommissionForTheSale(unitsSold, unitPrice);

			// Assert
			decimal expectedCommission = (unitsSold * unitPrice) *
																		SUT.Constants.CommissionRate.Epic;
			Assert.AreEqual(expectedCommission, calculatedCommission);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]

		public void ThrowArgumentOutOfRangeException_WhenNegativePrice()
		{
			// Arrange

			var unitsSold = 10;
			var unitPrice = -120.00M;
			var calculator = new SUT.CommissionCalculator();

			// Act
			decimal calculatedCommission = calculator.GetCommissionForTheSale(unitsSold, unitPrice);

			// Assert
			decimal expectedCommission = (unitsSold * unitPrice) *
																		SUT.Constants.CommissionRate.Epic;
			Assert.AreEqual(expectedCommission, calculatedCommission);
		}
	}
}