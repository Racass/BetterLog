using Logger.Front;
using Logger.Logs;
using Logger.Logs.CSV;
using System;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Logger
{
    class Controller
    {
        internal ObjLog log;
        private int p_type;
        private bool myColumns = false;
        private List<string> cols;
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
        /// <summary>
        /// Generates the columns names for CSV file
        /// </summary>
        /// <param name="Collumns">List of names</param>
        public void SetColumns(List<string> Collumns)
        {
            if (Collumns.Count > 0)
            {
                cols = Collumns;
                myColumns = true;
            }
            else
                throw new Exception("Colunas inválidas");
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
                    if (myColumns)
                    {
                        myLog = new CsvCtrl(cols);
                        return myLog;
                    }
                    else
                        throw new Exception("Colunas não foram setadas. Favor chamar Controller.SetColumns");
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
            if (log.myType == 1)
                log.WriteLog(Msg);
            else
                throw new Exception("Use o método correto para o seu tipo de log. Tipo atual: " + log.myType.ToString());
        }
        /// <summary>
        /// Write to CSVLog
        /// </summary>
        /// <param name="message">the Object CSVMessage containing the column and the message</param>
        public void WriteLog(CSVMessage message)
        {

        }
        /// <summary>
        /// Gets a object CsvCtrl for WriteLog
        /// </summary>
        /// <returns></returns>
        public CSVMessage Get_CSVMessage()
        {
            return new CSVMessage(this);
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