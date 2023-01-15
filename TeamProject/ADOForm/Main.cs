using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOForm
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Moviefix form2 = new Moviefix();
            form2.ShowDialog();
            form2.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reservfix form2 = new Reservfix();
            form2.ShowDialog();
            form2.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userfix form2 = new userfix();
            form2.ShowDialog();
            form2.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dispose();

        }

        private void Main_Load(object sender, EventArgs e)
        {
            Login Parent = (Login)Owner;
            label1.Text = ("Logged in : " + Parent.IdBox.Text);
        }
    }
}
