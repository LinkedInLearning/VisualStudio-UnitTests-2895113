using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SUT = BrokerageLib;

namespace BrokerageLib.XUnit.Tests.Account {

	public class Debit_Should {
		public static string CUSTOMER_NAME = "Mr. Heltman Azon";
		[Fact]
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
			Assert.Equal(expected: expectedBalance, actual: balance);
		}
		//[Fact]
		////[ExpectedException(typeof(ArgumentOutOfRangeException))]
		//public void ThrowExceptionWhenOverdrawn_DuringDebitAction() {
		//	// arrange
		//	decimal beginningBalance = 12.05M;
		//	decimal debitAmount = 12.06M;

		//	SUT.Account account = new SUT.Account(CUSTOMER_NAME, beginningBalance);

		//	// act
		//// 	account.Debit(debitAmount);
		//		var argException = Assert.Throws<ArgumentOutOfRangeException>(() =>
		//			account.Debit(debitAmount));
		//	}

		[Fact]
		public void FreezeAccount_WhenNegativeBalanceBelowThreshold() {
			// arrange
			decimal beginningBalance = 1M;
			decimal debitAmount = Constants.AccountThresholds.FreezeBalance +1;

			SUT.Account account = new SUT.Account(CUSTOMER_NAME, beginningBalance);

			// act
			account.Debit(debitAmount);

			// assert

			Assert.True(account.AccountFrozen);

		}

		[Fact]

		public void ThrowException_WhenNegativeDebitAmount() {
			// arrange
			decimal beginningBalance = 12.05M;
			decimal debitAmount = -5.0M;

			SUT.Account account = new SUT.Account(CUSTOMER_NAME, beginningBalance);

			// act
			//account.Debit(debitAmount);

			var argException = Assert.Throws<ArgumentOutOfRangeException>(() =>
				account.Debit(debitAmount));

		}
	}
}
