namespace StockAnalyzer
{
    partial class graph_frame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.fiveDayButton = new System.Windows.Forms.Button();
            this.oneMonthButton = new System.Windows.Forms.Button();
            this.oneYearButton = new System.Windows.Forms.Button();
            this.fiveYearButton = new System.Windows.Forms.Button();
            this.oneDayButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Black;
            this.chart1.BackSecondaryColor = System.Drawing.Color.Black;
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.BackSecondaryColor = System.Drawing.Color.Black;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 85F;
            chartArea1.Position.Width = 94F;
            chartArea1.Position.X = 3F;
            chartArea1.Position.Y = 7F;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.BorderColor = System.Drawing.Color.Black;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Color = System.Drawing.SystemColors.Highlight;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(798, 461);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.BorderWidth = 2;
            title1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.White;
            title1.Name = "Title1";
            this.chart1.Titles.Add(title1);
            this.chart1.SelectionRangeChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.chart1_SelectionRangeChanged);
            // 
            // fiveDayButton
            // 
            this.fiveDayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.fiveDayButton.Location = new System.Drawing.Point(574, 3);
            this.fiveDayButton.Name = "fiveDayButton";
            this.fiveDayButton.Size = new System.Drawing.Size(49, 19);
            this.fiveDayButton.TabIndex = 3;
            this.fiveDayButton.Text = "5 Days";
            this.fiveDayButton.UseVisualStyleBackColor = true;
            this.fiveDayButton.Click += new System.EventHandler(this.fiveDayButton_Click);
            // 
            // oneMonthButton
            // 
            this.oneMonthButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.oneMonthButton.Location = new System.Drawing.Point(629, 3);
            this.oneMonthButton.Name = "oneMonthButton";
            this.oneMonthButton.Size = new System.Drawing.Size(60, 19);
            this.oneMonthButton.TabIndex = 2;
            this.oneMonthButton.Text = "1 Month";
            this.oneMonthButton.UseVisualStyleBackColor = true;
            this.oneMonthButton.Click += new System.EventHandler(this.oneMonthButton_Click);
            // 
            // oneYearButton
            // 
            this.oneYearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.oneYearButton.Location = new System.Drawing.Point(695, 3);
            this.oneYearButton.Name = "oneYearButton";
            this.oneYearButton.Size = new System.Drawing.Size(44, 19);
            this.oneYearButton.TabIndex = 1;
            this.oneYearButton.Text = "1 yr";
            this.oneYearButton.UseVisualStyleBackColor = true;
            this.oneYearButton.Click += new System.EventHandler(this.oneYearButton_Click);
            // 
            // fiveYearButton
            // 
            this.fiveYearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fiveYearButton.Location = new System.Drawing.Point(745, 3);
            this.fiveYearButton.Name = "fiveYearButton";
            this.fiveYearButton.Size = new System.Drawing.Size(50, 19);
            this.fiveYearButton.TabIndex = 0;
            this.fiveYearButton.Text = "5 yr";
            this.fiveYearButton.UseVisualStyleBackColor = true;
            this.fiveYearButton.Click += new System.EventHandler(this.fiveYearButton_Click);
            // 
            // oneDayButton
            // 
            this.oneDayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.oneDayButton.Location = new System.Drawing.Point(529, 3);
            this.oneDayButton.Name = "oneDayButton";
            this.oneDayButton.Size = new System.Drawing.Size(39, 19);
            this.oneDayButton.TabIndex = 4;
            this.oneDayButton.Text = "1 Day";
            this.oneDayButton.UseVisualStyleBackColor = true;
            this.oneDayButton.Click += new System.EventHandler(this.oneDayButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 92.11909F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.880911F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.Controls.Add(this.fiveYearButton, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.oneYearButton, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.oneMonthButton, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.fiveDayButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.oneDayButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 436);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(798, 25);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // graph_frame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.chart1);
            this.Name = "graph_frame";
            this.Text = "Graph Frame";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button fiveDayButton;
        private System.Windows.Forms.Button oneMonthButton;
        private System.Windows.Forms.Button oneYearButton;
        private System.Windows.Forms.Button fiveYearButton;
        private System.Windows.Forms.Button oneDayButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}