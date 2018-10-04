using System;
using System.Data;
using System.Collections.Generic;
using Logger.MyObject.Others;


namespace Logger.MyObject
{
    class MyDataTable_CSV
    {
         #region constructor
        internal DataTable myTable;
        internal DataColumn col_ID;
        internal DataColumn col_Time;
        internal DataColumn col_Msg;

        List<ListFather> myMsgList;
        internal MyDataTable_Ctrl ctrler;

        string path;
        internal MyDataTable_CSV(string pth)
        {
            path = pth;
            CreateTable();   
            GenList();
        }
        private void GenList()
        {
            myMsgList = new List<ListFather>();
        }
        #region criaTabela
        internal void CreateTable()
        {
            myTable = new DataTable();
            SetColumns();
            AddColumnsToTable();
        }
        private void SetColumns()
        {
            col_ID = new DataColumn();
            col_Time = new DataColumn();
            col_Msg = new DataColumn();
            gen_col_id();
            gen_col_time();
            gen_col_msg();
        }
        private void gen_col_id()
        {
            col_ID.AutoIncrement = true;
            col_ID.AutoIncrementSeed = 0;
            col_ID.AutoIncrementStep = 1;
            col_ID.Caption = "ID";
            col_ID.ColumnName = "ID";
            col_ID.DataType = typeof(int);
            col_ID.Unique = true;
        }
        private void gen_col_time()
        {
            col_Time.AllowDBNull = false;
            col_Time.Caption = "Time";
            col_Time.ColumnName = "Time";
            col_Time.DataType = typeof(string);
        }
        private void gen_col_msg()
        {
            col_Msg.AllowDBNull = false;
            col_Msg.Caption = "Msg";
            col_Msg.ColumnName = "Msg";
            col_Msg.DataType = typeof(string);
        }
        private void AddColumnsToTable()
        {
            myTable.Columns.Add(col_ID);
            myTable.Columns.Add(col_Time);
            myTable.Columns.Add(col_Msg);
        }
        #endregion
        #endregion
        internal void WriteMessage(string Msg)
        {
            if (ctrler.Writting)
            {
                myMsgList.Add(new TimeMsg() { 
                    msg = Msg,
                    time = DateTime.Now.ToShortTimeString()
                });
            }
            else
            {
                insertTable(Msg);
            }
        }
        private void insertTable(string msg, string time = "now")
        {
            DataRow myRow;
            if (time == "now")
                time = DateTime.Now.ToShortTimeString();

            myRow = myTable.NewRow();
            myRow[1] = time;
            myRow[2] = msg;
            myTable.Rows.Add(myRow);
            myRow = null;
        }
        internal void PushFromLists()
        {
            int cnt = myMsgList.Count;
            for (int i = 0; i < cnt; i++)
                insertTable(myMsgList[i].msg, myMsgList[i].time);
            myMsgList.RemoveRange(0, cnt);
            myMsgList = null;
            System.GC.Collect();
            GenList();
        }
        #region Limpeza
        internal void Limpar()
        {
            LimpaTabela();
            LimpaColunas();
        }
        private void LimpaTabela()
        {
            myTable.Clear();
            myTable.Dispose();
            myTable = null;
        }
        private void LimpaColunas()
        {
            col_ID.Dispose();
            col_Time.Dispose();
            col_Msg.Dispose();
            col_ID = null;
            col_Time = null;
            col_Msg = null;
        }
        #endregion
    }
}
