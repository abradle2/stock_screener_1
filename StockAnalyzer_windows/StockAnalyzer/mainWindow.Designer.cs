namespace StockAnalyzer
{
    partial class mainWindow
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
            this.components = new System.ComponentModel.Container();
            this.quotesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.db1DataSet = new StockAnalyzer.db1DataSet();
            this.quotesTableAdapter = new StockAnalyzer.db1DataSetTableAdapters.quotesTableAdapter();
            this.tableAdapterManager = new StockAnalyzer.db1DataSetTableAdapters.TableAdapterManager();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDefaultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smoothedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.volumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indicatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movingAverageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exponentialMovingAverageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bollingerBandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manipulationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.candlestickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nameLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.openLabel = new System.Windows.Forms.Label();
            this.prevCloseLabel = new System.Windows.Forms.Label();
            this.dayRangeLabel = new System.Windows.Forms.Label();
            this.fiftytwoWeekRangeLabel = new System.Windows.Forms.Label();
            this.avgVolLabel = new System.Windows.Forms.Label();
            this.mktCapLabel = new System.Windows.Forms.Label();
            this.peLabel = new System.Windows.Forms.Label();
            this.pbLabel = new System.Windows.Forms.Label();
            this.divLabel = new System.Windows.Forms.Label();
            this.psLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.openText = new System.Windows.Forms.Label();
            this.prevCloseText = new System.Windows.Forms.Label();
            this.dailyRangeText = new System.Windows.Forms.Label();
            this.fiftytwoWeekRangeText = new System.Windows.Forms.Label();
            this.avgVolText = new System.Windows.Forms.Label();
            this.mktCapText = new System.Windows.Forms.Label();
            this.peText = new System.Windows.Forms.Label();
            this.pbText = new System.Windows.Forms.Label();
            this.psText = new System.Windows.Forms.Label();
            this.divText = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.bidLabel = new System.Windows.Forms.Label();
            this.askLabel = new System.Windows.Forms.Label();
            this.changePercentLabel = new System.Windows.Forms.Label();
            this.changeLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.symbolLabel = new System.Windows.Forms.Label();
            this.goButton = new System.Windows.Forms.Button();
            this.symbolTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.quotesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db1DataSet)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // quotesBindingSource
            // 
            this.quotesBindingSource.DataMember = "quotes";
            this.quotesBindingSource.DataSource = this.db1DataSet;
            // 
            // db1DataSet
            // 
            this.db1DataSet.DataSetName = "db1DataSet";
            this.db1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // quotesTableAdapter
            // 
            this.quotesTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CompanyInfoTableAdapter = null;
            this.tableAdapterManager.quotesTableAdapter = this.quotesTableAdapter;
            this.tableAdapterManager.UpdateOrder = StockAnalyzer.db1DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.drawToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(882, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem,
            this.loadDefaultsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // loadDefaultsToolStripMenuItem
            // 
            this.loadDefaultsToolStripMenuItem.Name = "loadDefaultsToolStripMenuItem";
            this.loadDefaultsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.loadDefaultsToolStripMenuItem.Text = "Load Defaults";
            this.loadDefaultsToolStripMenuItem.Click += new System.EventHandler(this.loadDefaultsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.tileHorizontallyToolStripMenuItem,
            this.tileVerticallyToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.cascadeToolStripMenuItem.Text = "Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // tileHorizontallyToolStripMenuItem
            // 
            this.tileHorizontallyToolStripMenuItem.Name = "tileHorizontallyToolStripMenuItem";
            this.tileHorizontallyToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.tileHorizontallyToolStripMenuItem.Text = "Tile Horizontally";
            this.tileHorizontallyToolStripMenuItem.Click += new System.EventHandler(this.tileHorizontallyToolStripMenuItem_Click);
            // 
            // tileVerticallyToolStripMenuItem
            // 
            this.tileVerticallyToolStripMenuItem.Name = "tileVerticallyToolStripMenuItem";
            this.tileVerticallyToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.tileVerticallyToolStripMenuItem.Text = "Tile Vertically";
            this.tileVerticallyToolStripMenuItem.Click += new System.EventHandler(this.tileVerticallyToolStripMenuItem_Click);
            // 
            // drawToolStripMenuItem
            // 
            this.drawToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem,
            this.indicatorsToolStripMenuItem,
            this.manipulationsToolStripMenuItem,
            this.chartTypeToolStripMenuItem});
            this.drawToolStripMenuItem.Name = "drawToolStripMenuItem";
            this.drawToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.drawToolStripMenuItem.Text = "Draw";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smoothedToolStripMenuItem,
            this.volumeToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // smoothedToolStripMenuItem
            // 
            this.smoothedToolStripMenuItem.CheckOnClick = true;
            this.smoothedToolStripMenuItem.Name = "smoothedToolStripMenuItem";
            this.smoothedToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.smoothedToolStripMenuItem.Text = "Smoothed";
            // 
            // volumeToolStripMenuItem
            // 
            this.volumeToolStripMenuItem.CheckOnClick = true;
            this.volumeToolStripMenuItem.Name = "volumeToolStripMenuItem";
            this.volumeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.volumeToolStripMenuItem.Text = "Volume";
            // 
            // indicatorsToolStripMenuItem
            // 
            this.indicatorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movingAverageToolStripMenuItem,
            this.exponentialMovingAverageToolStripMenuItem,
            this.bollingerBandsToolStripMenuItem});
            this.indicatorsToolStripMenuItem.Name = "indicatorsToolStripMenuItem";
            this.indicatorsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.indicatorsToolStripMenuItem.Text = "Indicators";
            // 
            // movingAverageToolStripMenuItem
            // 
            this.movingAverageToolStripMenuItem.CheckOnClick = true;
            this.movingAverageToolStripMenuItem.Name = "movingAverageToolStripMenuItem";
            this.movingAverageToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.movingAverageToolStripMenuItem.Text = "Moving Average";
            this.movingAverageToolStripMenuItem.Click += new System.EventHandler(this.movingAverageToolStripMenuItem_Click);
            // 
            // exponentialMovingAverageToolStripMenuItem
            // 
            this.exponentialMovingAverageToolStripMenuItem.CheckOnClick = true;
            this.exponentialMovingAverageToolStripMenuItem.Name = "exponentialMovingAverageToolStripMenuItem";
            this.exponentialMovingAverageToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.exponentialMovingAverageToolStripMenuItem.Text = "Exponential Moving Average";
            this.exponentialMovingAverageToolStripMenuItem.Click += new System.EventHandler(this.exponentialMovingAverageToolStripMenuItem_Click);
            // 
            // bollingerBandsToolStripMenuItem
            // 
            this.bollingerBandsToolStripMenuItem.CheckOnClick = true;
            this.bollingerBandsToolStripMenuItem.Name = "bollingerBandsToolStripMenuItem";
            this.bollingerBandsToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.bollingerBandsToolStripMenuItem.Text = "Bollinger Bands";
            this.bollingerBandsToolStripMenuItem.Click += new System.EventHandler(this.bollingerBandsToolStripMenuItem_Click);
            // 
            // manipulationsToolStripMenuItem
            // 
            this.manipulationsToolStripMenuItem.Name = "manipulationsToolStripMenuItem";
            this.manipulationsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.manipulationsToolStripMenuItem.Text = "Manipulations";
            // 
            // chartTypeToolStripMenuItem
            // 
            this.chartTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineToolStripMenuItem,
            this.candlestickToolStripMenuItem});
            this.chartTypeToolStripMenuItem.Name = "chartTypeToolStripMenuItem";
            this.chartTypeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.chartTypeToolStripMenuItem.Text = "Chart Type";
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Checked = true;
            this.lineToolStripMenuItem.CheckOnClick = true;
            this.lineToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.lineToolStripMenuItem.Text = "Line";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // candlestickToolStripMenuItem
            // 
            this.candlestickToolStripMenuItem.CheckOnClick = true;
            this.candlestickToolStripMenuItem.Name = "candlestickToolStripMenuItem";
            this.candlestickToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.candlestickToolStripMenuItem.Text = "Candlestick";
            this.candlestickToolStripMenuItem.Click += new System.EventHandler(this.candlestickToolStripMenuItem_Click);
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.tabControl1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 24);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(200, 545);
            this.panelLeft.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 545);
            this.tabControl1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.nameLabel);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.bidLabel);
            this.panel1.Controls.Add(this.askLabel);
            this.panel1.Controls.Add(this.changePercentLabel);
            this.panel1.Controls.Add(this.changeLabel);
            this.panel1.Controls.Add(this.priceLabel);
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Controls.Add(this.symbolLabel);
            this.panel1.Controls.Add(this.goButton);
            this.panel1.Controls.Add(this.symbolTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(682, 24);
            this.panel1.MaximumSize = new System.Drawing.Size(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 545);
            this.panel1.TabIndex = 3;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.Color.White;
            this.nameLabel.Location = new System.Drawing.Point(17, 53);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(57, 20);
            this.nameLabel.TabIndex = 10;
            this.nameLabel.Text = "label1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.Controls.Add(this.openLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.prevCloseLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dayRangeLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.fiftytwoWeekRangeLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.avgVolLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.mktCapLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.peLabel, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.pbLabel, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.divLabel, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.psLabel, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.openText, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.prevCloseText, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dailyRangeText, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.fiftytwoWeekRangeText, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.avgVolText, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.mktCapText, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.peText, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.pbText, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.psText, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.divText, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.label21, 1, 10);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 154);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 12;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(194, 261);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // openLabel
            // 
            this.openLabel.AutoSize = true;
            this.openLabel.ForeColor = System.Drawing.Color.White;
            this.openLabel.Location = new System.Drawing.Point(3, 0);
            this.openLabel.Name = "openLabel";
            this.openLabel.Size = new System.Drawing.Size(33, 13);
            this.openLabel.TabIndex = 8;
            this.openLabel.Text = "Open";
            // 
            // prevCloseLabel
            // 
            this.prevCloseLabel.AutoSize = true;
            this.prevCloseLabel.ForeColor = System.Drawing.Color.White;
            this.prevCloseLabel.Location = new System.Drawing.Point(3, 21);
            this.prevCloseLabel.Name = "prevCloseLabel";
            this.prevCloseLabel.Size = new System.Drawing.Size(58, 13);
            this.prevCloseLabel.TabIndex = 9;
            this.prevCloseLabel.Text = "Prev Close";
            // 
            // dayRangeLabel
            // 
            this.dayRangeLabel.AutoSize = true;
            this.dayRangeLabel.ForeColor = System.Drawing.Color.White;
            this.dayRangeLabel.Location = new System.Drawing.Point(3, 42);
            this.dayRangeLabel.Name = "dayRangeLabel";
            this.dayRangeLabel.Size = new System.Drawing.Size(61, 13);
            this.dayRangeLabel.TabIndex = 10;
            this.dayRangeLabel.Text = "Day Range";
            // 
            // fiftytwoWeekRangeLabel
            // 
            this.fiftytwoWeekRangeLabel.AutoSize = true;
            this.fiftytwoWeekRangeLabel.ForeColor = System.Drawing.Color.White;
            this.fiftytwoWeekRangeLabel.Location = new System.Drawing.Point(3, 63);
            this.fiftytwoWeekRangeLabel.Name = "fiftytwoWeekRangeLabel";
            this.fiftytwoWeekRangeLabel.Size = new System.Drawing.Size(51, 13);
            this.fiftytwoWeekRangeLabel.TabIndex = 11;
            this.fiftytwoWeekRangeLabel.Text = "52 Week";
            // 
            // avgVolLabel
            // 
            this.avgVolLabel.AutoSize = true;
            this.avgVolLabel.ForeColor = System.Drawing.Color.White;
            this.avgVolLabel.Location = new System.Drawing.Point(3, 84);
            this.avgVolLabel.Name = "avgVolLabel";
            this.avgVolLabel.Size = new System.Drawing.Size(64, 13);
            this.avgVolLabel.TabIndex = 12;
            this.avgVolLabel.Text = "Avg Volume";
            // 
            // mktCapLabel
            // 
            this.mktCapLabel.AutoSize = true;
            this.mktCapLabel.ForeColor = System.Drawing.Color.White;
            this.mktCapLabel.Location = new System.Drawing.Point(3, 105);
            this.mktCapLabel.Name = "mktCapLabel";
            this.mktCapLabel.Size = new System.Drawing.Size(62, 13);
            this.mktCapLabel.TabIndex = 13;
            this.mktCapLabel.Text = "Market Cap";
            // 
            // peLabel
            // 
            this.peLabel.AutoSize = true;
            this.peLabel.ForeColor = System.Drawing.Color.White;
            this.peLabel.Location = new System.Drawing.Point(3, 126);
            this.peLabel.Name = "peLabel";
            this.peLabel.Size = new System.Drawing.Size(26, 13);
            this.peLabel.TabIndex = 14;
            this.peLabel.Text = "P/E";
            // 
            // pbLabel
            // 
            this.pbLabel.AutoSize = true;
            this.pbLabel.ForeColor = System.Drawing.Color.White;
            this.pbLabel.Location = new System.Drawing.Point(3, 147);
            this.pbLabel.Name = "pbLabel";
            this.pbLabel.Size = new System.Drawing.Size(26, 13);
            this.pbLabel.TabIndex = 15;
            this.pbLabel.Text = "P/B";
            // 
            // divLabel
            // 
            this.divLabel.AutoSize = true;
            this.divLabel.ForeColor = System.Drawing.Color.White;
            this.divLabel.Location = new System.Drawing.Point(3, 189);
            this.divLabel.Name = "divLabel";
            this.divLabel.Size = new System.Drawing.Size(57, 13);
            this.divLabel.TabIndex = 17;
            this.divLabel.Text = "Div / Yield";
            // 
            // psLabel
            // 
            this.psLabel.AutoSize = true;
            this.psLabel.ForeColor = System.Drawing.Color.White;
            this.psLabel.Location = new System.Drawing.Point(3, 168);
            this.psLabel.Name = "psLabel";
            this.psLabel.Size = new System.Drawing.Size(26, 13);
            this.psLabel.TabIndex = 16;
            this.psLabel.Text = "P/S";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(3, 210);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "label10";
            // 
            // openText
            // 
            this.openText.AutoSize = true;
            this.openText.ForeColor = System.Drawing.Color.White;
            this.openText.Location = new System.Drawing.Point(90, 0);
            this.openText.MaximumSize = new System.Drawing.Size(100, 0);
            this.openText.Name = "openText";
            this.openText.Size = new System.Drawing.Size(41, 13);
            this.openText.TabIndex = 20;
            this.openText.Text = "label12";
            // 
            // prevCloseText
            // 
            this.prevCloseText.AutoSize = true;
            this.prevCloseText.ForeColor = System.Drawing.Color.White;
            this.prevCloseText.Location = new System.Drawing.Point(90, 21);
            this.prevCloseText.MaximumSize = new System.Drawing.Size(100, 0);
            this.prevCloseText.Name = "prevCloseText";
            this.prevCloseText.Size = new System.Drawing.Size(41, 13);
            this.prevCloseText.TabIndex = 21;
            this.prevCloseText.Text = "label13";
            // 
            // dailyRangeText
            // 
            this.dailyRangeText.AutoSize = true;
            this.dailyRangeText.ForeColor = System.Drawing.Color.White;
            this.dailyRangeText.Location = new System.Drawing.Point(90, 42);
            this.dailyRangeText.MaximumSize = new System.Drawing.Size(100, 0);
            this.dailyRangeText.Name = "dailyRangeText";
            this.dailyRangeText.Size = new System.Drawing.Size(41, 13);
            this.dailyRangeText.TabIndex = 19;
            this.dailyRangeText.Text = "label11";
            // 
            // fiftytwoWeekRangeText
            // 
            this.fiftytwoWeekRangeText.AutoSize = true;
            this.fiftytwoWeekRangeText.ForeColor = System.Drawing.Color.White;
            this.fiftytwoWeekRangeText.Location = new System.Drawing.Point(90, 63);
            this.fiftytwoWeekRangeText.MaximumSize = new System.Drawing.Size(100, 0);
            this.fiftytwoWeekRangeText.Name = "fiftytwoWeekRangeText";
            this.fiftytwoWeekRangeText.Size = new System.Drawing.Size(41, 13);
            this.fiftytwoWeekRangeText.TabIndex = 22;
            this.fiftytwoWeekRangeText.Text = "label14";
            // 
            // avgVolText
            // 
            this.avgVolText.AutoSize = true;
            this.avgVolText.ForeColor = System.Drawing.Color.White;
            this.avgVolText.Location = new System.Drawing.Point(90, 84);
            this.avgVolText.MaximumSize = new System.Drawing.Size(100, 0);
            this.avgVolText.Name = "avgVolText";
            this.avgVolText.Size = new System.Drawing.Size(41, 13);
            this.avgVolText.TabIndex = 23;
            this.avgVolText.Text = "label15";
            // 
            // mktCapText
            // 
            this.mktCapText.AutoSize = true;
            this.mktCapText.ForeColor = System.Drawing.Color.White;
            this.mktCapText.Location = new System.Drawing.Point(90, 105);
            this.mktCapText.MaximumSize = new System.Drawing.Size(100, 0);
            this.mktCapText.Name = "mktCapText";
            this.mktCapText.Size = new System.Drawing.Size(41, 13);
            this.mktCapText.TabIndex = 24;
            this.mktCapText.Text = "label16";
            // 
            // peText
            // 
            this.peText.AutoSize = true;
            this.peText.ForeColor = System.Drawing.Color.White;
            this.peText.Location = new System.Drawing.Point(90, 126);
            this.peText.MaximumSize = new System.Drawing.Size(100, 0);
            this.peText.Name = "peText";
            this.peText.Size = new System.Drawing.Size(41, 13);
            this.peText.TabIndex = 25;
            this.peText.Text = "label17";
            // 
            // pbText
            // 
            this.pbText.AutoSize = true;
            this.pbText.ForeColor = System.Drawing.Color.White;
            this.pbText.Location = new System.Drawing.Point(90, 147);
            this.pbText.MaximumSize = new System.Drawing.Size(100, 0);
            this.pbText.Name = "pbText";
            this.pbText.Size = new System.Drawing.Size(41, 13);
            this.pbText.TabIndex = 26;
            this.pbText.Text = "label18";
            // 
            // psText
            // 
            this.psText.AutoSize = true;
            this.psText.ForeColor = System.Drawing.Color.White;
            this.psText.Location = new System.Drawing.Point(90, 168);
            this.psText.MaximumSize = new System.Drawing.Size(100, 0);
            this.psText.Name = "psText";
            this.psText.Size = new System.Drawing.Size(41, 13);
            this.psText.TabIndex = 27;
            this.psText.Text = "label19";
            // 
            // divText
            // 
            this.divText.AutoSize = true;
            this.divText.ForeColor = System.Drawing.Color.White;
            this.divText.Location = new System.Drawing.Point(90, 189);
            this.divText.MaximumSize = new System.Drawing.Size(100, 0);
            this.divText.Name = "divText";
            this.divText.Size = new System.Drawing.Size(41, 13);
            this.divText.TabIndex = 28;
            this.divText.Text = "label20";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(90, 210);
            this.label21.MaximumSize = new System.Drawing.Size(100, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 13);
            this.label21.TabIndex = 29;
            this.label21.Text = "label21";
            // 
            // bidLabel
            // 
            this.bidLabel.AutoSize = true;
            this.bidLabel.ForeColor = System.Drawing.Color.White;
            this.bidLabel.Location = new System.Drawing.Point(122, 128);
            this.bidLabel.Name = "bidLabel";
            this.bidLabel.Size = new System.Drawing.Size(35, 13);
            this.bidLabel.TabIndex = 8;
            this.bidLabel.Text = "label1";
            // 
            // askLabel
            // 
            this.askLabel.AutoSize = true;
            this.askLabel.ForeColor = System.Drawing.Color.White;
            this.askLabel.Location = new System.Drawing.Point(16, 128);
            this.askLabel.Name = "askLabel";
            this.askLabel.Size = new System.Drawing.Size(35, 13);
            this.askLabel.TabIndex = 7;
            this.askLabel.Text = "label1";
            // 
            // changePercentLabel
            // 
            this.changePercentLabel.AutoSize = true;
            this.changePercentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changePercentLabel.ForeColor = System.Drawing.Color.White;
            this.changePercentLabel.Location = new System.Drawing.Point(103, 100);
            this.changePercentLabel.Name = "changePercentLabel";
            this.changePercentLabel.Size = new System.Drawing.Size(41, 13);
            this.changePercentLabel.TabIndex = 6;
            this.changePercentLabel.Text = "label1";
            // 
            // changeLabel
            // 
            this.changeLabel.AutoSize = true;
            this.changeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeLabel.ForeColor = System.Drawing.Color.White;
            this.changeLabel.Location = new System.Drawing.Point(103, 76);
            this.changeLabel.Name = "changeLabel";
            this.changeLabel.Size = new System.Drawing.Size(41, 13);
            this.changeLabel.TabIndex = 5;
            this.changeLabel.Text = "label1";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceLabel.ForeColor = System.Drawing.Color.White;
            this.priceLabel.Location = new System.Drawing.Point(16, 76);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(85, 29);
            this.priceLabel.TabIndex = 4;
            this.priceLabel.Text = "label1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 523);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(200, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // symbolLabel
            // 
            this.symbolLabel.AutoSize = true;
            this.symbolLabel.BackColor = System.Drawing.Color.Black;
            this.symbolLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.symbolLabel.ForeColor = System.Drawing.Color.White;
            this.symbolLabel.Location = new System.Drawing.Point(22, 5);
            this.symbolLabel.Name = "symbolLabel";
            this.symbolLabel.Size = new System.Drawing.Size(51, 13);
            this.symbolLabel.TabIndex = 2;
            this.symbolLabel.Text = "Symbol:";
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(125, 21);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(60, 25);
            this.goButton.TabIndex = 1;
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            this.goButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.goButton_MouseDown);
            this.goButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.goButton_MouseUp);
            // 
            // symbolTextBox
            // 
            this.symbolTextBox.Location = new System.Drawing.Point(19, 24);
            this.symbolTextBox.Name = "symbolTextBox";
            this.symbolTextBox.Size = new System.Drawing.Size(100, 20);
            this.symbolTextBox.TabIndex = 0;
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 569);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainWindow";
            this.Text = "Stock Analyzer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MdiChildActivate += new System.EventHandler(this.mdiActiveChildChange);
            ((System.ComponentModel.ISupportInitialize)(this.quotesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db1DataSet)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private db1DataSet db1DataSet;
        private System.Windows.Forms.BindingSource quotesBindingSource;
        private db1DataSetTableAdapters.quotesTableAdapter quotesTableAdapter;
        private db1DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticallyToolStripMenuItem;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.TextBox symbolTextBox;
        private System.Windows.Forms.Label symbolLabel;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem drawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smoothedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem volumeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indicatorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movingAverageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bollingerBandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manipulationsToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem exponentialMovingAverageToolStripMenuItem;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label changeLabel;
        private System.Windows.Forms.Label changePercentLabel;
        private System.Windows.Forms.Label bidLabel;
        private System.Windows.Forms.Label askLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label openLabel;
        private System.Windows.Forms.Label prevCloseLabel;
        private System.Windows.Forms.Label dayRangeLabel;
        private System.Windows.Forms.Label fiftytwoWeekRangeLabel;
        private System.Windows.Forms.Label avgVolLabel;
        private System.Windows.Forms.Label mktCapLabel;
        private System.Windows.Forms.Label peLabel;
        private System.Windows.Forms.Label pbLabel;
        private System.Windows.Forms.Label divLabel;
        private System.Windows.Forms.Label psLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label openText;
        private System.Windows.Forms.Label prevCloseText;
        private System.Windows.Forms.Label dailyRangeText;
        private System.Windows.Forms.Label fiftytwoWeekRangeText;
        private System.Windows.Forms.Label avgVolText;
        private System.Windows.Forms.Label mktCapText;
        private System.Windows.Forms.Label peText;
        private System.Windows.Forms.Label pbText;
        private System.Windows.Forms.Label psText;
        private System.Windows.Forms.Label divText;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ToolStripMenuItem chartTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem candlestickToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDefaultsToolStripMenuItem;

    }
}

