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
    public partial class basket : Form
    {
        public basket()
        {
            InitializeComponent();
        }


        Login login;
        Register register;
        Form1 form1;
        Main main;

        private void basket_Load(object sender, EventArgs e)
        {
            form1 = new Form1();
            form1.MdiParent = this;
            form1.Show();  //Mdi폼의 자식은 Show()모달리스만 사용 가능           
        }



        private void 종료ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
