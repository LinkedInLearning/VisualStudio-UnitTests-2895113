using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUT = BrokerageLib;

namespace BrokerageLib.XUnit.Tests.Account {

	[TestClass]
	public class Debit_Should {
		public static string CUSTOMER_NAME = "Mr. Heltman Azon";
		[TestMethod]
		public void UpdateBalanceCorrectly_DuringDebitAction() {
			// arrange	
			decimal beginningBalance = 12.05M;
			decimal debitAmount = 2.02M;
			decimal expectedBalance = 10.03M;
			SUT.Account account = new SUT.Account(CUSTOMER_NAME, beginningBalance);

			// act
			account.Debit(debitAmount);

			// assert
			decimal balance = account.Balance;
			Assert.AreEqual(expected: expectedBalance, actual: balance);
		}

		[TestMethod]
		[TestCategory("Freeze (Chilling...)")]
		public void FreezeAccount_WhenNegativeBalanceBelowThreshold() {
			// arrange
			decimal beginningBalance = 1M;
			decimal debitAmount = SUT.Constants.AccountThresholds.FreezeBalance + 1;

			SUT.Account account = new SUT.Account(CUSTOMER_NAME, beginningBalance);

			// act
			account.Debit(debitAmount);

			// assert

			Assert.IsTrue(account.AccountFrozen);

		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[TestCategory("Exceptions")]
		public void ThrowException_WhenNegativeDebitAmount() {
			// arrange
			decimal beginningBalance = 12.05M;
			decimal debitAmount = -5.0M;

			SUT.Account account = new SUT.Account(CUSTOMER_NAME, beginningBalance);

			// act
			account.Debit(debitAmount);

		

		}
	}
}
