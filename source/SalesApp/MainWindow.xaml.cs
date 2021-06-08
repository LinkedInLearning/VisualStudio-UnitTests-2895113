using BrokerageLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalesApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			SetupBindings();
		}
		private ObservableCollection<Decimal> PriceList = new ObservableCollection<decimal>();
		private ObservableCollection<int> SoldList = new ObservableCollection<int>();
		private void SetupBindings()
		{
			for (int counter = 1; counter < 21; counter++)
			{
				PriceList.Add(counter * 10M);
			}
			UnitPriceComboBox.ItemsSource = PriceList;

			for (int counter = 5; counter < 90; counter+=5)
			{
				SoldList.Add(counter * 10);
			}
			UnitsSoldComboBox.ItemsSource = SoldList;
			//UnitsSold = SoldList;
			UnitsSoldComboBox.SelectedItem = 5;
		}

		public ObservableCollection<decimal> UnitsSold { get; set; }

		private void BillCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
		{
			var pd = new BrokerageLib.PaymentSystem.PaymentDate();
			var futureDate = pd.CalculateFuturePaymentDate(BillCalendar.SelectedDate ?? DateTime.Now);
			
			DueCalendar.SelectedDate = futureDate;
			DueCalendar.DisplayDate = futureDate;
		}

		private void SalesAmountComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			int unitsSold = (int)(UnitsSoldComboBox.SelectedValue ?? 0);
			decimal unitPrice = (decimal)(UnitPriceComboBox.SelectedValue ?? 0M);
			string message = $"Units Sold: {unitsSold}, Unit Price: {unitPrice}";
			SummaryTextBlock.Text = message;
			var totalSale = unitsSold * unitPrice;
			string totalSaleMessage = $"Total Sale: {(unitsSold * unitPrice):C}";
			TotalPriceTextBlock.Text = totalSaleMessage;
			var calculator = new CommissionCalculator();

			// Act
			decimal calculatedCommission = calculator.GetCommissionForTheSale(unitsSold, unitPrice);
			if (totalSale==0)
			{
				return;
			}
			CommissionAmountTextBlock.Text = $"Commission Amount: {calculatedCommission:c}";
			CommissionRateTextBlock.Text = $"Commission Rate: {calculatedCommission/totalSale} ";
		}
	}
}
