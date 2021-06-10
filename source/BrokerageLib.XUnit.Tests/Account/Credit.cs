using System;
using Xunit;
using SUT = BrokerageLib;

namespace BrokerageLib.XUnit.Tests.Account {
	public class Credit_Should {
		public static string CUSTOMER_NAME = "Mr. Heltman Azon";
		[Fact]

		public void UpdateBalanceCorrectly_DuringCreditAction() {
			// arrange
			decimal beginningBalance = 5.06M;
			decimal depositAmount = 3.01M;
			decimal expectedBalance = 8.07M;
			SUT.Account account = new SUT.Account(CUSTOMER_NAME, beginningBalance);

			// act
			account.Credit(depositAmount);

			// assert
			decimal balance = account.Balance;
			Assert.Equal(expected: expectedBalance, actual: balance);

		}

		[Fact]
		[Trait(name: "Category", value: "Exceptions")]
		public void ThrowException_WhenNegativeCreditAmount() {
			// arrange
			decimal beginningBalance = 12.05M;
			decimal creditAmount = -5.0M;

			SUT.Account account = new SUT.Account(CUSTOMER_NAME, beginningBalance);

			// act and assert

			Assert.Throws<ArgumentOutOfRangeException>(() =>
				account.Credit(creditAmount));

		}

		[Fact]
		[Trait(name: "Freeze", value: "Thawing...")]
		public void UnfreezeAccount_WhenPositiveBalanceReached() {
			// arrange
			decimal beginningBalance = 1;
			decimal debitAmount = Constants.AccountThresholds.FreezeBalance + 1;

			decimal creditAmount = Constants.AccountThresholds.FreezeBalance + 2;

			SUT.Account account = new SUT.Account(CUSTOMER_NAME, beginningBalance);

			// act
			account.Debit(debitAmount);

			// assert
			Assert.True(account.AccountFrozen);

			// act
			account.Credit(creditAmount);
			// assert
			Assert.False(account.AccountFrozen);
		}

	}
}
