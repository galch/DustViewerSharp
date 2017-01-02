using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DustSensorViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            update_comboBox();
            
            chart1.ChartAreas[0].AxisX.Minimum = 1;
            chart1.ChartAreas[0].AxisX.Maximum = 600 + 1;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = Double.NaN;

            checkBox_PMS_raw.Visible = false;

            Filter_pm10 = new Filter.AverageFilter((int)numericUpDown1.Value);
            Filter_pm25 = new Filter.AverageFilter((int)numericUpDown1.Value);
            Filter_pm1 = new Filter.AverageFilter((int)numericUpDown1.Value);
        }

        private void update_comboBox()
        {
            comboBox_port.Items.Clear();

            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                comboBox_port.Items.Add(s);
            }

            if (comboBox_port.Items.Count > 0)
            {
                comboBox_port.SelectedIndex = 0;
            }
        }

        private void comboBox_port_DropDown(object sender, EventArgs e)
        {
            update_comboBox();
        }
        List<byte> data_acc = new List<byte>();
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int recvedPacketLength = serialPort1.BytesToRead;
            if (recvedPacketLength == 0) return;
            Console.WriteLine("Recv packet length {0}", recvedPacketLength);
            byte[] data = new byte[recvedPacketLength];
            serialPort1.Read(data, 0, recvedPacketLength);
            data_acc.AddRange(data);
            Console.WriteLine(BitConverter.ToString(data));

            if (data.Count() > 0)
            {
                if(data_acc.IndexOf(PMS_HEADER2) - data_acc.IndexOf(PMS_HEADER1) == 1)
                {
                    if(data_acc.Count > 32)
                    {
                        byte[] maybePMSpacket = data_acc.GetRange(data_acc.IndexOf(PMS_HEADER1), 32).ToArray();

                        if (!checkBox_PMS_raw.Visible)
                        {
                            checkBox_PMS_raw.Invoke(new Action(delegate ()
                            {
                                checkBox_PMS_raw.Visible = true;
                            }));
                        }
                        parse_PMS(maybePMSpacket);
                        data_acc.RemoveRange(data_acc.IndexOf(PMS_HEADER1), 32);
                    }
                }
                else if (data_acc.IndexOf(SDS_TAIL) - data_acc.IndexOf(SDS_HEADER1) == 9)
                {
                    if (checkBox_PMS_raw.Visible)
                    {
                        checkBox_PMS_raw.Invoke(new Action(delegate ()
                        {
                            checkBox_PMS_raw.Visible = false;
                        }));
                    }
                    parse_SDS(data);
                    data_acc.RemoveRange(data_acc.IndexOf(SDS_HEADER1), 10);
                }                
            }

        }
    
        private void button_con_Click(object sender, EventArgs e)
        {
            if (comboBox_port.SelectedItem == null)
            {
                MessageBox.Show("Serial Device was not found!");
                return;
            }

            if (!serialPort1.IsOpen)
                serialPort1.PortName = comboBox_port.SelectedItem.ToString();

            if (button_con.Text == "Connect")
            {
                try
                {
                    serialPort1.Open();
                }
                catch
                {
                    MessageBox.Show("Serial Port Access Denied");
                }                

                if(serialPort1.IsOpen)
                {
                    button_con.Text = "Disconnect";
                    button_con.ForeColor = Color.Black;
                    button_con.BackColor = Color.Lime;

                }
            }
            else
            {
                if (serialPort1.IsOpen)
                    serialPort1.Close();

                if (!serialPort1.IsOpen)
                {
                    button_con.Text = "Connect";
                    button_con.ForeColor = Color.Lime;
                    button_con.BackColor = Color.Black;
                }
            }
        }

        #region Parse and logging

        bool first = true;
        private static readonly string LOG_FILE = @"log_{0}_{1}.txt";
        private static readonly string[] TIME_FORMAT = { "HH':'mm':'ss", "yyyy'-'MM'-'dd'\t'HH':'mm':'ss", "yyyy''MM''dd" };
        private static readonly string[] LOG_FIRST_LINE = { "Time\tPM 10\tPM 2.5",
                                                            "Time\tPM 10\tPM 2.5\tPM 1.0",
                                                            "Time\tRAW 0.3\tRAW 0.5\tRAW 1.0\tRAW 2.5\tRAW 5.0\tRAW 10.0" };

        private static readonly string[] LOG_LINE = { "{0}\t{1}\t{2}",
                                                      "{0}\t{1}\t{2}\t{3}",
                                                      "{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}" };

        private static readonly string[] TEXT_LINE = { "{0}\tPM 10\t{1} µg/m3\tPM 2.5\t{2} µg/m3\tSensor: {3}",
                                                       "{0}\tPM 10\t{1} µg/m3\tPM 2.5\t{2} µg/m3\tPM 1.0\t{3} µg/m3\tSensor: {4}"};


        private void update(string sensor_name, double pm10, double pm25)
        {
            string s_log = String.Format(LOG_LINE[0], DateTime.Now.ToString(TIME_FORMAT[0]), pm10.ToString("0.0"), pm25.ToString("0.0"));
            string s_text = String.Format(TEXT_LINE[0], DateTime.Now.ToString(TIME_FORMAT[1]), pm10.ToString("0.0"), pm25.ToString("0.0"), sensor_name);

            update_log(sensor_name, s_log);
            update_text(s_text);
            update_chart(pm10, pm25);
            ThingSpeakClient.UpdateChannelFeed(pm10, pm25);
        }

        private void update(string sensor_name, int pm10, int pm25, int pm1)
        {
            string s_log = String.Format(LOG_LINE[1], DateTime.Now.ToString(TIME_FORMAT[0]), pm10, pm25, pm1);
            string s_text = String.Format(TEXT_LINE[1], DateTime.Now.ToString(TIME_FORMAT[1]), pm10, pm25, pm1, sensor_name);
            
            update_log(sensor_name, s_log);
            update_text(s_text);
            update_chart(pm10, pm25, pm1);
            ThingSpeakClient.UpdateChannelFeed(pm10, pm25, pm1);
        }

        private void update_log(string sensor_name, string msg)
        {
            string log_path = String.Format(LOG_FILE, sensor_name, DateTime.Now.ToString(TIME_FORMAT[2]));
            int type = msg.Split('\t').Count();

            if (first)
            {
                if (File.Exists(log_path))
                {
                    List<string> last_logs = File.ReadLines(log_path).Reverse().Take((int)chart1.ChartAreas[0].AxisX.Maximum).Reverse().ToList();

                    foreach (var log in last_logs)
                    {
                        if (!IsControlValid(this)) return;

                        if (!LOG_FIRST_LINE.Any(log.Contains))
                        {
                            string[] parsed = log.Split('\t');
                            switch (type)
                            {
                                case 3:
                                    update_chart(Convert.ToDouble(parsed[1]), Convert.ToDouble(parsed[2]));
                                    break;
                                case 4:
                                    update_chart(Convert.ToDouble(parsed[1]), Convert.ToDouble(parsed[2]), Convert.ToDouble(parsed[3]));
                                    break;
                            }
                        }
                    }
                }
                first = false;
            }

            if (!File.Exists(log_path))
            {
                using (StreamWriter sw = File.AppendText(log_path))
                {                    
                    switch(type)
                    {
                        case 3:
                            sw.WriteLine(LOG_FIRST_LINE[0]);
                            break;
                        case 4:
                            sw.WriteLine(LOG_FIRST_LINE[1]);
                            break;
                        case 7:
                            sw.WriteLine(LOG_FIRST_LINE[2]);
                            break;
                    }
                }
            }

            using (StreamWriter sw = File.AppendText(log_path))
            {
                sw.WriteLine(msg);
            }
        }

        private bool AbortThread = false;
        private bool IsControlValid(Control myControl)
        {
            if (myControl == null)          return false;
            if (myControl.IsDisposed)       return false;
            if (myControl.Disposing)        return false;
            if (!myControl.IsHandleCreated) return false;
            if (AbortThread)                return false; // the signal to the thread to stop processing

            return true;
        }

        private void update_text(string s)
        {
            if (!IsControlValid(textBox_console)) return;

            Thread thread_log = new Thread(new ThreadStart(delegate () // thread 생성
            {
                if (textBox_console.InvokeRequired)
                {
                    textBox_console.Invoke(new Action(delegate ()
                    {
                        if (textBox_console.Lines.Count() > 120)
                            textBox_console.Lines = textBox_console.Lines.Skip(1).ToArray();

                        textBox_console.AppendText(s + "\r\n");
                    }));
                }
                else
                {
                    textBox_console.Refresh();
                }
            }));
            thread_log.Start(); // thread 실행하여 병렬작업 시작
        }

        private void cut_chart(DataPointCollection point_arr, int cut)
        {
            
            var point_temp = point_arr.Skip(cut).ToArray();
            point_arr.Clear();
            //point_arr.Add(point_temp);

            Console.WriteLine(point_arr.Count);
        }
        private void update_chart(double pm10, double pm25)
        {
            if (!IsControlValid(chart1)) return;

            Thread thread_chart = new Thread(new ThreadStart(delegate () // thread 생성
            {
                if (chart1.InvokeRequired)
                {
                    chart1.Invoke(new Action(delegate ()
                    {
                        string Avg_10 = "PM10 - Avg" + numericUpDown1.Value;
                        string Avg_25 = "PM2.5 - Avg" + numericUpDown1.Value;

                        if (checkBox_filter.Checked)
                        {
                            if (!chart1.Series.Contains(chart1.Series.FindByName(Avg_10)))
                            {
                                chart1.Series.Add(Avg_10);
                                chart1.Series[Avg_10].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
                                chart1.Series.Add(Avg_25);
                                chart1.Series[Avg_25].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;


                                for (int i=0; i< chart1.Series["PM10"].Points.Count - 1; i++)
                                {
                                    chart1.Series[Avg_10].Points.AddY(Filter_pm10.insert(chart1.Series["PM10"].Points.ElementAt(i).YValues[0]));
                                    chart1.Series[Avg_25].Points.AddY(Filter_pm25.insert(chart1.Series["PM2.5"].Points.ElementAt(i).YValues[0]));
                                }
                            }

                            chart1.Series[Avg_10].Points.AddY(Filter_pm10.insert(pm10));
                            chart1.Series[Avg_25].Points.AddY(Filter_pm25.insert(pm25));
                        }
                        else
                        {
                            if(chart1.Series.Contains(chart1.Series.FindByName(Avg_10)))
                                chart1.Series.Remove(chart1.Series.FindByName(Avg_10));
                            if (chart1.Series.Contains(chart1.Series.FindByName(Avg_25)))
                                chart1.Series.Remove(chart1.Series.FindByName(Avg_25));                            
                        }
                        
                        foreach (var series in chart1.Series)
                        {
                            while (series.Points.Count > chart1.ChartAreas[0].AxisX.Maximum)
                            {
                                series.Points.RemoveAt(0);
                                //int leftover = series.Points.Count - (int)chart1.ChartAreas[0].AxisX.Maximum;
                                //cut_chart(series.Points, leftover);
                            }
                        }
                        chart1.ChartAreas[0].RecalculateAxesScale();

                        chart1.Series["PM10"].Points.AddY(pm10);
                        chart1.Series["PM2.5"].Points.AddY(pm25);
                        chart1.Series["PM1.0"].Points.AddY(0);
                    }));
                }
                else
                {
                    chart1.Refresh();
                }
            }));
            thread_chart.Start(); // thread 실행하여 병렬작업 시작
        }

        private void update_chart<T>(T pm10, T pm25, T pm1)
        {
            if (!IsControlValid(chart1)) return;
            
            Thread thread_chart = new Thread(new ThreadStart(delegate () // thread 생성
            {
                if (chart1.InvokeRequired)
                {
                    chart1.Invoke(new Action(delegate ()
                    {
                        string Avg_10 = "PM10 - Avg" + numericUpDown1.Value;
                        string Avg_25 = "PM2.5 - Avg" + numericUpDown1.Value;
                        string Avg_1 = "PM1.0 - Avg" + numericUpDown1.Value;

                        if (checkBox_filter.Checked)
                        {
                            if (!chart1.Series.Contains(chart1.Series.FindByName(Avg_10)))
                            {
                                chart1.Series.Add(Avg_10);
                                chart1.Series[Avg_10].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
                                chart1.Series.Add(Avg_25);
                                chart1.Series[Avg_25].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
                                chart1.Series.Add(Avg_1);
                                chart1.Series[Avg_1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;


                                for (int i = 0; i < chart1.Series["PM10"].Points.Count - 1; i++)
                                {
                                    chart1.Series[Avg_10].Points.AddY(Filter_pm10.insert(chart1.Series["PM10"].Points.ElementAt(i).YValues[0]));
                                    chart1.Series[Avg_25].Points.AddY(Filter_pm25.insert(chart1.Series["PM2.5"].Points.ElementAt(i).YValues[0]));
                                    chart1.Series[Avg_1].Points.AddY(Filter_pm1.insert(chart1.Series["PM1.0"].Points.ElementAt(i).YValues[0]));
                                }
                            }

                            chart1.Series[Avg_10].Points.AddY(Filter_pm10.insert(Convert.ToDouble(pm10)));
                            chart1.Series[Avg_25].Points.AddY(Filter_pm25.insert(Convert.ToDouble(pm25)));
                            chart1.Series[Avg_1].Points.AddY(Filter_pm1.insert(Convert.ToDouble(pm1)));
                        }
                        else
                        {
                            if (chart1.Series.Contains(chart1.Series.FindByName(Avg_10)))
                                chart1.Series.Remove(chart1.Series.FindByName(Avg_10));
                            if (chart1.Series.Contains(chart1.Series.FindByName(Avg_25)))
                                chart1.Series.Remove(chart1.Series.FindByName(Avg_25));
                        }

                        while (chart1.Series["PM10"].Points.Count > chart1.ChartAreas[0].AxisX.Maximum)
                        {
                            chart1.Series["PM10"].Points.RemoveAt(0);
                            chart1.Series["PM2.5"].Points.RemoveAt(0);
                            chart1.Series["PM1.0"].Points.RemoveAt(0);

                            if (checkBox_filter.Checked)
                            {
                                chart1.Series[Avg_10].Points.RemoveAt(0);
                                chart1.Series[Avg_25].Points.RemoveAt(0);
                                chart1.Series[Avg_1].Points.RemoveAt(0);
                            }

                            chart1.ChartAreas[0].RecalculateAxesScale();
                        }
                        chart1.Series["PM10"].Points.AddY(pm10);
                        chart1.Series["PM2.5"].Points.AddY(pm25);
                        chart1.Series["PM1.0"].Points.AddY(pm1);                       
                    }));
                }
                else
                {
                    chart1.Refresh();
                }
            }));
            thread_chart.Start(); // thread 실행하여 병렬작업 시작
        }


        const byte SDS_HEADER1 = 0xAA;
        const byte SDS_HEADER2 = 0xC0;
        const byte SDS_TAIL = 0xAB;
        private void parse_SDS(byte[] raw_input)
        {
            // packet format: AA C0 PM25_Low PM25_High PM10_Low PM10_High 0 0 CRC AB
            if (raw_input.Count() != 10) return;
            if (raw_input[0] != SDS_HEADER1 || raw_input[1] != SDS_HEADER2 || raw_input[9] != SDS_TAIL) return;

            byte crc = 0;
            for(int i=0; i<6; i++)
            {
                crc += raw_input[i + 2];
            }
            if (crc != raw_input[8]) return;  // error with CRC


            float pm25 = 0, pm10 = 0;

            pm25 = (float)((int)raw_input[2] | (int)(raw_input[3] << 8)) / 10;
            pm10 = (float)((int)raw_input[4] | (int)(raw_input[5] << 8)) / 10;

            update("SDS021", pm10, pm25);
        }

        const byte PMS_HEADER1 = 0x42;
        const byte PMS_HEADER2 = 0x4D;
        private void parse_PMS(byte[] raw_input)
        {
            // datasheet : https://drive.google.com/file/d/0B6jowxS0fbXsQi1MSHR5UzFPa3c/view
            // packet format: 42 4D CF_1.0_High CF_1.0_Low ...
            if (raw_input.Count() != 32) return;
            if (raw_input[0] != PMS_HEADER1 || raw_input[1] != PMS_HEADER2) return;

            Func<int, int> parse = (index) =>
            {
                return (int)(raw_input[index] << 8) + (int)raw_input[index + 1];
            };

            int check_sum = 0;
            for (int i = 0; i < 30; i++)
            {
                check_sum += raw_input[i];
            }
            int in_check_sum = parse(30);   // [30:31] checksum bytes

            if (check_sum != in_check_sum) return;  // error with checksum

            int[] CF_data = new int[3];
            int[] Air_data = new int[3];
            int[] raw_particle = new int[6];


            Action<int[], int, int> parse2array = (dset, length, start_index) =>
            {
                for (int i = 0; i < length; i++)
                {
                    dset[i] = parse(start_index + (i * 2));
                }
            };

            parse2array(CF_data,        3, 4);
            parse2array(Air_data,       3, 10);
            parse2array(raw_particle,   6, 16);            
            
            Console.WriteLine("{0}, {1},version = {2}, bug = {3}", raw_input[2], raw_input[3], raw_input[28], raw_input[29]);
            
            if (raw_input[28] == 114)    // PMS-5003 or 1003
                update("PMS5003", Air_data[2], Air_data[1], Air_data[0]);
            if (raw_input[28] == 128)    // PMS-7003
            {
                update("PMS7003", Air_data[2], Air_data[1], Air_data[0]);

                if (checkBox_PMS_raw.Checked)
                {
                    string s_log = String.Format(LOG_LINE[1], DateTime.Now.ToString(TIME_FORMAT[0]), CF_data[2], CF_data[1], CF_data[0]);
                    update_log("PMS7003_CF", s_log);
                    s_log = String.Format(LOG_LINE[2], DateTime.Now.ToString(TIME_FORMAT[0]), raw_particle[0], raw_particle[1], raw_particle[2], raw_particle[3], raw_particle[4], raw_particle[5]);
                    update_log("PMS7003_Raw", s_log);
                }
            }
        }
        #endregion
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            AbortThread = true;

            if (serialPort1.IsOpen)
                    serialPort1.Close();            
        }

        private DustSensorViewer.Filter.AverageFilter Filter_pm10;
        private DustSensorViewer.Filter.AverageFilter Filter_pm25;
        private DustSensorViewer.Filter.AverageFilter Filter_pm1;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            chart1.Invoke(new Action(delegate ()
            {
                while (chart1.Series.Count > 3)
                {
                    chart1.Series.RemoveAt(chart1.Series.Count - 1);
                }
            }));

            Filter_pm10 = new Filter.AverageFilter((int)numericUpDown1.Value);
            Filter_pm25 = new Filter.AverageFilter((int)numericUpDown1.Value);
            Filter_pm1 = new Filter.AverageFilter((int)numericUpDown1.Value);
        }

        private void checkBox_filter_CheckedChanged(object sender, EventArgs e)
        {
            if(!checkBox_filter.Checked)
            {
                chart1.Invoke(new Action(delegate ()
                {
                    while (chart1.Series.Count > 3)
                    {
                        chart1.Series.RemoveAt(chart1.Series.Count - 1);
                    }
                }));
            }
        }

        private void numericUpDown_chartX_ValueChanged(object sender, EventArgs e)
        {
            chart1.Invoke(new Action(delegate ()
            {
                chart1.ChartAreas[0].AxisX.Maximum = (int)numericUpDown_chartX.Value + 1;
                chart1.Update();
            }));
        }
    }
}
