using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CARD
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox1.Enabled = false;
            groupBox2.Visible = true;
            groupBox2.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox2.Enabled = false;
            groupBox1.Visible = true;
            groupBox1.Enabled = true;
        }
    }
}
