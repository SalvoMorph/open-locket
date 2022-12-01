using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Sandbox.Factory; // change with the correct nampespace

namespace Sandbox.Services // change with the correct nampespace
{
    /// <inheritdoc cref="LogBase"/>
    internal class FileLoggerService : LogBase
    {
        private static string logfileName = String.Empty;

        /// <summary>
        /// Ctor for <see cref="FileLoggerService"/>
        /// </summary>
        /// <param name="fileName"></param>
        public FileLoggerService(string fileName = "Log")
        {
            if (string.IsNullOrEmpty(logfileName))
                logfileName = $"{fileName}_{DateTime.Now:yyyyMMddHHmmssfff}.txt";
        }

        /// <inheritdoc cref="LogBase.Log(string)"/>
        public override void Log(string message)
        {
            StreamWriter file;

            lock (lockObj)
            {
                if (!File.Exists(logfileName))
                {
                    file = File.CreateText(logfileName);
                    file.WriteLine($"Test start at: {DateTime.Now}");
                    file.WriteLine($"");
                    file.WriteLine($"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    file.WriteLine($"");
                }
                else
                    file = File.AppendText(logfileName);

                file.WriteLine(message);
                file.Flush();
                file.Close();
            }
        }
    }
}
