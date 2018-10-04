using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Logs.CSV
{
    class CSVMessage
    {
        private Controller myFather;
        /// <summary>
        /// Constructs the CSVMessage
        /// </summary>
        /// <param name="father">the controller</param>
        internal CSVMessage(Controller father)
        {
            myFather = father;
        }
        internal string colName;
        internal string message;

        public void setMessage(string colName, string message)
        {
            this.colName = colName;
            this.message = message;
        }
    }
}
