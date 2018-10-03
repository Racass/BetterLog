using System;
using System.IO;

namespace Logger.Oobj.Types
{
    internal class txt
    {
        internal string directory = Directory.GetCurrentDirectory();
        internal string fileName = DateTime.Now.ToShortDateString().Replace("/", ".").Replace("\\", ".");
    }
}