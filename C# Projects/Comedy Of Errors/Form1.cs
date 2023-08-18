using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comedy_Of_Errors
{
    public partial class ComedyOfErros_Shubhang : Form
    {
        public ComedyOfErros_Shubhang()
        {
            InitializeComponent();
            HULK.Visible = false;   
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)

        {
            if (HULK.Visible == false)
            {
                HULK.Visible = true;
                Vision.Visible = false;
                button1.Text = "Play it Again";

            }
            else
            {
                HULK.Visible = false;
                Vision.Visible = true;
                button1.Text = "Click Image for Punch Line";
            }
        }
    }
}
