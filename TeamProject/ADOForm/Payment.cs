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

namespace ADOForm
{
    public partial class Payment : Form
    {
        int adultCount;
        int teenCount;
        string movieTitle;
        string selectedDate, selectedTime;
        string selectedRoom;
        string selectedRow, selectedCol;
        string userCode;
        string scrcode;
        public Payment(int adultCount,int teenCount, string movieTitle,string selectedDate, string selectedTime, string selectedRoom, string selectedRow, string selectedCol, string userCode, string scrcode)
        {
            InitializeComponent();
            this.CenterToScreen();

            this.adultCount = adultCount;
            this.teenCount = teenCount;
            this.movieTitle = movieTitle;
            this.selectedDate = selectedDate;
            this.selectedTime = selectedTime;
            this.selectedRoom = selectedRoom;
            this.selectedRow = selectedRow;
            this.selectedCol = selectedCol;
            this.userCode = userCode;
            this.scrcode = scrcode;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) { 
                checkBox2.Checked = false; 
                checkBox3.Checked = false;


                label7.Text = "신용/체크카드";
                label8.Text = "카드번호";
                label9.Text = "비밀번호";
                label10.Visible= true;
                label10.Text = "결제확인 메시지";


                cardNumBox.Visible = true;
                cardPasswordBox.Visible = true;
                confirmMsgBox.Visible = true;
                bankNameBox.Visible = false;
                accountNumBox.Visible = false;
                MobileCarrierBox.Visible = false;
                phoneNumBox.Visible = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;

                label7.Text = "계좌이체";
                label8.Text = "은행명";
                label9.Text = "입금 계좌번호";
                label10.Visible= false;

                cardNumBox.Visible = false;
                cardPasswordBox.Visible = false;
                confirmMsgBox.Visible = false;
                bankNameBox.Visible = true;
                accountNumBox.Visible = true;
                MobileCarrierBox.Visible = false;
                phoneNumBox.Visible = false;


            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox1.Checked = false;

                label7.Text = "휴대폰 결제";
                label8.Text = "통신사명";
                label9.Text = "휴대폰 번호";
                label10.Visible = false;

                cardNumBox.Visible = false;
                cardPasswordBox.Visible = false;
                confirmMsgBox.Visible = false;
                bankNameBox.Visible = false;
                accountNumBox.Visible = false;
                MobileCarrierBox.Visible = true;
                phoneNumBox.Visible = true;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random rand = new Random();

            int reservnum = rand.Next(10000, 90000);

            var conn = new OracleConnection("User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );");
            var cmd = new OracleCommand();
            if (checkBox1.Checked == true)
            {
                cmd.CommandText = "INSERT INTO reservation (reservcode, usercode, scrcode, reservnum, cardnum, cardpasswd, confirmMsg) VALUES (NO_SEQ.NEXTVAL, :1, :2, :3, :4, :5, :6)";

                cmd.Parameters.Add(new OracleParameter("1",
                                                        OracleDbType.Int64,
                                                        userCode,
                                                        ParameterDirection.Input
                                                        )
                                                        );
                cmd.Parameters.Add(new OracleParameter("2",
                                                        OracleDbType.Int64,
                                                        scrcode,
                                                        ParameterDirection.Input
                                                        )
                                                        );
                cmd.Parameters.Add(new OracleParameter("3",
                                                        OracleDbType.Int64,
                                                        reservnum,
                                                        ParameterDirection.Input
                                                        )
                                                        );
                cmd.Parameters.Add(new OracleParameter("4",
                                                        OracleDbType.Varchar2,
                                                        cardNumBox.Text,
                                                        ParameterDirection.Input
                                                        )
                                                        );
                cmd.Parameters.Add(new OracleParameter("5",
                                                        OracleDbType.Varchar2,
                                                        cardPasswordBox.Text,
                                                        ParameterDirection.Input
                                                        )
                                                        );
                cmd.Parameters.Add(new OracleParameter("6",
                                                        OracleDbType.Varchar2,
                                                        confirmMsgBox.Text,
                                                        ParameterDirection.Input
                                                        )
                                                        );




            }
            else if (checkBox2.Checked == true) {
                cmd.CommandText = "INSERT INTO reservation (reservcode, usercode, scrcode, reservnum, bankName, AccountNum) VALUES (NO_SEQ.NEXTVAL, :1, :2, :3, :4, :5)";

            }
            else {
                cmd.CommandText = "INSERT INTO reservation (reservcode, usercode, scrcode, reservnum, carrier, phoneNum) VALUES (NO_SEQ.NEXTVAL, :1, :2, :3, :4, :5)";

            }

            cmd.Connection = conn;
            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }
            finally
            {
                conn.Close();
            }


            MessageBox.Show("결제가 완료되었습니다. 감사합니다");
            this.Visible = false;
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            label1.Text = movieTitle;
            // label2 : 예매날짜및시간   label3 몇관 label4 몇열 ,  몇행
            label2.Text = selectedDate + " / " + selectedTime; 
            label3.Text= selectedRoom;




            string[] rowArr = selectedRow.Split(',');
            string[] colArr = selectedCol.Split(',');
            int count = 0;

            count = rowArr.Length-1;
            
            for (int i = 0; i< count; i++)
            {
                label4.Text += rowArr[i]+"행 " + colArr[i]+"열 ";
            }


            //label4.Text = selectedRow + "행,  " + selectedCol + "열";

            label5.Text = "성인    : "+adultCount.ToString()+ " 명    :    "+adultCount*15000+"원";
            label6.Text = "청소년 : "+teenCount.ToString() + " 명    :    "+teenCount*9000+"원";
            label11.Text = "결제 금액         : " + (adultCount * 15000 + teenCount * 9000).ToString()+"원";



            checkBox2.Checked = false;
            checkBox3.Checked = false;


            label7.Text = "신용/체크카드";
            label8.Text = "카드번호";
            label9.Text = "비밀번호";
            label10.Visible = true;
            label10.Text = "결제확인 메시지";


            cardNumBox.Visible = true;
            cardPasswordBox.Visible = true;
            confirmMsgBox.Visible = true;
            bankNameBox.Visible = false;
            accountNumBox.Visible = false;
            MobileCarrierBox.Visible = false;
            phoneNumBox.Visible = false;
            
        }
    }
}
