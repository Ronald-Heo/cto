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

    public partial class Form2 : Form
    {
  
        
        public Form2(string DataRecived)
        {

            InitializeComponent();
            label1.Text = DataRecived;

        }
        private void Form2_Load(object sender, EventArgs e)
        {
          
        }

        public List<double> _value;
        public List<string> _timestamp;


        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        
    }
}
