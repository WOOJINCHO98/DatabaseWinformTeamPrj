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
    public partial class Form1 : Form
    {

        private void ClearTextBoxes()
        {
            txtid.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtMail.Clear();
        }


        DBClass dbc = new DBClass(); //*****DBClass 객체 생성


        public Form1()
        {
            InitializeComponent();
            dbc.DB_ObjCreate(); //*****
            dbc.DB_Open();//*****
        }


            private void DAOpenBtn_Click(object sender, EventArgs e)
        {
            try
            {
                dbc.DS.Clear();
                dbc.DBAdapter.Fill(dbc.DS, "user");
                DBGrid.DataSource = dbc.DS.Tables["user"].DefaultView;
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



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dbc.DS2.Clear();
                dbc.DBAdapter2.Fill(dbc.DS2, "movie");
                DBGrid2.DataSource = dbc.DS2.Tables["movie"].DefaultView;
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




        private void AppendBtn_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("텍스트 상자에 모든 데이터 입력하셨으면 추가합니다!");
               // DS.Clear();//*

              //  DBAdapter.Fill(DS, "Phone");//*

                dbc.UserTable = dbc.DS.Tables["user"];//*
                DataRow newRow = dbc.UserTable.NewRow();
                newRow["userCode"] =Convert.ToInt32(txtid.Text);
                newRow["UserId"] = txtName.Text;
                newRow["Password"] = txtPhone.Text;
                newRow["Email"] = txtMail.Text;


                dbc.UserTable.Rows.Add(newRow);
                dbc.DBAdapter.Update(dbc.DS, "user");
                dbc.DS.AcceptChanges();//*
                ClearTextBoxes();  //*
                DBGrid.DataSource = dbc.DS.Tables["user"].DefaultView;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
           // DataSet DS = new DataSet();//*
            //DBAdapter.Fill(DS, "Phone");

            DataTable UserTable = dbc.DS.Tables["user"];

            if (e.RowIndex < 0)
            {
                // DBGrid의 컬럼 헤더를 클릭하면 컬럼을 정렬하므로
                // 아무 메시지도 띄우지 않습니다.
                return;
            }
            else if (e.RowIndex > UserTable.Rows.Count - 1)
            {
                MessageBox.Show("해당하는 데이터가 존재하지 않습니다.");
                return;
            }

            DataRow currRow = UserTable.Rows[e.RowIndex];
            txtid.Text = currRow["id"].ToString();
            txtName.Text = currRow["PName"].ToString();
            txtPhone.Text = currRow["Phone"].ToString();
            txtMail.Text = currRow["EMail"].ToString();

            dbc.SelectedRowIndex = Convert.ToInt32(currRow["id"]);
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

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //DS.Clear();    
                //DBAdapter.Fill(DS, "Phone");


                dbc.UserTable = dbc.DS.Tables["user"];//*
                DataColumn[] PrimaryKey = new DataColumn[1];
                PrimaryKey[0] = dbc.UserTable.Columns["id"];
                dbc.UserTable.PrimaryKey = PrimaryKey;

                DataRow currRow = dbc.UserTable.Rows.Find(dbc.SelectedRowIndex);


                currRow.BeginEdit();
                currRow["id"] = txtid.Text;
                currRow["PName"] = txtName.Text;
                currRow["Phone"] = txtPhone.Text;
                currRow["EMail"] = txtMail.Text;
                currRow.EndEdit();

                DataSet UpdatedSet = dbc.DS.GetChanges(DataRowState.Modified);
                if (UpdatedSet.HasErrors)
                {
                    MessageBox.Show("변경된 데이터에 문제가 있습니다.");
                }
                else
                {
                    dbc.DBAdapter.Update(UpdatedSet, "user");
                    dbc.DS.AcceptChanges();
                }

                DBGrid.DataSource = dbc.DS.Tables["user"].DefaultView;

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

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // DS.Clear();
                // DBAdapter.Fill(DS, "Phone");


                dbc.UserTable = dbc.DS.Tables["user"];//*
                DataColumn[] PrimaryKey = new DataColumn[1];
                PrimaryKey[0] = dbc.UserTable.Columns["id"];
                dbc.UserTable.PrimaryKey = PrimaryKey;

                DataRow currRow = dbc.UserTable.Rows.Find(dbc.SelectedRowIndex);
                currRow.Delete();

                dbc.DBAdapter.Update(dbc.DS.GetChanges(DataRowState.Deleted), "user");
                DBGrid.DataSource = dbc.DS.Tables["user"].DefaultView;
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

      
        private void DBGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Owner = this;
            frm2.ShowDialog();
            frm2.Dispose();
        }
        public String TxtS
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value.ToString(); }
        }


    }
}
