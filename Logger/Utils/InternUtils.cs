using System;
using System.IO;

namespace Logger.Utils
{
    internal static class InternUtils
    {
        /// <summary>
        /// Verify if a directory exists, if not create it
        /// </summary>
        /// <param name="dir">can be a custom directory, or by std current exe direc + "\log"</param>
        internal static void verifyDirectory(string dir = "currDir")
        {
            if (dir == "currDir")
                dir = Directory.GetCurrentDirectory() + "\\log";

            if (!Directory.Exists(dir)) 
                Directory.CreateDirectory(dir);
            verifySubFolders(dir);
        }
        private static void verifySubFolders(string dir)
        {
            if(!Directory.Exists(dir + "\\txt"))
                Directory.CreateDirectory(dir + "\\txt");

            if (!Directory.Exists(dir + "\\csv"))
                Directory.CreateDirectory(dir + "\\csv");
        }
    }
}