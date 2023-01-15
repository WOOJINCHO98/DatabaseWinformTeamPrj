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
    public partial class Moviefixcon : Form
    {
        private OracleConnection odpConn = new OracleConnection();
        Moviefix _parent;
        public Moviefixcon(Moviefix mform)
        {
            InitializeComponent();
            this.CenterToScreen();

            _parent = mform;
        }

        private int INSERTRow()//사용자 함수 정의
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";

            odpConn.Open();
            string strqry = "INSERT INTO movie VALUES (:movieCode,:title,:director,:mainActor,:janre,:releaseDate,:endDate,:ageLimit,:runtime,:numOfSpect,:explanation)";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);
            OraCmd.Parameters.Add("movieCode", OracleDbType.Int32).Value = txtid.Text.Trim();
            OraCmd.Parameters.Add("title", OracleDbType.Varchar2, 20).Value = txti.Text.Trim();
            OraCmd.Parameters.Add("director", OracleDbType.Varchar2, 40).Value = txtdir.Text.Trim();
            OraCmd.Parameters.Add("mainActor", OracleDbType.Varchar2, 40).Value = txtact.Text.Trim();
            OraCmd.Parameters.Add("janre", OracleDbType.Varchar2, 20).Value = txtjan.Text.Trim();
            OraCmd.Parameters.Add("releaseDate", OracleDbType.Varchar2, 20).Value = txtrel.Text.Trim();
            OraCmd.Parameters.Add("endDate", OracleDbType.Varchar2, 20).Value = txtend.Text.Trim();
            OraCmd.Parameters.Add("ageLimit", OracleDbType.Int32).Value = txtage.Text.Trim();
            OraCmd.Parameters.Add("runtime", OracleDbType.Int32).Value = txtrun.Text.Trim();
            OraCmd.Parameters.Add("numOfSpect", OracleDbType.Int32).Value = txtnos.Text.Trim();
            OraCmd.Parameters.Add("explanation", OracleDbType.Varchar2, 200).Value = txtexp.Text.Trim();
            return OraCmd.ExecuteNonQuery(); //추가되는 행수 반환
        }
        private int DELETERow() //사용자 함수 정의
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";

            odpConn.Open();
            string strqry = "DELETE FROM movie WHERE movieCode=:id";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);
            OraCmd.Parameters.Add("id", OracleDbType.Int32).Value
            = _parent.getintID;
            return OraCmd.ExecuteNonQuery();
        }
        private int UPDATERow() //사용자 함수 정의
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";

            odpConn.Open();
            string strqry = "UPDATE movie SET title=:title,director=:director,mainActor=:mainActor,janre=:janre,releaseDate=:releaseDate,endDate=:endDate,ageLimit=:ageLimit,runtime=:runtime,numOfSpect=:numOfSpect,explanation=:explanation WHERE movieCode=:id";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);
            OraCmd.Parameters.Add("title", OracleDbType.Varchar2, 20).Value = txti.Text.Trim();
            OraCmd.Parameters.Add("director", OracleDbType.Varchar2, 40).Value = txtdir.Text.Trim();
            OraCmd.Parameters.Add("mainActor", OracleDbType.Varchar2, 40).Value = txtact.Text.Trim();
            OraCmd.Parameters.Add("janre", OracleDbType.Varchar2, 20).Value = txtjan.Text.Trim();
            OraCmd.Parameters.Add("releaseDate", OracleDbType.Varchar2, 20).Value = txtrel.Text.Trim();
            OraCmd.Parameters.Add("endDate", OracleDbType.Varchar2, 20).Value = txtend.Text.Trim();
            OraCmd.Parameters.Add("ageLimit", OracleDbType.Int32).Value = txtage.Text.Trim();
            OraCmd.Parameters.Add("runtime", OracleDbType.Int32).Value = txtrun.Text.Trim();
            OraCmd.Parameters.Add("numOfSpect", OracleDbType.Int32).Value = txtnos.Text.Trim();
            OraCmd.Parameters.Add("explanation", OracleDbType.Varchar2, 200).Value = txtexp.Text.Trim();
            OraCmd.Parameters.Add("id", OracleDbType.Int32).Value =
           _parent.getintID;
            return OraCmd.ExecuteNonQuery(); //업데이트되는 행수 반환
        }
        private void initialTextBoxes()//사용자 함수 정의
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";

            odpConn.Open();
            string strqry = "select * from movie where movieCode=:movieCode";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);
            OraCmd.Parameters.Add("movieCode", OracleDbType.Int32).Value = _parent.getintID;
            OracleDataReader odr = OraCmd.ExecuteReader();
            while (odr.Read())
            {
                txtid.Text = Convert.ToString(odr.GetValue(0));
                txti.Text = Convert.ToString(odr.GetValue(1));
                txtdir.Text = Convert.ToString(odr.GetValue(2));
                txtact.Text = Convert.ToString(odr.GetValue(3));
                txtjan.Text = Convert.ToString(odr.GetValue(4));
                txtrel.Text = Convert.ToString(odr.GetValue(5));
                txtend.Text = Convert.ToString(odr.GetValue(6));
                txtage.Text = Convert.ToString(odr.GetValue(7));
                txtrun.Text = Convert.ToString(odr.GetValue(8));
                txtnos.Text = Convert.ToString(odr.GetValue(9));
                txtexp.Text = Convert.ToString(odr.GetValue(10));
            }
            odr.Close();
            odpConn.Close();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (btnOK.Text == "추가")
            {
                if (INSERTRow() > 0)
                {
                    MessageBox.Show("정상적으로 데이터 행이 추가됨.");
                }
                else MessageBox.Show("데이터 행이 추가되지 않음!");
                this.Close();
            }
            else if (btnOK.Text == "삭제")
            {
                if (DELETERow() > 0)
                {
                    MessageBox.Show("정상적으로 데이터 행이 삭제됨!");
                }
                else MessageBox.Show("데이터 행이 삭제되지 않음!");
                this.Close();
            }
            else
            {
                if (UPDATERow() > 0)
                {
                    MessageBox.Show("정상적으로 데이터가 업데이트됨!");
                }
                else MessageBox.Show("데이터 행이 업데이트되지 않음!");
                this.Close();
            }
        }

        private void Moviefixcon_Load(object sender, EventArgs e)
        {
            if (_parent.getstrCommand == "삭제")
            {
                btnOK.Text = "삭제";
                txtid.Enabled = false;
                initialTextBoxes();
            }
            else if (_parent.getstrCommand == "업데이트")
            {
                btnOK.Text = "업데이트";
                txtid.Enabled = false;
                initialTextBoxes();
            }
            else btnOK.Text = "추가";
        }
    }
}
