using System;
using System.Linq;
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

      Xunit.Assert.Equal(sampleDate.AddDays(30), resultWhichShouldBe30DaysLater);
    }
    [Fact]
    public void ReturnMonday_WhenProposedDateFallsOnSunday() {
      // arrange
      var pd = new SUT.PaymentSystem.PaymentDate();

      DateTime sampleDate = DateTime.Parse("7/8/2011");

      // act
      var resultDateWhichShouldBeMonday = pd.CalculateFuturePaymentDate(sampleDate);

      // assert

      Assert.Equal(DayOfWeek.Monday, resultDateWhichShouldBeMonday.DayOfWeek);
    }

    [Fact]
    public void ReturnMonday_WhenProposedDateFallsOnSaturday() {
      // arrange
      var pd = new SUT.PaymentSystem.PaymentDate();

      DateTime sampleDate = DateTime.Parse("7/7/2011");

      // act
      var resultDateWhichShouldBeMonday = pd.CalculateFuturePaymentDate(sampleDate);

      // assert

      Assert.Equal(DayOfWeek.Monday, resultDateWhichShouldBeMonday.DayOfWeek);
    }
  }
}
