using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.IO;
using Logger.MyObject.Others;

namespace Logger.MyObject
{
    class MyDataTable_Ctrl
    {
        #region Constructor
        Logger.Logs.ObjLog myObj;
        internal DataTable myTable;
        private Thread myWriter;
        internal bool Writting = false;
        StreamWriter oEsc;
        string path;
        internal MyDataTable_Ctrl(string pth, Logger.Logs.ObjLog father)
        {
            myObj = father;
            path = pth;
            myTable = father.getMyTable();
            ThreadStart();
            WriteThread();
        }
        #endregion
        private void WriteThread()
        {
            myWriter = new Thread(Writter);
            myWriter.SetApartmentState(ApartmentState.STA);
            myWriter.Start();
        }
        private Thread ThreadStart()
        {
            Thread init = new Thread(TXT_Start);
            init.SetApartmentState(ApartmentState.STA);
            init.Start();
            return init;
        }
        #region Threads
        [STAThread]
        private void Writter()
        {
            int lastID = 0;
            while (true)
            {
                Thread.Sleep(5 * 1000);
                Writting = true;
                for (int i = lastID; i < myTable.Rows.Count; i++)
                {
                    oEsc.WriteLine(myTable.Rows[i][1] + ": " + myTable.Rows[i][2]);
                    lastID = myTable.Rows.Count;
                }
                LimpaTudo();
                Writting = false;
            }
        }
        [STAThread]
        private void TXT_Start()
        {
            oEsc = new StreamWriter(path, true);
            oEsc.AutoFlush = true;
            oEsc.WriteLine();
            oEsc.WriteLine("Log services intialized with success..");
            oEsc.WriteLine();
        }
        #endregion
        #region limpeza
        private void LimpaTudo()
        {
            myObj.Limpar();
            LimpaStream();
            GC.Collect();
            RecreateSystems();
        }
        private void LimpaStream()
        {
            oEsc.Close();
            oEsc.Dispose();
            oEsc = null;
        }
        private void RecreateSystems()
        {
            myObj.reCreate();
            Thread td = ThreadStart();
            while (td.IsAlive)
            {
                //Wait
            }
        }
        #endregion
    }
}