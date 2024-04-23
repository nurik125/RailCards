using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CARD
{
    public partial class Form3 : Form
    {
        public bool Correct = false;
        public bool DataError = false;
        public int info;
        public string[,] LogAndPas = new string[3, 2] {
        {"login1", "password1"}, 
        {"login2", "password2" }, 
        {"login3", "password3" }
        };
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = maskedTextBox1.Text;
            
            for(int i = 0; i < LogAndPas.Length / 2; i++)
            {
                if(LogAndPas[i, 0] == login && password == LogAndPas[i, 1])
                {
                    Correct = true;
                    info = i;
                    this.Close();
                }
                else
                {
                    this.Close();
                    DataError = true;
                }
            }
        }
    }
}
