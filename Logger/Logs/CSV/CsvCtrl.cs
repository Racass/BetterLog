using System;
using System.Collections.Generic;
using Logger.MyObject;

namespace Logger.Logs.CSV
{
    class CsvCtrl : ObjLog
    {
        MyDataTable_CSV myCSV;
        internal bool isReady = false;
        internal CsvCtrl(List<string> columns)
        {
            this.myType = 2;
        }
        internal override void WriteLog(string Msg)
        {

        }
        internal override void OpenForm()
        {

        }
        internal override System.Data.DataTable getMyTable()
        {
            System.Data.DataTable myTable = new System.Data.DataTable();
            return myTable;
        }
        internal override void Limpar()
        {

        }
        internal override void reCreate()
        {

        }
    }
}
