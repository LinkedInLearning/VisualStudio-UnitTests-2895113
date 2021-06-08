using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SUT = BrokerageLib;

namespace BrokerageLib.XUnit.Tests.Account {

	public class Debit_Should {
		public const String CUSTOMER_NAME = "Mr. Heltman Azon";
		[Fact]
		public void UpdateBalanceCorrectly_DuringDebitAction() {
		// arrange
		decimal beginningBalance = 12.05M;
		decimal debitAmount = 2.02M;
		decimal expected = 10.03M;
		SUT.Account account = new SUT.Account(CUSTOMER_NAME, beginningBalance);

		// act
		account.Debit(debitAmount);

		// assert
		decimal actual = account.Balance;
		Assert.Equal(expected, actual);
	}
	[Fact]
	//[ExpectedException(typeof(ArgumentOutOfRangeException))]
	public void ThrowExceptionWhenOverdrawn_DuringDebitAction() {
		// arrange
		decimal beginningBalance = 12.05M;
		decimal debitAmount = 12.06M;

		SUT.Account account = new SUT.Account(CUSTOMER_NAME, beginningBalance);

		// act
	// 	account.Debit(debitAmount);
			var argException = Assert.Throws<ArgumentOutOfRangeException>(() =>
				account.Debit(debitAmount));
		}

	[Fact]
	//[ExpectedException(typeof(ArgumentOutOfRangeException))]
	public void ThrowException_WhenNegativeDebitAmount() {
		// arrange
		decimal beginningBalance = 12.05M;
		decimal debitAmount = -5.0M;

		SUT.Account account = new SUT.Account(CUSTOMER_NAME, beginningBalance);

		// act
		//account.Debit(debitAmount);

		var argException = Assert.Throws<ArgumentOutOfRangeException>(() =>
			account.Debit(debitAmount));

			// assert will never run, 
			// when the exception happens.



		}
	}
}
