using System;

namespace BrokerageLib {

	public class CommissionCalculator
	{
		// Business rule
		// There are three commission rates for sales reps

		// Sales rep earns Constants.CommissionRate.Epic commission rate
		// When sales total is greater than Constants.CommissionThreshold.EpicSalesAmount ($15,000)
		// or when units sold is greater than Constants.CommissionThreshold.EpicUnitAmount (600)

		// Sales rep earns Constants.CommissionRate.Earner commission rate
		// When sales total is greater than Constants.CommissionThreshold.EarnerSalesAmount ($12,000)
		// or when units sold is greater than Constants.CommissionThreshold.EarnerUnitAmount (400)


		public decimal GetCommissionForTheTransaction(int unitsSold, decimal unitPrice)
		{
			if (unitsSold < 0)
			{
				throw new ArgumentOutOfRangeException("UnitsSold cannot be less than zero.");
			}

			if (unitPrice < 0)
			{
				throw new ArgumentOutOfRangeException("unitPrice cannot be less than zero.");
			}

			decimal grossSale = unitsSold * unitPrice;

			if (grossSale >= Constants.CommissionThreshold.EpicSalesAmount || 
				  unitsSold >= Constants.CommissionThreshold.EpicUnitAmount)
			{
				return grossSale * Constants.CommissionRate.Epic;
			}
			else if (grossSale >= Constants.CommissionThreshold.EarnerSalesAmount || 
							 unitsSold >= Constants.CommissionThreshold.EarnerUnitAmount)
			{
				return grossSale * Constants.CommissionRate.Earner;
			}

			else
			{
				return grossSale * Constants.CommissionRate.Standard;
			}

		}
	}
	
}