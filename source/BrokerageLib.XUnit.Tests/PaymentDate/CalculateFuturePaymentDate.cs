using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SUT = BrokerageLib;

namespace BrokerageLib.XUnit.Tests.PaymentDate {
	public class CalculateFuturePaymentDate_Should {

		[Fact]
		public void ReturnDate30DaysInFuture_WhenProposedDateFallsOnWeekday() {

			// arrange

			var pd = new SUT.PaymentSystem.PaymentDate();
			DateTime sampleDate = DateTime.Parse("7/6/2011");

			// act
			var resultWhichShouldBe30DaysLater = pd.CalculateFuturePaymentDate(sampleDate);

			// assert
			Assert.Equal(expected: sampleDate.AddDays(30), actual: resultWhichShouldBe30DaysLater);
		}
		[Fact]
		public void ReturnMonday_WhenProposedDateFallsOnSunday() {
			Assert.True(false);
		}
		[Fact]
		public void ReturnMonday_WhenProposedDateFallsOnSaturday() { }
		}
}
