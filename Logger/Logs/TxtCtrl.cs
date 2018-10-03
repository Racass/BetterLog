using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using Logger.Utils;
using Logger.MyObject;
using System.Threading;
using System.Windows.Forms;
using Logger.Front;

namespace Logger.Logs
{
    class TxtCtrl : ObjLog
    {
        MyDataTable_TXT txt_Table;
        string path;
        internal TxtCtrl()
        {
            path = Directory.GetCurrentDirectory() + "\\log\\txt\\" + DateTime.Now.ToShortDateString().Replace("/", ".").Replace("\\", ".") + ".txt";
            InternUtils.verifyDirectory();
            txt_Table = new MyDataTable_TXT(path);
            txt_Table.ctrler = new MyDataTable_Ctrl(path, this);
        }
        internal override void WriteLog(string Msg)
        {
            txt_Table.WriteMessage(Msg);
        }
        internal override DataTable getMyTable()
        {
            return txt_Table.myTable;
        }
        internal override void OpenForm()
        {
            Thread form = new Thread(MyForm);
            form.Start();
        }
        internal override void Limpar()
        {
            txt_Table.Limpar();
            txt_Table.PushFromLists();
        }
        internal override void reCreate()
        {
            txt_Table.CreateTable();
        }
        #region Threads
        [STAThread]
        private void MyForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ShowLogTable myForm = new ShowLogTable();
            myForm.SyncDataTxt(this.getMyTable());
            Application.Run(myForm);
        }
        #endregion
    }
}