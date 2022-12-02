using System.Diagnostics.CodeAnalysis;
using Sandbox.Factory; // change with the correct nampespace
using Sandbox.Models; // change with the correct nampespace
using Sandbox.Services; // change with the correct nampespace

namespace Sandbox.Helpers // change with the correct nampespace
{
    /// <summary>
    /// The Log Helper
    /// </summary>
    internal static class LogTestHelper
    {
        private static LogBase logger = null;

        /// <summary>
        /// Log the message
        /// </summary>
        /// <param name="target"><see cref="LogTarget"/></param>
        /// <param name="message">The message to log.</param>
        /// <param name="logType"><see cref="LogType"/></param>
        /// <param name="fileName">Default is Log</param>
        public static void Log(LogTarget target, string message, LogType logType = LogType.INFO, string fileName = "Log")
        {
            switch (target)
            {
                case LogTarget.File:
                    logger = new FileLoggerService(fileName);
                    logger.Log(ParseMessageWithLogType(message, logType));
                    break;
                case LogTarget.Console:
                    logger = new ConsoleLoggerService();
                    logger.Log(ParseMessageWithLogType(message, logType));
                    break;
                case LogTarget.Both:
                    logger = new ConsoleLoggerService();
                    logger.Log(ParseMessageWithLogType(message, logType));
                    logger = new FileLoggerService(fileName);
                    logger.Log(ParseMessageWithLogType(message, logType));
                    break;
                default: return;
            }
        }

        private string ParseMessageWithLogType(string message, LogType logType)
        {
            switch(logType)
            {
                case LogType.INFO: return $"Info: {message}";
                case LogType.WARNING: return $"Warning: {message}";
                case LogType.ERROR: return $"Error: {message}";
            }
        }
    }
}
