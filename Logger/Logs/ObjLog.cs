using System;
using System.Data;

namespace Logger.Logs
{
    abstract class ObjLog
    {
        internal int myType;
        internal abstract void WriteLog(string Msg);
        internal abstract void OpenForm();
        internal abstract DataTable getMyTable();
        internal abstract void Limpar();
        internal abstract void reCreate();
    }
}
