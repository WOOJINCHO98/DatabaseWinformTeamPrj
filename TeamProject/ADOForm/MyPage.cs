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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ADOForm
{
    public partial class MyPage : Form
    {

        string selectedReservcode;
        string userCode;
        public MyPage(string userCode)
        {
            InitializeComponent();
            this.CenterToScreen();

            this.userCode = userCode;
        }

        private void MyPage_Load(object sender, EventArgs e)
        {
            string connectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
            OracleConnection myConnection = new OracleConnection(connectionString);

            string commandString = "select m.title as 영화제목, s.scrdate as 상영날짜, r.reservnum as 예약번호, r.cardnum as 카드번호, r.confirmMsg as 확인메시지, r.bankName as 은행명, r.AccountNum as 입금계좌번호, r.carrier as 결제통신사, r.phoneNum as 결제전화번호, r.reservcode as 예약식별번호 from reservation r, screening s, movie m where r.scrcode = s.scrcode AND s.moviecode = m.movieCode AND userCode = :userCode";

            OracleCommand myCommand = new OracleCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = commandString;

            myCommand.Parameters.Add(new OracleParameter("userCode",
                        OracleDbType.Int64,
                        userCode,
                        ParameterDirection.Input
                        )
                        );
            myConnection.Open(); //

            OracleDataReader MR;
            MR = myCommand.ExecuteReader();



            DataTable dataTable = new DataTable();
            dataTable.Load(MR);


            dataGridView1.DataSource= dataTable;

            myConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
            OracleConnection myConnection = new OracleConnection(connectionString);

            string commandString = "delete from reservation where reservcode = :1";

            OracleCommand myCommand = new OracleCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = commandString;


            myCommand.Parameters.Add(new OracleParameter("1",
                                    OracleDbType.Int64,
                                    selectedReservcode,
                                    ParameterDirection.Input
                                    )
                                    );

            myConnection.Open(); //

            OracleDataReader MR;

            MR = myCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(MR);
            dataGridView1.DataSource = dataTable;


            MyPage frm1 = new MyPage(userCode);
            this.Visible = false;
            frm1.Owner = this;
            frm1.ShowDialog();
            frm1.Dispose();





        }

        private void search_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {



            int rowIndex = dataGridView1.CurrentRow.Index;

            selectedReservcode = dataGridView1.Rows[rowIndex].Cells[9].Value.ToString();

            MessageBox.Show(selectedReservcode);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int rowIndex = dataGridView1.CurrentRow.Index;

            selectedReservcode = dataGridView1.Rows[rowIndex].Cells[9].Value.ToString();


        }
    }
}
