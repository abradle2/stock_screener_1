using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace StockAnalyzer
{
    public partial class graph_frame : Form
    {
        DateTime today = DateTime.Today;
        public graph_frame(DataTable companyInfo, string symbol)
        {
            
            InitializeComponent();
            string connectionStringLaptop = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\crommie\Dropbox\stock_analyzer\StockAnalyzer_windows\StockAnalyzer\prices.mdf;Integrated Security=True";
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\aaron\documents\visual studio 2012\Projects\StockAnalyzer\StockAnalyzer\prices.mdf;Integrated Security=True";
            SqlConnection db2Connection = new SqlConnection(connectionStringLaptop);
            db2Connection.Open();

            string sqlStr = "SELECT datetime, closeVal, openVal, highVal, lowVal FROM " + symbol;
            SqlDataAdapter myCommand = new SqlDataAdapter(sqlStr, db2Connection);
            DataSet ds = new DataSet();
            myCommand.Fill(ds);

            this.chart1.Series["Series1"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Format = "C";
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                this.chart1.Series["Series1"].Points.AddXY(Convert.ToDateTime(row["datetime"]), row["closeVal"]);
            }

            

            this.chart1.ChartAreas["ChartArea1"].AxisY.IsStartedFromZero = false;
            this.chart1.Titles["Title1"].Text = symbol;

            this.chart1.ChartAreas["ChartArea1"].CursorX.IsUserEnabled = true;
            this.chart1.ChartAreas["ChartArea1"].CursorX.IsUserSelectionEnabled = true;
            this.chart1.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoomable = true;
            //this.chart1.ChartAreas["ChartArea1"].AxisX.ScrollBar.IsPositionedInside = true;

            //Make candlestick plot, but don't show it yet
            this.chart1.Series.Add("Candlestick");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                this.chart1.Series["Candlestick"].ChartType = SeriesChartType.Candlestick;
                this.chart1.Series["Candlestick"].Points.AddXY(Convert.ToDateTime(row["datetime"]),
                    row["highVal"], row["lowVal"], row["openVal"], row["closeVal"]);
                this.chart1.Series["Candlestick"].Enabled = false;
            }
        }


        //Chart type: candlestick
        public bool checkCandlestick()
        {
            if (this.chart1.Series.IndexOf("Candlestick") == -1)
            {
                return false;
            }
            else
            {
                if (this.chart1.Series["Candlestick"].Enabled) { return true; }
                else { return false; }
            }
        }

        
        public void showCandlestick()
        {
            this.chart1.Series["Series1"].Enabled = false;
            this.chart1.Series["Candlestick"].Enabled = true;
        }

        public void hideCandlestick()
        {
            this.chart1.Series["Series1"].Enabled = true;
            this.chart1.Series["Candlestick"].Enabled = false;

        }

        //Chart type: line
        public bool checkLine()
        {
            if (this.chart1.Series.IndexOf("Series1") == -1)
            {
                return false;
            }
            else
            {
                if (this.chart1.Series["Series1"].Enabled) { return true; }
                else { return false; }
            }
        }

        public void hideLine()
        {
            this.chart1.Series["Series1"].Enabled = false;
        }

        public void showLine()
        {
            this.chart1.Series["Series1"].Enabled = true;
            this.chart1.Series["Candlestick"].Enabled = false;
        }



        public string getSymbol()
        {
            return (this.chart1.Titles["Title1"].Text);
        }
        

        //Moving Averages
        public bool checkMovingAverage()
        {
            if (this.chart1.Series.IndexOf("Simple") == -1)
            {
                return false;
            }
            else
            {
                if (this.chart1.Series["Simple"].Enabled) { return true; }
                else { return false; }
            }
        }

         public void showMovingAverage()
         {
            this.chart1.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "10", "Series1", "Simple");
            this.chart1.Series["Simple"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            this.chart1.Series["Simple"].Color = Color.Yellow;
            this.chart1.Series["Simple"].Enabled = true;
         }

         public void hideMovingAverage()
         {
             try
             {
                 this.chart1.Series["Simple"].Enabled = false;
             }
             catch
             {
                 System.Console.WriteLine("Oops - no moving average yet");
             }
         }

        //Exponential Moving Average
         public bool checkExponentialMovingAverage()
         {
             if (this.chart1.Series.IndexOf("Exponential") == -1)
             {
                 return false;
             }
             else
             {
                 if (this.chart1.Series["Exponential"].Enabled) { return true; }
                 else { return false; }
             }
         }

        
        public void showExponentialMovingAverage()
         {
             this.chart1.DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "Series1", "Exponential");
             this.chart1.Series["Exponential"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
             this.chart1.Series["Exponential"].Color = Color.Red;
             this.chart1.Series["Exponential"].Enabled = true;
         }

        public void hideExponentialMovingAverage()
        {
            try { this.chart1.Series["Exponential"].Enabled = false; }
            catch { }
        }

        //Bollinger Bands
        public bool checkBollingerBands()
        {
            if (this.chart1.Series.IndexOf("Bollinger") == -1)
            {
                return false;
            }
            else
            {
                if (this.chart1.Series["Bollinger"].Enabled) { return true; }
                else { return false; }
            }
        }


        public void showBollingerBands()
        {
            this.chart1.DataManipulator.FinancialFormula(FinancialFormula.BollingerBands, "10, 2", "Series1", "Bollinger, Bollinger:Y2");
            this.chart1.Series["Bollinger"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            //this.chart1.Series["Bollinger"].Color = Color.Green;
            foreach (DataPoint point in this.chart1.Series["Bollinger"].Points)
                    point.Color = Color.FromArgb(50, point.Color = Color.Yellow);
            this.chart1.Series["Bollinger"].Enabled = true;
        }

        public void hideBollingerBands()
        {
            try { this.chart1.Series["Bollinger"].Enabled = false; }
            catch { }
        }



        //Event Handlers

        private void fiveYearButton_Click(object sender, EventArgs e)
        {
            this.chart1.ChartAreas["ChartArea1"].AxisX.ScaleView.ZoomReset();
            this.chart1.ChartAreas["ChartArea1"].AxisY.ScaleView.ZoomReset();
            this.chart1.ChartAreas["ChartArea1"].AxisX.Minimum = today.AddYears(-5).ToOADate();
            
        }

        private void oneYearButton_Click(object sender, EventArgs e)
        {
            this.chart1.ChartAreas["ChartArea1"].AxisX.ScaleView.ZoomReset();
            this.chart1.ChartAreas["ChartArea1"].AxisY.ScaleView.ZoomReset();
            this.chart1.ChartAreas["ChartArea1"].AxisX.Minimum = today.AddYears(-1).ToOADate();
            
        }

        private void oneMonthButton_Click(object sender, EventArgs e)
        {
            this.chart1.ChartAreas["ChartArea1"].AxisX.ScaleView.ZoomReset();
            this.chart1.ChartAreas["ChartArea1"].AxisY.ScaleView.ZoomReset();
            this.chart1.ChartAreas["ChartArea1"].AxisX.Minimum = today.AddMonths(-1).ToOADate();
        }

        private void fiveDayButton_Click(object sender, EventArgs e)
        {
            this.chart1.ChartAreas["ChartArea1"].AxisX.ScaleView.ZoomReset();
            this.chart1.ChartAreas["ChartArea1"].AxisY.ScaleView.ZoomReset();
            this.chart1.ChartAreas["ChartArea1"].AxisX.Minimum = today.AddDays(-7).ToOADate();
            //this.chart1.ChartAreas["ChartArea1"].AxisY.ScaleView
        }

        private void oneDayButton_Click(object sender, EventArgs e)
        {
            this.chart1.ChartAreas["ChartArea1"].AxisX.ScaleView.ZoomReset();
            this.chart1.ChartAreas["ChartArea1"].AxisY.ScaleView.ZoomReset();
            this.chart1.ChartAreas["ChartArea1"].AxisX.Minimum = today.AddDays(-1).ToOADate();
        }

        void chart1_SelectionRangeChanged(object sender, CursorEventArgs e)
        {
            var axisY = this.chart1.ChartAreas["ChartArea1"].AxisY;

            var xRangeStart = e.Axis.ScaleView.ViewMinimum;
            var xRangeEnd = e.Axis.ScaleView.ViewMaximum;

            // compute the Y values for the points crossing the range edges
            double? yRangeStart = null;
            var pointBeforeRangeStart = this.chart1.Series[0].Points.FirstOrDefault(x => x.XValue <= xRangeStart);
            var pointAfterRangeStart = this.chart1.Series[0].Points.FirstOrDefault(x => x.XValue > xRangeStart);
            if (pointBeforeRangeStart != null && pointAfterRangeStart != null)
                yRangeStart = Interpolate2Points(pointBeforeRangeStart, pointAfterRangeStart, xRangeStart);

            double? yRangeEnd = null;
            var pointBeforeRangeEnd = this.chart1.Series[0].Points.FirstOrDefault(x => x.XValue <= xRangeEnd);
            var pointAfterRangeEnd = this.chart1.Series[0].Points.FirstOrDefault(x => x.XValue > xRangeEnd);
            if (pointBeforeRangeEnd != null && pointAfterRangeEnd != null)
                yRangeEnd = Interpolate2Points(pointBeforeRangeEnd, pointAfterRangeEnd, xRangeEnd);

            var edgeValues = new[] { yRangeStart, yRangeEnd }.Where(x => x.HasValue).Select(x => x.Value);

            // find the points inside the range
            var valuesInRange = this.chart1.Series["Series1"].Points
            .Where(p => p.XValue >= xRangeStart && p.XValue <= xRangeEnd)
            .Select(x => x.YValues[0]);

            // find the minimum and maximum Y values
            var values = valuesInRange.Concat(edgeValues);
            double yMin;
            double yMax;
            if (values.Any())
            {
                yMin = values.Min();
                yMax = values.Max();
            }
            else
            {
                yMin = this.chart1.Series["Series1"].Points.Min(x => x.YValues[0]);
                yMax = this.chart1.Series["Series1"].Points.Max(x => x.YValues[0]);
            }

            // zoom Y-axis to [yMin - yMax]
            axisY.ScaleView.Zoom(yMin, yMax);
        }

        // see: http://en.wikipedia.org/wiki/Linear_interpolation#Linear_interpolation_between_two_known_points
        public static double Interpolate2Points(DataPoint p1, DataPoint p2, double x)
        {
            var x0 = p1.XValue;
            var y0 = p1.YValues[0];
            var x1 = p2.XValue;
            var y1 = p2.YValues[0];
            return y0 + ((x - x0) * y1 - (x - x0) * y0) / (x1 - x0);
        }
       
    }
}
