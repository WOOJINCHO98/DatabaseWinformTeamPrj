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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ADOForm
{
    public partial class Userfixcon : Form
    {
        private OracleConnection odpConn = new OracleConnection();
        userfix _parent;
        public Userfixcon(userfix parent)
        {
            InitializeComponent();
            this.CenterToScreen();

            _parent = parent;

        }

        private void initialTextBoxes()//사용자 함수 정의
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";

            odpConn.Open();
            string strqry = "select * from user_t where userCode=:userCode";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);
            OraCmd.Parameters.Add("userCode", OracleDbType.Int32).Value = _parent.getintID;
            OracleDataReader odr = OraCmd.ExecuteReader();
            while (odr.Read())
            {
                txtid.Text = Convert.ToString(odr.GetValue(0));
                txtid2.Text = Convert.ToString(odr.GetValue(1));
                txtpas.Text = Convert.ToString(odr.GetValue(2));
                txtem.Text = Convert.ToString(odr.GetValue(3));
                dateTimePicker1.Value = Convert.ToDateTime(odr.GetValue(4));
                dateTimePicker2.Value = Convert.ToDateTime(odr.GetValue(5));
                txtname.Text = Convert.ToString(odr.GetValue(6));
                txtadd.Text = Convert.ToString(odr.GetValue(7));
                txtpho.Text = Convert.ToString(odr.GetValue(8));
                txtgr.Text = Convert.ToString(odr.GetValue(9));
                txtvpm.Text = Convert.ToString(odr.GetValue(10));
                txtadm.Text = Convert.ToString(odr.GetValue(11));

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

        private int INSERTRow()//사용자 함수 정의
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";

            odpConn.Open();
            string strqry = "INSERT INTO user_t VALUES (:userCode,:userId,:password,:email,:birth,:registerDate,:name,:address,:phoneNum,:userGrade,:viewPerMonth,:userMod)";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);


            OraCmd.Parameters.Add("userCode", OracleDbType.Int32).Value = txtid.Text.Trim();
            OraCmd.Parameters.Add("userId", OracleDbType.Varchar2, 20).Value = txtid2.Text.Trim();
            OraCmd.Parameters.Add("password", OracleDbType.Varchar2, 20).Value = txtpas.Text.Trim();
            OraCmd.Parameters.Add("email", OracleDbType.Varchar2, 20).Value = txtem.Text.Trim();
            OraCmd.Parameters.Add("birth", OracleDbType.Date, 40).Value = dateTimePicker1.Value;
            OraCmd.Parameters.Add("registerDate", OracleDbType.Date, 40).Value = dateTimePicker2.Value;
            OraCmd.Parameters.Add("name", OracleDbType.Varchar2, 20).Value = txtname.Text.Trim();
            OraCmd.Parameters.Add("address", OracleDbType.Varchar2, 40).Value = txtadd.Text.Trim();
            OraCmd.Parameters.Add("phoneNum", OracleDbType.Varchar2, 20).Value = txtpho.Text.Trim();
            OraCmd.Parameters.Add("userGrade", OracleDbType.Varchar2, 20).Value = txtgr.Text.Trim();
            OraCmd.Parameters.Add("viewPerMonth", OracleDbType.Int32).Value = txtvpm.Text.Trim();
            OraCmd.Parameters.Add("userMod", OracleDbType.Int16).Value = txtadm.Text.Trim();
            return OraCmd.ExecuteNonQuery(); //추가되는 행수 반환

        }
        private int DELETERow() //사용자 함수 정의
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";

            odpConn.Open();
            string strqry = "DELETE FROM user_t WHERE userCode=:id";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);
            OraCmd.Parameters.Add("id", OracleDbType.Int32).Value = _parent.getintID;
            return OraCmd.ExecuteNonQuery();
        }
        private int UPDATERow() //사용자 함수 정의
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";

            odpConn.Open();
            string strqry = "UPDATE user_t SET userId=:userId,password=:password,email=:email,birth=:birth,registerDate=:registerDate,name=:name,address=:address,phoneNum=:phoneNum,userGrade=:userGrade,viewPerMonth=:viewPerMonth,userMod=:userMod WHERE userCode=:id";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);
            OraCmd.Parameters.Add("userId", OracleDbType.Varchar2, 20).Value = txtid2.Text.Trim();
            OraCmd.Parameters.Add("password", OracleDbType.Varchar2, 20).Value = txtpas.Text.Trim();
            OraCmd.Parameters.Add("email", OracleDbType.Varchar2, 20).Value = txtem.Text.Trim();
            OraCmd.Parameters.Add("birth", OracleDbType.Date, 30).Value = dateTimePicker1.Value;
            OraCmd.Parameters.Add("registerDate", OracleDbType.Date, 30).Value = dateTimePicker2.Value;
            OraCmd.Parameters.Add("name", OracleDbType.Varchar2, 20).Value = txtname.Text.Trim();
            OraCmd.Parameters.Add("address", OracleDbType.Varchar2, 30).Value = txtadd.Text.Trim();
            OraCmd.Parameters.Add("phoneNum", OracleDbType.Varchar2, 20).Value = txtpho.Text.Trim();
            OraCmd.Parameters.Add("userGrade", OracleDbType.Varchar2, 20).Value = txtgr.Text.Trim();
            OraCmd.Parameters.Add("viewPerMonth", OracleDbType.Int32).Value = txtvpm.Text.Trim();
            OraCmd.Parameters.Add("userMod", OracleDbType.Int16).Value = txtadm.Text.Trim();
            OraCmd.Parameters.Add("id", OracleDbType.Int32).Value = _parent.getintID;
            return OraCmd.ExecuteNonQuery(); //업데이트되는 행수 반환
        }

        private void Userfixcon_Load(object sender, EventArgs e)
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
