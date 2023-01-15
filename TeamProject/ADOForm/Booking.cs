using Oracle.DataAccess.Client;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace ADOForm
{
    public partial class Booking : Form
    {
        DBClass dbc = new DBClass(); //*****DBClass 객체 생성
        string curItem;
        string curDate;
        string curRoom;
        string curTime1, curTime2, curTime3, curTime4, curTime5;
        string curRoom1, curRoom2, curRoom3, curRoom4, curRoom5;
        string curScrCode1, curScrCode2, curScrCode3, curScrCode4, curScrCode5;
        public String selectedRoom;
        public String movieTitle, selectedDate, selectedTime;
        public String userCode;
        string temp;
        public String scrcode;
        public Booking(string userCode)
        {


            InitializeComponent();
            this.CenterToScreen();
            this.userCode = userCode;

            dbc.DB_ObjCreate(); //*****
            dbc.DB_Open();//*****
        }

        private void Booking_Load(object sender, EventArgs e)
        {
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;

            try
            {
                dbc.DS2.Clear();
                dbc.DBAdapter2.Fill(dbc.DS2, "movie");
                DBGrid2.DataSource = dbc.DS2.Tables["movie"].DefaultView;




                string connectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
                OracleConnection myConnection = new OracleConnection(connectionString);

                string commandString = "select title from movie";

                OracleCommand myCommand = new OracleCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandText = commandString;

                myConnection.Open(); //

                OracleDataReader MR;
                MR = myCommand.ExecuteReader();


                while (MR.Read())
                {
                    object bugID = MR[0];
                    //object description = MR["FirstName"];
                    MovieList.Items.Add(bugID.ToString() + "   ");
                }



                MR.Close();
                myConnection.Close();







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

        private void SelectBtn_Click(object sender, EventArgs e)
        {

            selectedDate = label6.Text;

            if (radioButton1.Checked == true) {
                selectedTime = radioButton1.Text;
            }
            else if (radioButton2.Checked == true) {
                selectedTime = radioButton2.Text;
            }
            else if (radioButton3.Checked == true) {
                selectedTime = radioButton3.Text;
            }
            else if (radioButton4.Checked == true) {
                selectedTime = radioButton4.Text;
            }
            else {
                selectedTime= radioButton5.Text;
            }



            SelectSeat frm1 = new SelectSeat(selectedRoom, movieTitle, selectedDate, selectedTime, userCode, scrcode);
            this.Visible = false;
            frm1.Owner = this;
            frm1.ShowDialog();
            frm1.Dispose();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

            try
            {
                curDate = monthCalendar1.SelectionRange.Start.ToShortDateString();
                label6.Text = curDate;















                string connectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
                OracleConnection myConnection = new OracleConnection(connectionString);




                string commandString = "SELECT m.title, s.scrtime, s.roomcode, s.scrcode FROM screening s, movie m WHERE s.moviecode = m.movieCode AND m.title = :curItem AND s.scrdate = :curDate";

                OracleCommand myCommand = new OracleCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandText = commandString;
                myCommand.Parameters.Add(new OracleParameter("curItem",
                    OracleDbType.Varchar2,
                    curItem,
                    ParameterDirection.Input
                    )
                    );
                myCommand.Parameters.Add(new OracleParameter("curDate",
                    OracleDbType.Varchar2,
                    curDate,
                    ParameterDirection.Input
                    )
                    );
                myCommand.BindByName = true;



                myConnection.Open(); //

                OracleDataReader MR;
                MR = myCommand.ExecuteReader();




                int i = 0;
                while (MR.Read())
                {
                    object bugID = MR[0];
                    //object description = MR["FirstName"];


                    if (MR[0].ToString().Trim().Equals(curItem.Trim()) && MR[1].ToString().Substring(0, 10).Equals(curDate))
                    {
                        if (i == 0)
                        {
                            curRoom1 = MR[2].ToString().Trim();
                            curScrCode1= MR[3].ToString().Trim();


                            temp = MR[1].ToString().Substring(10);

                            radioButton1.Text = temp.Substring(0,6);

                            radioButton1.Visible = true;
                            radioButton2.Visible = false;
                            radioButton3.Visible = false;
                            radioButton4.Visible = false;
                            radioButton5.Visible = false;
                        }
                        else if (i == 1)
                        {
                            curRoom2 = MR[2].ToString().Trim();
                            curScrCode2 = MR[3].ToString().Trim();



                            temp = MR[1].ToString().Substring(10);

                            radioButton2.Text = temp.Substring(0, 6);
                            radioButton1.Visible = true;
                            radioButton2.Visible = true; radioButton3.Visible = false;
                            radioButton4.Visible = false;
                            radioButton5.Visible = false;
                        }
                        else if (i == 2)
                        {
                            curRoom3 = MR[2].ToString().Trim();
                            curScrCode3 = MR[3].ToString().Trim();



                            temp = MR[1].ToString().Substring(10);

                            radioButton3.Text = temp.Substring(0, 6);
                            radioButton1.Visible = true;
                            radioButton2.Visible = true;
                            radioButton3.Visible = true;
                            radioButton4.Visible = false;
                            radioButton5.Visible = false;


                        }
                        else if (i == 3)
                        {
                            curRoom4 = MR[2].ToString().Trim();
                            curScrCode4 = MR[3].ToString().Trim();



                            temp = MR[1].ToString().Substring(10);

                            radioButton4.Text = temp.Substring(0, 6);
                            radioButton1.Visible = true;
                            radioButton2.Visible = true;
                            radioButton3.Visible = true;
                            radioButton4.Visible = true;
                            radioButton5.Visible = false;

                        }
                        else if (i == 4)
                        {
                            curRoom5 = MR[2].ToString().Trim();
                            curScrCode5 = MR[3].ToString().Trim();


                            temp = MR[1].ToString().Substring(10);

                            radioButton5.Text = temp.Substring(0, 6);
                            radioButton1.Visible = true;
                            radioButton2.Visible = true;
                            radioButton3.Visible = true;
                            radioButton4.Visible = true;
                            radioButton5.Visible = true;

                            temp = MR[1].ToString().Substring(10);

                            radioButton5.Text = temp.Substring(0, 6);
                        }


                    }
                    i++;
                }



                MR.Close();
                myConnection.Close();

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

        private void MovieList_SelectedIndexChanged(object sender, EventArgs e)
        {
            curItem = MovieList.SelectedItem.ToString().Trim();

            label5.Text = curItem;



            movieTitle = curItem;







            try
            {
                curDate = monthCalendar1.SelectionRange.Start.ToShortDateString();
                label6.Text = curDate;















                string connectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
                OracleConnection myConnection = new OracleConnection(connectionString);




                string commandString = "SELECT m.title, s.scrtime, s.roomcode, s.scrcode FROM screening s, movie m WHERE s.moviecode = m.movieCode AND m.title = :curItem AND s.scrdate = :curDate";

                OracleCommand myCommand = new OracleCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandText = commandString;
                myCommand.Parameters.Add(new OracleParameter("curItem",
                    OracleDbType.Varchar2,
                    curItem,
                    ParameterDirection.Input
                    )
                    );
                myCommand.Parameters.Add(new OracleParameter("curDate",
                    OracleDbType.Varchar2,
                    curDate,
                    ParameterDirection.Input
                    )
                    );
                myCommand.BindByName = true;



                myConnection.Open(); //

                OracleDataReader MR;
                MR = myCommand.ExecuteReader();




                int i = 0;
                while (MR.Read())
                {
                    object bugID = MR[0];
                    //object description = MR["FirstName"];


                    if (MR[0].ToString().Trim().Equals(curItem.Trim()) && MR[1].ToString().Substring(0, 10).Equals(curDate))
                    {
                        if (i == 0)
                        {
                            curRoom1 = MR[2].ToString().Trim();
                            curScrCode1 = MR[3].ToString().Trim();


                            temp = MR[1].ToString().Substring(10);

                            radioButton1.Text = temp.Substring(0, 6);

                            radioButton1.Visible = true;
                            radioButton2.Visible = false;
                            radioButton3.Visible = false;
                            radioButton4.Visible = false;
                            radioButton5.Visible = false;
                        }
                        else if (i == 1)
                        {
                            curRoom2 = MR[2].ToString().Trim();
                            curScrCode2 = MR[3].ToString().Trim();



                            temp = MR[1].ToString().Substring(10);

                            radioButton2.Text = temp.Substring(0, 6);
                            radioButton1.Visible = true;
                            radioButton2.Visible = true; radioButton3.Visible = false;
                            radioButton4.Visible = false;
                            radioButton5.Visible = false;
                        }
                        else if (i == 2)
                        {
                            curRoom3 = MR[2].ToString().Trim();
                            curScrCode3 = MR[3].ToString().Trim();



                            temp = MR[1].ToString().Substring(10);

                            radioButton3.Text = temp.Substring(0, 6);
                            radioButton1.Visible = true;
                            radioButton2.Visible = true;
                            radioButton3.Visible = true;
                            radioButton4.Visible = false;
                            radioButton5.Visible = false;


                        }
                        else if (i == 3)
                        {
                            curRoom4 = MR[2].ToString().Trim();
                            curScrCode4 = MR[3].ToString().Trim();



                            temp = MR[1].ToString().Substring(10);

                            radioButton4.Text = temp.Substring(0, 6);
                            radioButton1.Visible = true;
                            radioButton2.Visible = true;
                            radioButton3.Visible = true;
                            radioButton4.Visible = true;
                            radioButton5.Visible = false;

                        }
                        else if (i == 4)
                        {
                            curRoom5 = MR[2].ToString().Trim();
                            curScrCode5 = MR[3].ToString().Trim();


                            temp = MR[1].ToString().Substring(10);

                            radioButton5.Text = temp.Substring(0, 6);
                            radioButton1.Visible = true;
                            radioButton2.Visible = true;
                            radioButton3.Visible = true;
                            radioButton4.Visible = true;
                            radioButton5.Visible = true;

                            temp = MR[1].ToString().Substring(10);

                            radioButton5.Text = temp.Substring(0, 6);
                        }


                    }
                    i++;
                }



                MR.Close();
                myConnection.Close();

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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {


                try
                {




                    string connectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
                    OracleConnection myConnection = new OracleConnection(connectionString);

                    string commandString = "SELECT roomname FROM room where roomcode = :curRoom";


                    OracleCommand myCommand = new OracleCommand();
                    myCommand.Connection = myConnection;
                    myCommand.CommandText = commandString;


                    myCommand.Parameters.Add(new OracleParameter("curRoom",
                        OracleDbType.Int64,
                        curRoom1,
                        ParameterDirection.Input
                    )
                        );

                    myCommand.BindByName = true;






                    myConnection.Open(); //

                    OracleDataReader MR;
                    MR = myCommand.ExecuteReader();


                    while (MR.Read())
                    {
                        label4.Text = MR[0].ToString().Trim() + "관";
                    }

                    MR.Close();
                    myConnection.Close();

                    selectedRoom = curRoom1;

                    scrcode = curScrCode1;







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
            }
            

            }

            private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {


                try
                {




                    string connectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
                    OracleConnection myConnection = new OracleConnection(connectionString);

                    string commandString = "SELECT roomname FROM room where roomcode = :curRoom";


                    OracleCommand myCommand = new OracleCommand();
                    myCommand.Connection = myConnection;
                    myCommand.CommandText = commandString;


                    myCommand.Parameters.Add(new OracleParameter("curRoom",
                        OracleDbType.Int64,
                        curRoom2,
                        ParameterDirection.Input
                    )
                        );

                    myCommand.BindByName = true;






                    myConnection.Open(); //

                    OracleDataReader MR;
                    MR = myCommand.ExecuteReader();


                    while (MR.Read())
                    {
                        label4.Text = MR[0].ToString().Trim() + "관";
                    }

                    MR.Close();
                    myConnection.Close();
                    selectedRoom = curRoom2;





                    scrcode = curScrCode2;

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
            else { 
            }
{

}

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton3.Checked == true)
            {


                try
                {




                    string connectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
                    OracleConnection myConnection = new OracleConnection(connectionString);

                    string commandString = "SELECT roomname FROM room where roomcode = :curRoom";


                    OracleCommand myCommand = new OracleCommand();
                    myCommand.Connection = myConnection;
                    myCommand.CommandText = commandString;


                    myCommand.Parameters.Add(new OracleParameter("curRoom",
                        OracleDbType.Int64,
                        curRoom3,
                        ParameterDirection.Input
                    )
                        );

                    myCommand.BindByName = true;






                    myConnection.Open(); //

                    OracleDataReader MR;
                    MR = myCommand.ExecuteReader();


                    while (MR.Read())
                    {
                        label4.Text = MR[0].ToString().Trim() + "관";
                    }

                    MR.Close();
                    myConnection.Close();
                    selectedRoom = curRoom3;


                    scrcode = curScrCode3;


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
            }
            {

            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton4.Checked == true)
            {


                try
                {




                    string connectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
                    OracleConnection myConnection = new OracleConnection(connectionString);

                    string commandString = "SELECT roomname FROM room where roomcode = :curRoom";


                    OracleCommand myCommand = new OracleCommand();
                    myCommand.Connection = myConnection;
                    myCommand.CommandText = commandString;


                    myCommand.Parameters.Add(new OracleParameter("curRoom",
                        OracleDbType.Int64,
                        curRoom4,
                        ParameterDirection.Input
                    )
                        );

                    myCommand.BindByName = true;






                    myConnection.Open(); //

                    OracleDataReader MR;
                    MR = myCommand.ExecuteReader();


                    while (MR.Read())
                    {
                        label4.Text = MR[0].ToString().Trim() + "관";
                    }

                    MR.Close();
                    myConnection.Close();
                    selectedRoom = curRoom4;


                    scrcode = curScrCode4;


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
            }
            {

            }

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton5.Checked == true)
            {


                try
                {




                    string connectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
                    OracleConnection myConnection = new OracleConnection(connectionString);

                    string commandString = "SELECT roomname FROM room where roomcode = :curRoom";


                    OracleCommand myCommand = new OracleCommand();
                    myCommand.Connection = myConnection;
                    myCommand.CommandText = commandString;


                    myCommand.Parameters.Add(new OracleParameter("curRoom",
                        OracleDbType.Int64,
                        curRoom5,
                        ParameterDirection.Input
                    )
                        );

                    myCommand.BindByName = true;






                    myConnection.Open(); //

                    OracleDataReader MR;
                    MR = myCommand.ExecuteReader();


                    while (MR.Read())
                    {
                        label4.Text = MR[0].ToString().Trim() + "관";
                    }

                    MR.Close();
                    myConnection.Close();
                    selectedRoom = curRoom5;


                    scrcode = curScrCode5;


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
            }
            {

            }
        }
    }
}