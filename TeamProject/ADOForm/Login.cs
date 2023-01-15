using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ADOForm
{
    public partial class Login : Form
    {

        public String userCode;
        private void ClearTextBoxes()
        {
            IdBox.Clear();
            PasswordBox.Clear();
        }
        DBClass dbc = new DBClass(); //*****DBClass 객체 생성
        public Login()
        {
            InitializeComponent();
            this.CenterToScreen();

            dbc.DB_ObjCreate(); //*****
            dbc.DB_Open();//*****
        }


        private void LoginBtn_Click(object sender, EventArgs e)
        {

        }

        private void registerBtn_Click(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {

            if (IdBox.Text.Trim() == "")
            {
                MessageBox.Show("ID를 입력하세요");
                IdBox.Text = "";
                IdBox.Focus();
            }
            else
            {

                string connectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
                OracleConnection myConnection = new OracleConnection(connectionString);

                string commandString = "select userId, password, userMod, userCode password from user_t";

                OracleCommand myCommand = new OracleCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandText = commandString;

                myConnection.Open(); //

                OracleDataReader MR;
                MR = myCommand.ExecuteReader();

                while (MR.Read())
                {


                    if (MR[0].ToString().Equals(IdBox.Text) && MR[1].ToString().Equals(PasswordBox.Text))
                    {
                        if (MR[2].ToString().Equals("1"))
                        {
                            label1.Text = "로그인 성공";

                            MessageBox.Show("안녕하세요 관리자 " + MR[0].ToString() + " 님!");

                            Main frm1 = new Main();
                            frm1.Owner = this;
                            frm1.ShowDialog();
                            frm1.Dispose();

                            break;
                        }
                        else
                        {
                            label1.Text = "로그인 성공";

                            MessageBox.Show("안녕하세요 " + MR[0].ToString() + " 님!");


                            userCode = MR[3].ToString();
                            UserMain frm1 = new UserMain(userCode);
                            frm1.Owner = this;
                            frm1.ShowDialog();
                            frm1.Dispose();


                            break;
                        }
                    }
                    else
                    {
                        label1.Text = "로그인 실패했습니다. 입력하신 값을 다시 확인해주세요";
                    }

                }

                MR.Close();
                myConnection.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Register frm = new Register();
            frm.Owner = this;
            frm.ShowDialog();
            frm.Dispose();
        }
    }
}
