using System;
using Xunit;
using SUT = BrokerageLib;

namespace BrokerageLib.XUnit.Tests.PaymentDate {

	public class CalculateFuturePaymentDate_Should {
    [Fact]
    [Trait  (name: "Category", value: "Fact Test")]
    [Trait(name: "Sprint", value: "12")]
    public void ReturnDate30DaysInFuture_WhenProposedDateFallsOnWeekday() {
      // arrange
      var pd = new SUT.PaymentSystem.PaymentDate();

      DateTime sampleDate = DateTime.Parse("7/6/2011");

      // act
      var resultWhichShouldBe30DaysLater = pd.CalculateFuturePaymentDate(sampleDate);

      // assert

      Xunit.Assert.Equal(expected: sampleDate.AddDays(30), 
                         actual: resultWhichShouldBe30DaysLater);
    }
    [Fact]
    [Trait(name: "Category", value: "Fact Test")]
    [Trait(name: "Sprint", value: "12")]
    public void ReturnMonday_WhenProposedDateFallsOnSunday() {
      // arrange
      var pd = new SUT.PaymentSystem.PaymentDate();

      DateTime sampleDate = DateTime.Parse("7/8/2011");

      // act
      var resultDateWhichShouldBeMonday = pd.CalculateFuturePaymentDate(sampleDate);

      // assert

      Assert.Equal(expected: DayOfWeek.Monday, 
                    actual: resultDateWhichShouldBeMonday.DayOfWeek);
    }

    [Fact]
    [Trait(name: "Category", value: "Fact Test")]
    [Trait(name: "Sprint", value: "12")]
    public void ReturnMonday_WhenProposedDateFallsOnSaturday() {
      // arrange
      var pd = new SUT.PaymentSystem.PaymentDate();

      DateTime sampleDate = DateTime.Parse("7/7/2011");

      // act
      var resultDateWhichShouldBeMonday = pd.CalculateFuturePaymentDate(sampleDate);

      // assert

      Assert.Equal(expected: DayOfWeek.Monday, 
                    actual: resultDateWhichShouldBeMonday.DayOfWeek);
    }
  }
}
