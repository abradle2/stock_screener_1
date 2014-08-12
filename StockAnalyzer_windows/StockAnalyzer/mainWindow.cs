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
using System.IO;

namespace StockAnalyzer
{
    public partial class mainWindow : Form
    {
        public mainWindow()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            goButton.Image = System.Drawing.Image.FromFile(@"../../../images/goButton_MouseUp.png");
        }

        private void quotesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.quotesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.db1DataSet);
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db1DataSet.quotes' table. You can move, or remove it, as needed.
            //this.quotesTableAdapter.Fill(this.db1DataSet.quotes);

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in this.db1DataSet.Tables["quotes"].Rows)
            {
                System.Diagnostics.Debug.Write(row["Symbol"] + ": " + row["Close"]);
            }
        }

       

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form NewMdiChild = new graph_frame();
            //NewMdiChild.MdiParent = this;
            //NewMdiChild.Text = "Graph Frame " + this.MdiChildren.Count();
            //NewMdiChild.Show();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void tileHorizontallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        private void tileVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            try
            {
                string symbol = symbolTextBox.Text.ToUpper();
                stockData stock = new stockData();
                Form NewMdiChild = new graph_frame(stock.getData(symbol), symbol);
                NewMdiChild.MdiParent = this;
                NewMdiChild.Text = symbol + this.MdiChildren.Count();
                NewMdiChild.Show();
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Sorry, couldn't locate that symbol.  Please try another one.");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Sorry, couldn't locate that symbol.  Please try another one.");
            }
        }
            

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void goButton_MouseUp(object sender, MouseEventArgs e)
        {
            goButton.Image = System.Drawing.Image.FromFile(@"../../../images/goButton_MouseUp.png");
        }

        private void goButton_MouseDown(object sender, MouseEventArgs e)
        {
            goButton.Image = System.Drawing.Image.FromFile(@"../../../images/goButton_MouseDown.png");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Form childForm = this.ActiveMdiChild;
            graph_frame castForm = (graph_frame)childForm;
            castForm.showMovingAverage();
        }


        private void movingAverageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = this.ActiveMdiChild;
            graph_frame castForm = (graph_frame)childForm;
            if (movingAverageToolStripMenuItem.Checked)
            {
                castForm.showMovingAverage();
            }
            else
            {
                castForm.hideMovingAverage();
            }
        }

        private void exponentialMovingAverageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = this.ActiveMdiChild;
            graph_frame castForm = (graph_frame)childForm;
            
            if (exponentialMovingAverageToolStripMenuItem.Checked)
            {
                castForm.showExponentialMovingAverage();
            }
            else
            {
                castForm.hideExponentialMovingAverage();
            }
        }

        private void bollingerBandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = this.ActiveMdiChild;
            graph_frame castForm = (graph_frame)childForm;

            if (bollingerBandsToolStripMenuItem.Checked)
            {
                castForm.showBollingerBands();
            }
            else
            {
                castForm.hideBollingerBands();
            }
        }

        //Reset everything when the active MDI child window changes
        private void mdiActiveChildChange(object sender, EventArgs e)
        {
            Form childForm = this.ActiveMdiChild;
            graph_frame castForm = (graph_frame)childForm;
            if (castForm.checkMovingAverage()) { movingAverageToolStripMenuItem.Checked = true;}
            else {movingAverageToolStripMenuItem.Checked = false;}

            if (castForm.checkExponentialMovingAverage()) { exponentialMovingAverageToolStripMenuItem.Checked = true; }
            else { exponentialMovingAverageToolStripMenuItem.Checked = false; }

            if (castForm.checkBollingerBands()) { bollingerBandsToolStripMenuItem.Checked = true; }
            else { bollingerBandsToolStripMenuItem.Checked = false; }

            if (castForm.checkCandlestick()) { candlestickToolStripMenuItem.Checked = true; }
            else { candlestickToolStripMenuItem.Checked = false; }

            if (castForm.checkLine()) { lineToolStripMenuItem.Checked = true; }
            else { lineToolStripMenuItem.Checked = false; }

                        
            //Update Company Info from Database
            string connectionStringLaptop = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\crommie\Dropbox\stock_analyzer\StockAnalyzer_windows\StockAnalyzer\prices.mdf;Integrated Security=True";
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\aaron\documents\visual studio 2012\Projects\StockAnalyzer\StockAnalyzer\prices.mdf;Integrated Security=True";
            SqlConnection db2Connection = new SqlConnection(connectionStringLaptop);
            db2Connection.Open();

            //TODO: Figure out a better way to pass the symbol name into this function!!!
            //Right now we are reading the title of the active chart.  Not a good method!!
            string sym = castForm.getSymbol();
            string sqlStr = "SELECT * FROM companyData where symbol = '" + sym + "'";
            SqlDataAdapter myCommand = new SqlDataAdapter(sqlStr, db2Connection);
            DataSet ds = new DataSet();
            myCommand.Fill(ds);
            db2Connection.Close();
            
            string tempPrice = ds.Tables[0].Rows[0]["price"].ToString();
            string price = tempPrice.Split('>', '<')[2];
            price = Convert.ToDouble(price).ToString("0.00");
            priceLabel.Text = price;
            
            string name = ds.Tables[0].Rows[0]["name"].ToString();
            nameLabel.Text = name;

            string change = ds.Tables[0].Rows[0]["change"].ToString();
            change = change.Split('"', '"')[1];
            changeLabel.Text = change;

            string prevClose = ds.Tables[0].Rows[0]["prevClose"].ToString();
            try 
            { 
                float changePercent = float.Parse(change) / float.Parse(prevClose);
                changePercentLabel.Text = (changePercent * 100).ToString("0.00") + "%";
                if (float.Parse(change) > 0)
                {
                    changeLabel.ForeColor = Color.Green;
                    changePercentLabel.ForeColor = Color.Green;
                }
                else
                {
                    changeLabel.ForeColor = Color.Red;
                    changePercentLabel.ForeColor = Color.Red;
                }
            }
            catch { //MessageBox.Show("Detailed Data Not Available For " + symbol); 
            }

            string openVal = ds.Tables[0].Rows[0]["openVal"].ToString();
            openText.Text = openVal;

            string ask = ds.Tables[0].Rows[0]["ask"].ToString();
            askLabel.Text = "ask  " + ask;

            string bid = ds.Tables[0].Rows[0]["bid"].ToString();
            bidLabel.Text = "bid  " + bid;

            //string prevClose = ds.Tables[0].Rows[0]["prevClose"].ToString();
            //prevClose defined above already
            prevCloseText.Text = prevClose;

            string dailyHigh = ds.Tables[0].Rows[0]["dailyHigh"].ToString();
            string dailyLow = ds.Tables[0].Rows[0]["dailyLow"].ToString();
            dailyLow = Convert.ToDouble(dailyLow).ToString("0.00");         //Only show 2 decimal places
            dailyHigh = Convert.ToDouble(dailyHigh).ToString("0.00");       //Only show 2 decimal places
            dailyRangeText.Text = dailyLow + " - " + dailyHigh;

            string fiftytwoWeekHigh = ds.Tables[0].Rows[0]["fiftytwoWeekHigh"].ToString();
            string fiftytwoWeekLow = ds.Tables[0].Rows[0]["fiftytwoWeekLow"].ToString();
            fiftytwoWeekLow = Convert.ToDouble(fiftytwoWeekLow).ToString("0.00");         //Only show 2 decimal places
            fiftytwoWeekHigh = Convert.ToDouble(fiftytwoWeekHigh).ToString("0.00");       //Only show 2 decimal places
            fiftytwoWeekRangeText.Text = fiftytwoWeekLow + " - " + fiftytwoWeekHigh;

            string avgVol = ds.Tables[0].Rows[0]["avgDailyVol"].ToString();
            avgVolText.Text = avgVol;

            string mktcap = ds.Tables[0].Rows[0]["mktCap"].ToString();
            mktCapText.Text = mktcap;

            string pe = ds.Tables[0].Rows[0]["pe"].ToString();
            peText.Text = pe;

            string pb = ds.Tables[0].Rows[0]["pb"].ToString();
            pbText.Text = pb;

            string ps = ds.Tables[0].Rows[0]["ps"].ToString();
            psText.Text = ps;

            string div = ds.Tables[0].Rows[0]["div"].ToString();
            string divYield = ds.Tables[0].Rows[0]["divYield"].ToString();
            divText.Text = div + " / " + divYield + "%";
            
        }

        private void candlestickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = this.ActiveMdiChild;
            graph_frame castForm = (graph_frame)childForm;

            if (candlestickToolStripMenuItem.Checked)
            {
                castForm.showCandlestick();
                this.lineToolStripMenuItem.Checked = false;
            }
            else
            {
                castForm.hideCandlestick();
            }
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = this.ActiveMdiChild;
            graph_frame castForm = (graph_frame)childForm;

            if (lineToolStripMenuItem.Checked)
            {
                castForm.showLine();
                candlestickToolStripMenuItem.Checked = false;
            }
            else
            {
                castForm.hideLine();
            }
        }

        private void loadDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StreamReader defaultsReader = new StreamReader("../defaults.dat"))
            {
                string line;
                string[] vals;
                while ((line = defaultsReader.ReadLine()) != null)
                {
                    vals = line.Split(',');
                    foreach (string val in vals)
                    {
                        try
                        {
                            string symbol = val.ToUpper();
                            stockData stock = new stockData();
                            Form NewMdiChild = new graph_frame(stock.getData(symbol), symbol);
                            NewMdiChild.MdiParent = this;
                            NewMdiChild.Text = symbol + this.MdiChildren.Count();
                            NewMdiChild.Show();
                        }
                        catch (NotSupportedException)
                        {
                            MessageBox.Show("Not Supported Exception");
                        }
                        catch (FileNotFoundException)
                        {
                            MessageBox.Show("File Not Found Exception");
                            
                        }
                    }
                }
            }
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);


        }



    }

}


