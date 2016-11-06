using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1025
{
    public partial class newChartWindow : Form
    {
        public newChartWindow()
        {
            InitializeComponent(); 

            public void SetChart()
        {
            chart1.ChartAreas[0].AxisX.IsStartedFromZero = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisX.ScaleView.SizeType = DateTimeIntervalType.Seconds;
            chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;
            chart1.ChartAreas[0].AxisX.Interval = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 100; //Y축의 높이
            //_valueList1 = new List<double>();
            DateTime now = DateTime.Now;
            //chart1.ChartAreas[0].AxisX.Minimum = now.ToOADate();
            //chart1.ChartAreas[0].AxisX.Maximum = now.AddSeconds(60).ToOADate();
        }



        public void AddData()
        {
            //_valueList1.Add(System.DateTime.Now.Second);
            //_valueList1.Add(new Random().Next(0, 100));
            chart1.Series[0].Points.AddXY(0, random.Next(2000, 5000));
            chart1.Series[1].Points.AddXY(0, random.Next(2000, 5000));
            if (chart1.Series[0].Points.Count > 1000)
            {
                chart1.Series[0].Points.RemoveAt(0);
                chart1.Series[1].Points.RemoveAt(0);

            }

            //차트의 X축간격 100, Y축간격 1000
            chart1.ChartAreas[0].AxisX.Interval = 100;
            chart1.ChartAreas[0].AxisY.Interval = 1000;
            //차트의 X축 최소값과 최대값, Y축 최소값과 최대값
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 1000;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 7000;


            chart1.Invalidate();

        }
        public void timer1_Tick(object sender, EventArgs e)
        {
            AddData();

        }

    }



    }
}
