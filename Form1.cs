﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace _1025
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Query";
        }

        //private void

        static void main(String[] args)
        {
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'linktoDataSet.unit' 테이블에 로드합니다. 필요한 경우 이 코드를 이동하거나 제거할 수 있습니다.
            this.unitTableAdapter.Fill(this.linktoDataSet.unit);

            DataSet ds = new DataSet();
            string strConn = "Server=localhost;Database=linkto;Uid=root;Pwd=apstinc;";

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                string sql = "SELECT * FROM unit where ItemID ='FIC001.CO' limit 50";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                conn.Close();
                adpt.Fill(ds);
                adpt.Dispose();
                /*  while (rdr.Read())
                  {
                     // Console.WriteLine("{0}: {1}", rdr["ItemID"], rdr["ItemTimeStamp"]);
                  }*/
                rdr.Close();


            }
            Console.WriteLine("Before Merge: {0}", ds.Tables[0].Rows.Count);
            System.Threading.Thread.Sleep(1000);
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                Console.WriteLine("{0}:{1}", r["ItemID"], r["ItemTimeStamp"]);
            }
            System.Threading.Thread.Sleep(10000);
            //Console.WriteLine("{0}", ds.Tables[0].Rows[0]);
            Console.WriteLine("{0}", ds.Tables[0]);
            string[] data = { "사과", "토마토", "포도", "배", "복숭아" };
            comboBox1.Items.AddRange(data);
            

            comboBox1.SelectedIndex = 0;
          


        }
        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            Console.WriteLine("Changed");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void input_Click(object sender, EventArgs e)
        {
           
           
        }

        
        private List<double> _valueList1;

        private void SetChart()
        {
            chart1.ChartAreas[0].AxisX.IsStartedFromZero = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisX.ScaleView.SizeType = DateTimeIntervalType.Seconds;
            chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;
            chart1.ChartAreas[0].AxisX.Interval = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 100; //Y축의 높이
            _valueList1 = new List<double>();
            DateTime now = DateTime.Now;
            chart1.ChartAreas[0].AxisX.Minimum = now.ToOADate();
            chart1.ChartAreas[0].AxisX.Maximum = now.AddSeconds(60).ToOADate();
        }

        private void AddData()
        {
            //_valueList1.Add(System.DateTime.Now.Second);
            _valueList1.Add(new Random().Next(0, 100));
            DateTime now = DateTime.Now;
            if (chart1.Series[0].Points.Count > 0)
            {
                while (chart1.Series[0].Points[0].XValue < now.AddSeconds(-60).ToOADate())
                {
                    chart1.Series[0].Points.RemoveAt(0);
                    chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points[0].XValue;
                    chart1.ChartAreas[0].AxisX.Maximum = now.AddSeconds(0).ToOADate();
                }
            }
            chart1.Series[0].Points.AddXY(now.ToOADate(), _valueList1[_valueList1.Count - 1]);
            chart1.Invalidate();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            AddData();
        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                btn_go.Text = "GO";
            }
            else
            {
                SetChart();
                timer1.Interval = 1000;
                timer1.Start();
                btn_go.Text = "STOP";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            //  ComboBox comboBox = (ComboBox)sender;

        }


    }
}
