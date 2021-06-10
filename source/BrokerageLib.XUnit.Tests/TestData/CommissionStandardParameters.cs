using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerageLib.XUnit.Tests.TestData {
	public class CommissionStandardParameters : IEnumerable<object[]> {
		private readonly List<object[]> _dataItems = new List<object[]>
		{
			new object []
			{
				new CommissionTestModel
				{
					UnitsSold = 1,
					UnitPrice = 1M
				}},
			new object []
			{
				new CommissionTestModel
				{
					UnitsSold = 399,
					UnitPrice = 1M
				}},
			new object []
			{
				new CommissionTestModel
				{
					UnitsSold = 1,
					UnitPrice = 11_999M
				}},
		};


		public IEnumerator<object[]> GetEnumerator() {

			return _dataItems.GetEnumerator();

		}
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	}
	public struct CommissionTestModel {
		public int UnitsSold { get; set; }
		public decimal UnitPrice { get; set; }

	}
}

