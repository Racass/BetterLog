using System;
using System.Threading;
using Logger.Logs;
using System.Windows.Forms;
using Logger.Front;

namespace Logger
{
    class Controller
    {
        internal ObjLog log;
        private int p_type;
        /// <summary>
        /// Set the instance of the log
        /// </summary>
        /// <param name="type">See LogType at docs</param>
        /// 1- TXT ##### 2 - CSV #### 3 - SQL #### 4 - Windows #### 5 - SAPForm #### 6 - WinForm
        public Controller(int type)
        {
            p_type = type;
            log = setType(type);
            if (log == null)
                throw new Exception("Objeto não implementando. Favor obedecer regra 1~5. Error code: -1");
        }
        private ObjLog setType(int type)
        {
            ObjLog myLog;
            switch (type)
            {
                case 1:
                    myLog = new TxtCtrl();
                    return myLog;
                case 2:
                    myLog = null;
                    throw new Exception("Not implemented");
                    //return myLog;
                case 3:
                    myLog = null;
                    throw new Exception("Not implemented");
                    //return myLog;
                case 4:
                    myLog = null;
                    throw new Exception("Not implemented");
                    //return myLog;
                case 5:
                    myLog = null;
                    throw new Exception("Not implemented");
                    //return myLog;
                case 6:
                    myLog = null;
                    throw new Exception("Not implemented");
                    //return myLog;
            }
            return null;
        }
        /// <summary>
        /// Write a message in the log
        /// </summary>
        /// <param name="Msg">The message to be written</param>
        public void WriteLog(string Msg)
        {
            log.WriteLog(Msg);
        }
        /// <summary>
        /// Open a windows form with a grid containing the application log
        /// </summary>
        public void OpenMyForm()
        {
            log.OpenForm();
        }
        [STAThread]
        private void ClearMem()
        {
            log = null;
            GC.Collect();
            log = setType(p_type);
        }

    }
}