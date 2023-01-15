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

namespace ADOForm
{
    public partial class userfix : Form
    {


        private int intID; //ID 필드 설정
        private string strCommand;
        //데이터 삭제, 추가, 업데이트 인지를 설정할 문자열 필드
        private OracleConnection odpConn = new OracleConnection();
        public int getintID
        { get { return intID; } }
        public string getstrCommand
        { get { return strCommand; } }

        private void showDataGridView() //사용자 정의 함수
        {
            try
            {
                odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
                odpConn.Open();
                OracleDataAdapter oda = new OracleDataAdapter();
                oda.SelectCommand = new OracleCommand("SELECT * from user_t", odpConn);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                odpConn.Close();
                DBGrid.DataSource = dt;
                DBGrid.AutoResizeColumns();
                DBGrid.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
                DBGrid.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
                DBGrid.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("에러 발생 : " + ex.ToString());
                odpConn.Close();
            }
        }
        public userfix()
        {
            InitializeComponent();
            this.CenterToScreen();

            this.ContextMenuStrip = contextMenuStrip1;

        }

        private void 정보수정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            strCommand = "업데이트";
            intID = Convert.ToInt32(DBGrid.SelectedCells[0].Value);
            Userfixcon form2 = new Userfixcon(this);
            form2.ShowDialog();
            form2.Dispose();
            showDataGridView();
        }

        private void 정보삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            strCommand = "삭제";
            intID = Convert.ToInt32(DBGrid.SelectedCells[0].Value);

            Userfixcon form2 = new Userfixcon(this);
            form2.ShowDialog();
            form2.Dispose();
            showDataGridView();
        }

        private void 정보등록ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            strCommand = "추가";
            Userfixcon form2 = new Userfixcon(this);
            form2.ShowDialog();
            form2.Dispose();
            showDataGridView();
        }

        private void userfix_Load(object sender, EventArgs e)
        {
            showDataGridView();
        }
    }
}
