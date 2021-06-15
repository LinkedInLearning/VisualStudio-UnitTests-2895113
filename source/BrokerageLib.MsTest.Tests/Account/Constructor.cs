using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUT = BrokerageLib;

namespace BrokerageLib.MsTest.Tests.Account {
	[TestClass]
	public class Constructor_Should
	{
		[TestMethod]
		[Ignore("Not working")]
		public void InitializeAccount_WhenCustomerInformationIsSupplied()
		{
			// if there is no logic in the constructor
			// you might choose to not test.  
			// this examples shows how to do a simple test
			// // for a parameterized constructor that sets properties

			// arrange
			decimal beginningBalance = 5.06M;
			string customerName = "Test Customer";


			// act
			SUT.Account account = new SUT.Account(customerName, beginningBalance);

			// assert
			Assert.IsNotNull(account); //verifies constructor created an instance!
			Assert.AreEqual(expected: customerName, actual: account.CustomerName);
			Assert.AreEqual(expected: beginningBalance, actual: account.Balance);
		}
	}
}
