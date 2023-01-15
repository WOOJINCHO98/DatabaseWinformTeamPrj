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

    public partial class UserMain : Form
    {

        public string userCode;

        public UserMain(string userCode)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.userCode = userCode;
        }

        private void BookingBtn_Click(object sender, EventArgs e)
        {

            Booking frm1 = new Booking(userCode);
            frm1.Owner = this;
            frm1.ShowDialog();
            frm1.Dispose();
        }

        private void MypageBtn_Click(object sender, EventArgs e)
        {

            MyPage frm1 = new MyPage(userCode);
            frm1.Owner = this;
            frm1.ShowDialog();
            frm1.Dispose();
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void UserMain_Load(object sender, EventArgs e)
        {
            Login Parent = (Login)Owner;
            label7.Text = ("Logged in : " + Parent.IdBox.Text);
        }

        private void ProInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgramInfo frm1 = new ProgramInfo();
            frm1.Owner = this;
            frm1.ShowDialog();
            frm1.Dispose();
        }
    }
}
