using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SUT = BrokerageLib;

namespace BrokerageLib.XUnit.Tests.Account
{
	public class Constructor_Should
	{
		[Fact]
		public void InitializeAccount_WhenCustomerInformationIsSupplied()
		{
			// arrange
			decimal beginningBalance = 5.06M;
			string customerName = "Test Customer";


			// act
			SUT.Account account = new SUT.Account(customerName, beginningBalance);

			// assert

			Assert.Equal(expected: customerName, actual: account.CustomerName);
			Assert.Equal(expected: beginningBalance, actual: account.Balance);
		}
	}
}
