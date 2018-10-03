using System;
using Logger.Oobj;

namespace Logger
{
    class Log
    {
        internal string directory;
        internal string fileName;
        private int type;
        /// <summary>
        /// Generate the logger
        /// </summary>
        /// <param name="dir">directory of file. Standard is CurrPath "\log\"</param>
        /// <param name="tipo">tipo do log. 1- TXT 2 - CSV 3 - WindowsLog 4 - </param>
        public Log(int tipo, string dir = "")
        {
            type = tipo;
        }

        private void write()
        {
            
        }
    }
}