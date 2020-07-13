using Syncfusion.PivotAnalysis.Base;
using Syncfusion.Windows.Controls.PivotGrid;
using System;
using System.Collections.Generic;
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

namespace Pivotsample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            PivotItem m_PivotItem = new PivotItem()
            {
                FieldHeader = "Product",
                FieldMappingName = "Product",
                TotalHeader = "Total"
            };
            PivotItem m_PivotItem1 = new PivotItem()
            {
                FieldHeader = "Date",
                FieldMappingName = "Date",
                TotalHeader = "Total"
            };
            PivotItem n_PivotItem = new PivotItem()
            {
                FieldHeader = "Country",
                FieldMappingName = "Country",
                TotalHeader = "Total"
            };
            PivotItem n_PivotItem1 = new PivotItem()
            {
                FieldHeader = "State",
                FieldMappingName = "State",
                TotalHeader = "Total"
            };
            // Adding PivotItem to PivotRows
            pivotGrid.PivotRows.Add(m_PivotItem);
            pivotGrid.PivotRows.Add(m_PivotItem1);
            // Adding PivotItem to PivotColumns
            pivotGrid.PivotColumns.Add(n_PivotItem);
            pivotGrid.PivotColumns.Add(n_PivotItem1);
            PivotComputationInfo m_PivotComputationInfo = new PivotComputationInfo()
            {
                CalculationName = "Amount",
                FieldName = "Amount",
                SummaryType = SummaryType.Count
            };
            PivotComputationInfo m_PivotComputationInfo1 = new PivotComputationInfo()
            {
                CalculationName = "Quantity",
                FieldName = "Quantity",
                SummaryType = SummaryType.Count
            };
            pivotGrid.PivotCalculations.Add(m_PivotComputationInfo);
            pivotGrid.PivotCalculations.Add(m_PivotComputationInfo1);
            pivotGrid.ItemSource = ProductSales.GetSalesData();
        }

        private void Expand_Click(object sender, RoutedEventArgs e)
        {
            //Expand all nodes in rows and columns
            pivotGrid.ExpandAllGroup();
        }

        private void Collapse_Click(object sender, RoutedEventArgs e)
        {
            //Collapse all nodes in rows and columns
            pivotGrid.CollapseAllGroup();
        }
    }
    public class ProductSales
    {
        public string Product
        {
            get;
            set;
        }
        public string Date
        {
            get;
            set;
        }
        public string Country
        {
            get;
            set;
        }
        public string State
        {
            get;
            set;
        }
        public int Quantity
        {
            get;
            set;
        }
        public double Amount
        {
            get;
            set;
        }
        public static ProductSalesCollection GetSalesData()
        {
            /// Geography
            string[] countries = new string[] {
            "Canada"
        };
            string[] canadaStates = new string[] {
            "Alberta",
            "British Columbia",
            "Ontario"
        };
            /// Time
            string[] dates = new string[] {
            "FY 2005",
            "FY 2006",
            "FY 2007"
        };
            /// Products
            string[] products = new string[] {
            "Bike",
            "Car"
        };
            Random r = new Random(123345345);
            int numberOfRecords = 2000;
            ProductSalesCollection listOfProductSales = new ProductSalesCollection();
            for (int i = 0; i < numberOfRecords; i++)
            {
                ProductSales sales = new ProductSales();
                sales.Country = countries[r.Next(0, countries.GetLength(0))];
                sales.Quantity = r.Next(1, 12);
                /// 1 percent discount for 1 quantity
                double discount = (30000 * sales.Quantity) * (double.Parse(sales.Quantity.ToString()) / 100);
                sales.Amount = (30000 * sales.Quantity) - discount;
                sales.Date = dates[r.Next(r.Next(dates.GetLength(0) + 1))];
                sales.Product = products[r.Next(r.Next(products.GetLength(0) + 1))];
                sales.State = canadaStates[r.Next(canadaStates.GetLength(0))];
                listOfProductSales.Add(sales);
            }
            return listOfProductSales;
        }
        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}", this.Country, this.State, this.Product);
        }
        public class ProductSalesCollection : List<ProductSales>
        {

        }
    }
}
