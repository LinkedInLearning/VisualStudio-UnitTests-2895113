using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SUT = BrokerageLib;

namespace BrokerageLib.XUnit.Tests.Account {
	public class Credit_Should {
		[Fact]
		public void UpdateBalanceCorrectly_DuringCreditAction() {
			// arrange
			decimal beginningBalance = 5.06M;
			decimal depositAmount = 3.01M;
			decimal expectedBalance = 8.07M;
			SUT.Account account = new SUT.Account("Test Customer", beginningBalance);

			// act
			account.Credit(depositAmount);	

		

			// assert
			decimal balance = account.Balance;
			Assert.Equal(expected: expectedBalance, actual: balance);

	

		}

	}
}
