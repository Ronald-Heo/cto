using System;
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
        public string strConn = "Server=localhost;Database=linkto;Uid=root;Pwd=apstinc;";
        public string tagName = " ";

        
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'linktoDataSet.unit' 테이블에 로드합니다. 필요한 경우 이 코드를 이동하거나 제거할 수 있습니다.
            this.unitTableAdapter.Fill(this.linktoDataSet.unit);

            DataSet ds = new DataSet();
            //string strConn = "Server=localhost;Database=linkto;Uid=root;Pwd=apstinc;";

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                string sql = "SELECT Distinct ItemID FROM unit limit 50";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                conn.Close();
                adpt.Fill(ds);
                adpt.Dispose();
                /*  while (rdr.Read())
                  {
                     // Console.WriteLine("{0}", rdr["ItemID"]);
                  }*/
                rdr.Close();


            }
            Console.WriteLine("Before Merge: {0}", ds.Tables[0].Rows.Count);
            System.Threading.Thread.Sleep(1000);

            //데이터베이스 목록 드롭다운에 넣기
            List<string> tableList = new List<string>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                string list = r["ItemID"].ToString();
                tableList.Add(list);
            }
            
            //System.Threading.Thread.Sleep(10000);
            //Console.WriteLine("{0}", ds.Tables[0].Rows[0]);
            Console.WriteLine("{0}", ds.Tables[0]);
            string[] data = tableList.ToArray();
            comboBox1.Items.AddRange(data);
            comboBox1.SelectedIndex = 0;


        

        }
        

        private void _start_Click(object sender, EventArgs e)
        {
            //컨트롤 타이머 시작
            timer1.Start();
            //시스템 타이머 시작
            //timer.Start();
        }

        private void _stop_Click(object sender, EventArgs e)
        {
            //컨트롤 타이머 중지
            timer1.Stop();
            //시스템 타이머 중지
            //timer.Stop();
        }





        private void chart1_Click(object sender, EventArgs e)
        {

        }

        
        public void input_Click(object sender, EventArgs e)
        {

            DataSet ds2 = new DataSet();
            //string strConn = "Server=localhost;Database=linkto;Uid=root;Pwd=apstinc;";


                MySqlConnection conn = new MySqlConnection(strConn);
            
                conn.Open();

                string sql = "SELECT * FROM unit where ItemID = @tagName limit 500";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlParameter paramTagName = new MySqlParameter("@tagName", MySqlDbType.Text);
                paramTagName.Value = tagName;

                // SqlCommand 객체의 Parameters 속성에 추가
                cmd.Parameters.Add(paramTagName);

                MySqlDataAdapter adpter = new MySqlDataAdapter(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
           
            while (rdr.Read())
                {
                    double listvalue = Convert.ToDouble(rdr["ItemCurrentValue"]);
                    DateTime timestamp = Convert.ToDateTime(rdr["ItemTimeStamp"].ToString());
                _valueList2.Add(listvalue);
                _valueList3.Add(timestamp);
                    
                    
                }
                rdr.Close();
           for(int i=0; i<_valueList2.Count; i++)
            {
                Console.WriteLine("{0}:{1}", _valueList2[i], _valueList3[i]);
            }
            Console.WriteLine("{0}//{1}", _valueList3[3].ToOADate(), _valueList3[3]-TimeSpan.FromSeconds(10000));

        }

        public List<double> _valueList2 = new List<double>();
        public List<DateTime> _valueList3 = new List<DateTime>();
        private List<double> _valueList1;

        private void SetChart()
        {
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 500;
            chart1.ChartAreas[0].AxisX.Interval = 2;
            chart1.ChartAreas[0].AxisY.Minimum = 48;
            chart1.ChartAreas[0].AxisY.Maximum = 54; //Y축의 높이
            _valueList1 = new List<double>();
            DateTime now = DateTime.Now;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 1000;
            // Set scrollbar enable
            chart1.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
        }
        public int s = 0;
        private void AddData()
        {
            // chart1.ChartAreas[0].AxisX.IsStartedFromZero = true;
            // chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            // chart1.ChartAreas[0].AxisX.ScaleView.SizeType = DateTimeIntervalType.Seconds;
            //chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            // chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;

            int t = s++;
            chart1.Series[0].Points.AddXY(t, _valueList2[t]);
            chart1.Invalidate();

            //chart1.Series[0].XValueType = ChartValueType.DateTime;
            //chart1.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd";
           
            //chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;
            
            chart1.ChartAreas[0].AxisX.Minimum = t-100;
            chart1.ChartAreas[0].AxisX.Maximum = t;
            chart1.ChartAreas[0].AxisX.Interval = 100;
            chart1.ChartAreas[0].AxisY.Minimum = _valueList2.Min();
            chart1.ChartAreas[0].AxisY.Maximum = _valueList2.Max(); //Y축의 높이
            _valueList1 = new List<double>();
            
            // Set scrollbar enable
            chart1.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            if (chart1.Series[0].Points.Count > 100)
            {
                chart1.Series[0].Points.RemoveAt(0);
                

            }

            //_valueList1.Add(System.DateTime.Now.Second);

            
            

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
            ComboBox comboBox = (ComboBox)sender;
            textBox2.Text = (string)comboBox.SelectedItem;
            tagName = (string)comboBox.SelectedItem;

        }

        private void transfer_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(textBox3.Text);
           
            frm2.Show();
            

        }
       

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void _zoominX_Click(object sender, EventArgs e)
        {
            //X축 확대
            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(40, 60);
        }

        private void _zoominY_Click(object sender, EventArgs e)
        {
            //Y축 확대
            chart1.ChartAreas[0].AxisY.ScaleView.Zoom(40, 60);
        }
    }
}
