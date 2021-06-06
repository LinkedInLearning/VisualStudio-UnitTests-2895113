namespace BrokerageLib {

	public class Constants {

		public class CommissionRate {
			public const decimal Standard = 0.08m;
			public const decimal Earner = 0.11m;
			public const decimal Epic = 0.14m;
		}

		public class CommissionThreshold {
			public const decimal EpicSalesAmount = 15_000m;
			public const decimal EpicUnitAmount = 600m;
			public const decimal EarnerSalesAmount = 12_000m;
			public const decimal EarnerUnitAmount = 400m;
		}

		public class Discount
		{
			public const decimal PreferredCustomer = 0.2m;
			public const decimal BulkOrder = 0.5m;
		}
	}
}
