using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CARD
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = "C:\\Users\\User\\source\\repos\\CARD\\Assets\\WastedSound.wav";
            player.Play();
        }
    }
}
