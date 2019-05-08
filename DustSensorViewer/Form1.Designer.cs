namespace DustSensorViewer
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.numericUpDown_chartX = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_filter = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.checkBox_PMS_raw = new System.Windows.Forms.CheckBox();
            this.button_con = new System.Windows.Forms.Button();
            this.comboBox_port = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.textBox_console = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.checkBox_sampling = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_chartX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox_sampling);
            this.splitContainer1.Panel1.Controls.Add(this.numericUpDown2);
            this.splitContainer1.Panel1.Controls.Add(this.numericUpDown_chartX);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox_filter);
            this.splitContainer1.Panel1.Controls.Add(this.numericUpDown1);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox_PMS_raw);
            this.splitContainer1.Panel1.Controls.Add(this.button_con);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox_port);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(805, 580);
            this.splitContainer1.SplitterDistance = 105;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // numericUpDown_chartX
            // 
            this.numericUpDown_chartX.BackColor = System.Drawing.Color.Black;
            this.numericUpDown_chartX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_chartX.ForeColor = System.Drawing.Color.Lime;
            this.numericUpDown_chartX.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown_chartX.Location = new System.Drawing.Point(715, 11);
            this.numericUpDown_chartX.Margin = new System.Windows.Forms.Padding(1);
            this.numericUpDown_chartX.Maximum = new decimal(new int[] {
            7200,
            0,
            0,
            0});
            this.numericUpDown_chartX.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown_chartX.Name = "numericUpDown_chartX";
            this.numericUpDown_chartX.Size = new System.Drawing.Size(80, 21);
            this.numericUpDown_chartX.TabIndex = 5;
            this.numericUpDown_chartX.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericUpDown_chartX.ValueChanged += new System.EventHandler(this.numericUpDown_chartX_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(676, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Plot";
            // 
            // checkBox_filter
            // 
            this.checkBox_filter.AutoSize = true;
            this.checkBox_filter.ForeColor = System.Drawing.Color.Lime;
            this.checkBox_filter.Location = new System.Drawing.Point(388, 11);
            this.checkBox_filter.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_filter.Name = "checkBox_filter";
            this.checkBox_filter.Size = new System.Drawing.Size(195, 22);
            this.checkBox_filter.TabIndex = 4;
            this.checkBox_filter.Text = "Enable Moving Average by";
            this.checkBox_filter.UseVisualStyleBackColor = true;
            this.checkBox_filter.CheckedChanged += new System.EventHandler(this.checkBox_filter_CheckedChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.Black;
            this.numericUpDown1.ForeColor = System.Drawing.Color.Lime;
            this.numericUpDown1.Location = new System.Drawing.Point(586, 9);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(1);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(64, 25);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // checkBox_PMS_raw
            // 
            this.checkBox_PMS_raw.AutoSize = true;
            this.checkBox_PMS_raw.ForeColor = System.Drawing.Color.Lime;
            this.checkBox_PMS_raw.Location = new System.Drawing.Point(231, 11);
            this.checkBox_PMS_raw.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_PMS_raw.Name = "checkBox_PMS_raw";
            this.checkBox_PMS_raw.Size = new System.Drawing.Size(153, 22);
            this.checkBox_PMS_raw.TabIndex = 2;
            this.checkBox_PMS_raw.Text = "Save Raw Data(PMS)";
            this.checkBox_PMS_raw.UseVisualStyleBackColor = true;
            // 
            // button_con
            // 
            this.button_con.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_con.Font = new System.Drawing.Font("D2Coding", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_con.ForeColor = System.Drawing.Color.Lime;
            this.button_con.Location = new System.Drawing.Point(126, 9);
            this.button_con.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.button_con.Name = "button_con";
            this.button_con.Size = new System.Drawing.Size(93, 26);
            this.button_con.TabIndex = 1;
            this.button_con.Text = "Connect";
            this.button_con.UseVisualStyleBackColor = true;
            this.button_con.Click += new System.EventHandler(this.button_con_Click);
            // 
            // comboBox_port
            // 
            this.comboBox_port.BackColor = System.Drawing.Color.Black;
            this.comboBox_port.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_port.ForeColor = System.Drawing.Color.Lime;
            this.comboBox_port.FormattingEnabled = true;
            this.comboBox_port.Location = new System.Drawing.Point(7, 9);
            this.comboBox_port.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.comboBox_port.Name = "comboBox_port";
            this.comboBox_port.Size = new System.Drawing.Size(111, 26);
            this.comboBox_port.TabIndex = 0;
            this.comboBox_port.DropDown += new System.EventHandler(this.comboBox_port_DropDown);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.textBox_console);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.chart1);
            this.splitContainer2.Size = new System.Drawing.Size(805, 472);
            this.splitContainer2.SplitterDistance = 107;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 0;
            // 
            // textBox_console
            // 
            this.textBox_console.BackColor = System.Drawing.Color.Black;
            this.textBox_console.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_console.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox_console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_console.ForeColor = System.Drawing.Color.Lime;
            this.textBox_console.Location = new System.Drawing.Point(0, 0);
            this.textBox_console.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textBox_console.Multiline = true;
            this.textBox_console.Name = "textBox_console";
            this.textBox_console.ReadOnly = true;
            this.textBox_console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_console.Size = new System.Drawing.Size(805, 107);
            this.textBox_console.TabIndex = 0;
            this.textBox_console.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Black;
            this.chart1.BorderlineColor = System.Drawing.Color.Lime;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Lime;
            chartArea1.AxisX.LineColor = System.Drawing.Color.Lime;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Lime;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Lime;
            chartArea1.AxisY.LineColor = System.Drawing.Color.Lime;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Lime;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Lime;
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.BorderColor = System.Drawing.Color.Lime;
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 100F;
            chartArea1.Position.Width = 100F;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Far;
            legend1.DockedToChartArea = "ChartArea1";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Legend = "Legend1";
            series1.Name = "PM10";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Legend = "Legend1";
            series2.Name = "PM2.5";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series3.Legend = "Legend1";
            series3.Name = "PM1.0";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(805, 362);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM15";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.BackColor = System.Drawing.Color.Black;
            this.numericUpDown2.ForeColor = System.Drawing.Color.Lime;
            this.numericUpDown2.Location = new System.Drawing.Point(174, 59);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(1);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(51, 25);
            this.numericUpDown2.TabIndex = 7;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkBox_sampling
            // 
            this.checkBox_sampling.AutoSize = true;
            this.checkBox_sampling.ForeColor = System.Drawing.Color.Lime;
            this.checkBox_sampling.Location = new System.Drawing.Point(11, 60);
            this.checkBox_sampling.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_sampling.Name = "checkBox_sampling";
            this.checkBox_sampling.Size = new System.Drawing.Size(160, 22);
            this.checkBox_sampling.TabIndex = 8;
            this.checkBox_sampling.Text = "Sampling interval :";
            this.checkBox_sampling.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(228, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Min";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(805, 580);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("D2Coding", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dust Viewer v1.3 by herz1012";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_chartX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button_con;
        private System.Windows.Forms.ComboBox comboBox_port;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox textBox_console;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.CheckBox checkBox_PMS_raw;
        private System.Windows.Forms.CheckBox checkBox_filter;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown_chartX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_sampling;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
    }
}

