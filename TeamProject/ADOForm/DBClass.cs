using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;//ADO.Net 개체 참조
using System.Data; //DataSet 개체 참조
using System.Windows.Forms; //MessageBox 개체 참조


namespace ADOForm
{
    public class DBClass //DBClass 정의 시작
    {
        private int selectedRowIndex;//수정하거나 삭제하기 위해 선택된 행의 인덱스를 저장한다.
        private int selectedKeyValue; // 수정, 삭제할 때 필요한 레코드의 키값을 보관할 필드
        OracleDataAdapter dBAdapter; // Data Provider인 DBAdapter 입니다.

        OracleDataAdapter dBAdapter2; // Data Provider인 DBAdapter 입니다.
        DataSet dS;// DataSet 객체입니다.
        DataSet dS2;// DataSet 객체입니다.
        OracleCommandBuilder myCommandBuilder; // 추가, 수정, 삭제시에 필요한 명령문을 자동으로 작성해주는 객체
        DataTable userTable;// DataTable 객체입니다.
        DataTable movieTable;
        public int SelectedRowIndex { get { return selectedRowIndex; } set { selectedRowIndex = value; } }
        public int SelectedKeyValue { get { return selectedKeyValue; } set { selectedKeyValue = value; } }
        public OracleDataAdapter DBAdapter { get { return dBAdapter; } set { dBAdapter = value; } }
        public OracleDataAdapter DBAdapter2 { get { return dBAdapter2; } set { dBAdapter2 = value; } }
        public DataSet DS { get { return dS; } set { dS = value; } }

        public DataSet DS2 { get { return dS2; } set { dS2 = value; } }
        public OracleCommandBuilder MyCommandBuilder
        {
            get { return myCommandBuilder; }
            set { myCommandBuilder = value; }
        }

        public OracleCommandBuilder MyCommandBuilder2
        {
            get { return myCommandBuilder; }
            set { myCommandBuilder = value; }
        }
        public DataTable UserTable { get { return userTable; } set { userTable = value; } }

        public DataTable MovieTable { get { return movieTable; } set { movieTable = value; } }
        public void DB_Open()
        {
            try
            {
                string connectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
                string commandString = "select * from user_t";
                DBAdapter = new OracleDataAdapter(commandString, connectionString);
                MyCommandBuilder = new OracleCommandBuilder(DBAdapter);
                DS = new DataSet();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }

            try
            {
                string connectionString2 = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
                string commandString2 = "select * from movie";
                DBAdapter2 = new OracleDataAdapter(commandString2, connectionString2);
                MyCommandBuilder2 = new OracleCommandBuilder(DBAdapter2);
                DS2 = new DataSet();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }
        public void DB_ObjCreate()
        {
            UserTable = new DataTable();
        }
    } //DBClass 정의 
}
