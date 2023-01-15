using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
namespace ADOForm
{
    public partial class Form2 : Form
    {
        new  Form1 Parent;
        DBClass dbc = new DBClass(); //*****DBClass 객체 생성






        // 추가, 수정, 삭제시에 필요한 명령문을 
        // 자동으로 작성해주는 객체입니다.
        OracleCommandBuilder myCommandBuilder;


        // 수정, 삭제할 때 필요한 레코드의 키값을 보관할 필드
        private int SelectedKeyValue;

        private void ClearTextBoxes()
        {
            txtid.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtMail.Clear();
        }
        private void DB_Open()
        {
            try
            {
                string connectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION =   (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))   (CONNECT_DATA =     (SERVER = DEDICATED)     (SERVICE_NAME = xe)   ) );";

                string commandString = "select * from Phone";

                dbc.DBAdapter = new OracleDataAdapter(commandString, connectionString);
                myCommandBuilder = new OracleCommandBuilder(dbc.DBAdapter);

                dbc.DS = new DataSet();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }
        public Form2()
        {
            InitializeComponent();
            dbc.DB_ObjCreate(); //*****
            dbc.DB_Open();//*****
        }

        private void UpBtn_Click(object sender, EventArgs e)
        {
            if (NameList.SelectedIndex != 0)
            {
                NameList.SelectedIndex = NameList.SelectedIndex - 1;
            }
            else
            {
                MessageBox.Show("이곳은 레코드의 처음입니다.");
            }
        }

        private void DownBtn_Click(object sender, EventArgs e)
        {
            if (NameList.SelectedIndex != NameList.Items.Count - 1)
            {
                NameList.SelectedIndex = NameList.SelectedIndex + 1;
            }
            else
            {
                MessageBox.Show("이곳은 레코드의 마지막입니다.");
            }
        }

        private void NameList_SelectedIndexChanged(object sender, EventArgs e)
        {
             //DS.Clear();
             //DBAdapter.Fill(DS, "Phone");
            Parent = (Form1)Owner;
            dbc.UserTable = dbc.DS.Tables["Phone"];

            DataRow[] ResultRows = dbc.UserTable.Select("PName like '%" + Parent.TxtS + "%'");

            DataColumn[] PrimaryKey = new DataColumn[1];
            PrimaryKey[0] = dbc.UserTable.Columns["id"];
            dbc.UserTable.PrimaryKey = PrimaryKey;

            DataRow currRow = dbc.UserTable.Rows.Find(NameList.Text.Substring(0, 2));

            SelectedKeyValue = Convert.ToInt32(currRow["id"].ToString());
            txtid.Text = currRow["id"].ToString();
            txtName.Text = currRow["PName"].ToString();
            txtMail.Text = currRow["Email"].ToString();
            txtPhone.Text = currRow["Phone"].ToString(); 
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dbc.DS.Clear();
            dbc.DBAdapter.Fill(dbc.DS, "Phone");
            Parent = (Form1)Owner;
            dbc.UserTable = dbc.DS.Tables["Phone"];

            DataRow[] ResultRows
                = dbc.UserTable.Select("PName like '%" + Parent.TxtS + "%'");

            NameList.Items.Clear();

            foreach (DataRow currRow in ResultRows)
            {
                NameList.Items.Add(currRow["Id"].ToString()
                    + " " + currRow["PName"].ToString());
            }	
        }
    }
}
