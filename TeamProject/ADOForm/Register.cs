using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ADOForm
{
    public partial class Register : Form
    {



        private int SelectedRowIndex;
        // Data Provider인 DBAdapter 입니다. 
        OracleDataAdapter DBAdapter;
        // DataSet 객체입니다.
        DataSet DS;
        // 추가, 수정, 삭제시에 필요한 명령문을 
        // 자동으로 작성해주는 객체입니다.
        OracleCommandBuilder myCommandBuilder;
        // ataTable 객체입니다.
        DataTable userTable;
        // 수정, 삭제할 때 필요한 레코드의 키값을 보관할 필드
        private int SelectedKeyValue;





        DBClass dbc = new DBClass(); //*****DBClass 객체 생성



        private void ClearTextBoxes()
        {
            txtid.Clear();
            txtPassword1.Clear();
            txtPassword2.Clear();
            txtEmail.Clear();
            txtName.Clear();
            txtAdress.Clear();
            txtPhone.Clear();

        }

        /*
        private void DB_Open()
        {
            try
            {
                string connectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
                string commandString = "select * from user_t";
                DBAdapter = new OracleDataAdapter(commandString, connectionString);
                myCommandBuilder = new OracleCommandBuilder(DBAdapter);
                DS = new DataSet();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }
        */


        public Register()
        {
            InitializeComponent();
            this.CenterToScreen();

            dbc.DB_ObjCreate(); //*****
            dbc.DB_Open();//*****

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (txtPassword1.ToString().Equals(txtPassword2.ToString()))
            {

                try
                {


                    MessageBox.Show("텍스트 상자에 모든 데이터 입력하셨으면 추가합니다!");
                    // DS.Clear();//*

                    //  DBAdapter.Fill(DS, "Phone");//*
                    dbc.UserTable = dbc.DS.Tables["user"];//*
                    DataRow newRow = dbc.UserTable.NewRow();
                    //newRow["userCode"] = Convert.ToInt32(txtCode.Text);
                    newRow["UserId"] = txtid.Text;
                    newRow["Password"] = txtPhone.Text;
                    newRow["Email"] = txtEmail.Text;
                    newRow["Birth"] = dateTimePicker1.Value;
                    newRow["Name"] = (txtName.Text);
                    newRow["Address"] = (txtAdress.Text);
                    newRow["phonenum"] = txtPhone.Text;
                    //newRow["PhoneNum "] = (txtPhone.Text);



                    dbc.UserTable.Rows.Add(newRow);
                    dbc.DBAdapter.Update(dbc.DS, "user");
                    dbc.DS.AcceptChanges();//*
                    ClearTextBoxes();  //*
                    //DBGrid.DataSource = dbc.DS.Tables["user"].DefaultView;

                }
                catch (DataException DE)
                {
                    MessageBox.Show(DE.Message);
                }
                catch (Exception DE)
                {
                    MessageBox.Show(DE.Message);
                }
            }
            else
            {
                MessageBox.Show("1차 비밀번호와 2차 비밀번호의 값이 다릅니다. 비밀번호 확인 해주세요");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                dbc.DS.Clear();
                dbc.DBAdapter.Fill(dbc.DS, "user");
                //DBGrid.DataSource = dbc.DS.Tables["user"].DefaultView;
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        //Convert.ToInt32(txtCode.Text),


        private void registerBtn_Click(object sender, EventArgs e)
        {
            var conn = new OracleConnection("User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );");
            var cmd = new OracleCommand();
            cmd.CommandText = "INSERT INTO user_t (userCode, userId, password, email, birth, name, address, phoneNum) VALUES (NO_SEQ.NEXTVAL, :2, :3, :4, :5, :6, :7, :8)";

            cmd.Parameters.Add(new OracleParameter("2",
                                                OracleDbType.Varchar2,
                                                txtid.Text,
                                                ParameterDirection.Input
                                                )
                                                );
            cmd.Parameters.Add(new OracleParameter("3",
                                    OracleDbType.Varchar2,
                                    txtPassword1.Text,
                                    ParameterDirection.Input
                                    )
                                    );
            cmd.Parameters.Add(new OracleParameter("4",
                                    OracleDbType.Varchar2,
                                    txtEmail.Text,
                                    ParameterDirection.Input
                                    )
                                    );
            cmd.Parameters.Add(new OracleParameter("5",
                                    OracleDbType.Date,
                                    dateTimePicker1.Value,
                                    ParameterDirection.Input
                                    )
                                    );
            cmd.Parameters.Add(new OracleParameter("6",
                        OracleDbType.Varchar2,
                        (txtName.Text),
                        ParameterDirection.Input
                        )
                        );
            cmd.Parameters.Add(new OracleParameter("7",
            OracleDbType.Varchar2,
            txtAdress.Text,
            ParameterDirection.Input
            )
            );
            cmd.Parameters.Add(new OracleParameter("8",
            OracleDbType.Varchar2,
            txtPhone.Text,
            ParameterDirection.Input
            )
            );





            cmd.Connection = conn;
            conn.Open();


            ClearTextBoxes();  //*
            label2.Text = "";



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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
            OracleConnection myConnection = new OracleConnection(connectionString);

            string commandString = "select userId from user_t";

            OracleCommand myCommand = new OracleCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = commandString;

            myConnection.Open(); //

            OracleDataReader MR;
            MR = myCommand.ExecuteReader();

            while (MR.Read())
            {

                //label2.Text = MR[0].ToString();
                //label3.Text = MR[1].ToString();


                if (MR[0].ToString().Equals(txtid.Text))
                {

                    label2.Text = "중복된 아이디가 있습니다. 다시 입력해주세요";
                }
                else if (!MR[0].ToString().Equals(txtid.Text))
                {
                    label2.Text = "사용가능한 아이디 입니다.";
                }

            }

            myConnection.Close();



        }
    }
}