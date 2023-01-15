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
    public partial class SelectSeat : Form
    {
        public string selectedRoom;
        public string movieTitle;
        public string selectedDate;
        public string selectedTime;
        int count;
        public int adultCount;
        public int teenCount;
        int sumCount;
        int roNum, colNum;
        public string selectedRow, selectedCol;
        public string userCode, scrcode;
        public SelectSeat(string selectedRoom, string movieTitle, string selectedDate, string selectedTime, string userCode, string scrcode)
        {
            InitializeComponent();
            this.CenterToScreen();

            this.movieTitle = movieTitle;
            this.selectedDate = selectedDate;
            this.selectedTime = selectedTime;
            this.selectedRoom = selectedRoom;
            this.userCode = userCode;
            this.scrcode = scrcode;
        }

        private void SelectSeat_Load(object sender, EventArgs e)
        {

            selectedRow = "";
            selectedCol = "";




            try
            {




                string connectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
                OracleConnection myConnection = new OracleConnection(connectionString);

                string commandString = "SELECT roomname, ronum, columnnum  FROM room where roomcode = :curRoom";


                OracleCommand myCommand = new OracleCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandText = commandString;


                myCommand.Parameters.Add(new OracleParameter("curRoom",
                    OracleDbType.Int64,
                    selectedRoom,
                    ParameterDirection.Input
                )
                    );

                myCommand.BindByName = true;






                myConnection.Open(); //

                OracleDataReader MR;
                MR = myCommand.ExecuteReader();


                while (MR.Read())
                {
                    roomName.Text = MR[0].ToString().Trim() + "관";





                    roNum = Convert.ToInt32(MR[1]);
                    colNum= Convert.ToInt32(MR[2]);





                    if (roNum == 5)
                    {
                        checkBox15.Visible = false;
                        checkBox30.Visible = false;
                        checkBox45.Visible = false;
                        checkBox60.Visible = false;
                        checkBox75.Visible = false;
                        checkBox90.Visible = false;
                    }
                    else if (roNum == 4)
                    {
                        checkBox15.Visible = false;
                        checkBox30.Visible = false;
                        checkBox45.Visible = false;
                        checkBox60.Visible = false;
                        checkBox75.Visible = false;
                        checkBox90.Visible = false;

                        checkBox14.Visible = false;
                        checkBox29.Visible = false;
                        checkBox44.Visible = false;
                        checkBox59.Visible = false;
                        checkBox74.Visible = false;
                        checkBox89.Visible = false;
                    }


                    if (colNum== 14)
                    {
                        label6.Visible = false;
                        checkBox76.Visible = false;
                        checkBox77.Visible = false;
                        checkBox78.Visible = false;
                        checkBox79.Visible = false;
                        checkBox80.Visible = false;
                        checkBox81.Visible = false;
                        checkBox82.Visible = false;
                        checkBox83.Visible = false;
                        checkBox84.Visible = false;
                        checkBox85.Visible = false;
                        checkBox86.Visible = false;
                        checkBox87.Visible = false;
                        checkBox88.Visible = false;
                        checkBox89.Visible = false;
                        checkBox90.Visible = false;
                    }



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

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            adultCount = ((int)numericUpDown1.Value);
            sumCount = adultCount + teenCount;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            teenCount = ((int)numericUpDown2.Value);
            sumCount = adultCount + teenCount;


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {


            if (checkBox1.Checked == true)
            {
                count += 1;
                selectedRow += "A, ";                     //*****************************
                selectedCol += "1, ";                     //*****************************
            }
            else
            {
                count -= 1;

                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);                     //*****************************
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);                     //*****************************
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                count += 1;
                selectedRow += "A, ";
                selectedCol += "2, ";

            }
            else
            {
                count -= 1;

                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                count += 1;
                selectedRow += "A, ";
                selectedCol += "3, ";

            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                count += 1;
                selectedRow += "A, ";
                selectedCol += "4, ";

            }

            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                count += 1;
                selectedRow += "A, ";
                selectedCol += "5, ";
            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                count += 1;
                selectedRow += "A, ";
                selectedCol += "6, ";



            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                count += 1;
                selectedRow += "A, ";
                selectedCol += "7, ";



            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                count += 1;
                selectedRow += "A, ";
                selectedCol += "8, ";



            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }

        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                count += 1;
                selectedRow += "A, ";
                selectedCol += "9, ";



            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }

        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == true)
            {
                count += 1;
                selectedRow += "A, ";
                selectedCol += "10, ";

            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }

        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked == true)
            {
                count += 1;
                selectedRow += "A, ";
                selectedCol += "11, ";
            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }

        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked == true)
            {
                count += 1;
                selectedRow += "A, ";
                selectedCol += "12, ";

            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }

        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked == true)
            {
                count += 1;
                selectedRow += "A, ";
                selectedCol += "13, ";

            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }

        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked == true)
            {
                count += 1;
                selectedRow += "A, ";
                selectedCol += "14, ";
            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }

        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked == true)
            {
                count += 1;
                selectedRow += "A, ";
                selectedCol += "15, ";

            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }

        }


        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox16.Checked == true)
            {
                count += 1;
                selectedRow += "B, ";                     //*****************************
                selectedCol += "1, ";

            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked == true)
            {
                count += 1;
                selectedRow += "B, ";
                selectedCol += "2, ";

            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked == true)
            {
                count += 1;
                selectedRow += "B, ";                     //*****************************
                selectedCol += "3, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked == true)
            {
                count += 1;
                selectedRow += "B, ";
                selectedCol += "4, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox20.Checked == true)
            {
                count += 1;
                selectedRow += "B, ";
                selectedCol += "5, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox21.Checked == true)
            {
                count += 1;
                selectedRow += "B, ";
                selectedCol += "6, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox22.Checked == true)
            {
                count += 1;
                selectedRow += "B, ";
                selectedCol += "7, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox23.Checked == true)
            {
                count += 1;
                selectedRow += "B, ";
                selectedCol += "8, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox24.Checked == true)
            {
                count += 1;
                selectedRow += "B, ";
                selectedCol += "9, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox25.Checked == true)
            {
                count += 1;
                selectedRow += "B, ";
                selectedCol += "10, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox26.Checked == true)
            {
                count += 1;
                selectedRow += "B, ";
                selectedCol += "11, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox27.Checked == true)
            {
                count += 1;
                selectedRow += "B, ";
                selectedCol += "12, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox28.Checked == true)
            {
                count += 1;
                selectedRow += "B, ";
                selectedCol += "13, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox29.Checked == true)
            {
                count += 1;
                selectedRow += "B, ";
                selectedCol += "14, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox30.Checked == true)
            {
                count += 1;
                selectedRow += "B, ";
                selectedCol += "15, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox31_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox31.Checked == true)
            {
                count += 1;
                selectedRow += "C, ";
                selectedCol += "1, ";

            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox32.Checked == true)
            {
                count += 1;
                selectedRow += "C, ";
                selectedCol += "2, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox33_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox33.Checked == true)
            {
                count += 1;
                selectedRow += "C, ";
                selectedCol += "3, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox34_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox34.Checked == true)
            {
                count += 1;
                selectedRow += "C, ";
                selectedCol += "4, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox35_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox35.Checked == true)
            {
                count += 1;
                selectedRow += "C, ";
                selectedCol += "5, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox36_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox36.Checked == true)
            {
                count += 1;
                selectedRow += "C, ";
                selectedCol += "6, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox37_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox37.Checked == true)
            {
                count += 1;
                selectedRow += "C, ";
                selectedCol += "7, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox38_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox38.Checked == true)
            {
                count += 1;
                selectedRow += "C, ";
                selectedCol += "8, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox39_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox39.Checked == true)
            {
                count += 1;
                selectedRow += "C, ";
                selectedCol += "9, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox40_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox40.Checked == true)
            {
                count += 1;
                selectedRow += "C, ";
                selectedCol += "10, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox41_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox41.Checked == true)
            {
                count += 1;
                selectedRow += "C, ";
                selectedCol += "11, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox42_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox42.Checked == true)
            {
                count += 1;
                selectedRow += "C, ";
                selectedCol += "12, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox43_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox43.Checked == true)
            {
                count += 1;
                selectedRow += "C, ";
                selectedCol += "13, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox44_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox44.Checked == true)
            {
                count += 1;
                selectedRow += "C, ";
                selectedCol += "14, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox45_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox45.Checked == true)
            {
                count += 1;
                selectedRow += "C, ";
                selectedCol += "15, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox46_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox46.Checked == true)
            {
                count += 1;
                selectedRow += "D, ";
                selectedCol += "1, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox47_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox47.Checked == true)
            {
                count += 1;
                selectedRow += "D, ";
                selectedCol += "2, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox48_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox48.Checked == true)
            {
                count += 1;
                selectedRow += "D, ";
                selectedCol += "3, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox49_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox49.Checked == true)
            {
                count += 1;
                selectedRow += "D, ";
                selectedCol += "4, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox50_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox50.Checked == true)
            {
                count += 1;
                selectedRow += "D, ";
                selectedCol += "5, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox51_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox51.Checked == true)
            {
                count += 1;
                selectedRow += "D, ";
                selectedCol += "6, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox52_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox52.Checked == true)
            {
                count += 1;
                selectedRow += "D, ";
                selectedCol += "7, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox53_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox53.Checked == true)
            {
                count += 1;
                selectedRow += "D, ";
                selectedCol += "8, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox54_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox54.Checked == true)
            {
                count += 1;
                selectedRow += "D, ";
                selectedCol += "9, ";

            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox55_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox55.Checked == true)
            {
                count += 1;
                selectedRow += "D, ";
                selectedCol += "10, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox56_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox56.Checked == true)
            {
                count += 1;
                selectedRow += "D, ";
                selectedCol += "11, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox57_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox57.Checked == true)
            {
                count += 1;
                selectedRow += "D, ";
                selectedCol += "12, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox58_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox58.Checked == true)
            {
                count += 1;
                selectedRow += "D, ";
                selectedCol += "13, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox59_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox59.Checked == true)
            {
                count += 1;
                selectedRow += "D, ";
                selectedCol += "14, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox60_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox60.Checked == true)
            {
                count += 1;
                selectedRow += "D, ";
                selectedCol += "15, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox61_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox61.Checked == true)
            {
                count += 1;
                selectedRow += "E, ";
                selectedCol += "1, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox62_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox62.Checked == true)
            {
                count += 1;
                selectedRow += "E, ";
                selectedCol += "2, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox63_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox63.Checked == true)
            {
                count += 1;
                selectedRow += "E, ";
                selectedCol += "3, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox64_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox64.Checked == true)
            {
                count += 1;
                selectedRow += "E, ";
                selectedCol += "4, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox65_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox65.Checked == true)
            {
                count += 1;
                selectedRow += "E, ";
                selectedCol += "5, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox66_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox66.Checked == true)
            {
                count += 1;
                selectedRow += "E, ";
                selectedCol += "6, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox67_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox67.Checked == true)
            {
                count += 1;
                selectedRow += "E, ";
                selectedCol += "7, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox68_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox68.Checked == true)
            {
                count += 1;
                selectedRow += "E, ";
                selectedCol += "8, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox69_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox69.Checked == true)
            {
                count += 1;
                selectedRow += "E, ";
                selectedCol += "9, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox70_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox70.Checked == true)
            {
                count += 1;
                selectedRow += "E, ";
                selectedCol += "10, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox71_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox71.Checked == true)
            {
                count += 1;
                selectedRow += "E, ";
                selectedCol += "11, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox72_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox72.Checked == true)
            {
                count += 1;
                selectedRow += "E, ";
                selectedCol += "12, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox73_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox73.Checked == true)
            {
                count += 1;
                selectedRow += "E, ";
                selectedCol += "13, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox74_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox74.Checked == true)
            {
                count += 1;
                selectedRow += "E, ";
                selectedCol += "14, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox75_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox75.Checked == true)
            {
                count += 1;
                selectedRow += "E, ";
                selectedCol += "15, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox76_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox76.Checked == true)
            {
                count += 1;
                selectedRow += "F, ";
                selectedCol += "1, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox77_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox77.Checked == true)
            {
                count += 1;
                selectedRow += "F, ";
                selectedCol += "2, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox78_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox78.Checked == true)
            {
                count += 1;
                selectedRow += "F, ";
                selectedCol += "3, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox79_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox79.Checked == true)
            {
                count += 1;
                selectedRow += "F, ";
                selectedCol += "4, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox80_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox80.Checked == true)
            {
                count += 1;
                selectedRow += "F, ";
                selectedCol += "5, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox81_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox81.Checked == true)
            {
                count += 1;
                selectedRow += "F, ";
                selectedCol += "6, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox82_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox82.Checked == true)
            {
                count += 1;
                selectedRow += "F, ";
                selectedCol += "7, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox83_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox83.Checked == true)
            {
                count += 1;
                selectedRow += "F, ";
                selectedCol += "8, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox84_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox84.Checked == true)
            {
                count += 1;
                selectedRow += "F, ";
                selectedCol += "9, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 3);
            }
        }

        private void checkBox85_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox85.Checked == true)
            {
                count += 1;
                selectedRow += "F, ";
                selectedCol += "10, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox86_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox86.Checked == true)
            {
                count += 1;
                selectedRow += "F, ";
                selectedCol += "11, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }

        private void checkBox87_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox87.Checked == true)
            {
                count += 1;
                selectedRow += "F, ";
                selectedCol += "12, ";
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);


            }
            else
            {
                count -= 1;
            }
        }

        private void checkBox88_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox88.Checked == true)
            {
                count += 1;
                selectedRow += "F, ";
                selectedCol += "13, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            label12.Text = selectedRow + "|||||||" + selectedCol;
        }

        private void checkBox89_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox89.Checked == true)
            {
                count += 1;
                selectedRow += "F, ";
                selectedCol += "14, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);

            }
        }

        private void checkBox90_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox90.Checked == true)
            {
                count += 1;
                selectedRow += "F, ";
                selectedCol += "15, ";


            }
            else
            {
                count -= 1;
                selectedRow = selectedRow.Substring(0, selectedRow.Length - 3);
                selectedCol = selectedCol.Substring(0, selectedCol.Length - 4);
            }
        }



        private void button113_Click(object sender, EventArgs e)
        {






            if (count > sumCount)
            {
                MessageBox.Show("선택된 좌석이 총 인원보다 많습니다. 확인 해주세요.");
            }
            else if (count < sumCount)
            {
                MessageBox.Show("선택된 좌석이 총 인원보다 적습니다. 확인 해주세요.");

            }
            else {
                this.selectedRoom = roomName.Text;


                Payment frm1 = new Payment(adultCount, teenCount, movieTitle, selectedDate, selectedTime, selectedRoom, selectedRow, selectedCol, userCode, scrcode);
                this.Visible = false;
                frm1.Owner = this;
                frm1.ShowDialog();
                frm1.Dispose();
            }
        }
    }
}
