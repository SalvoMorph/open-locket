using System.Diagnostics.CodeAnalysis;
using Sandbox.Factory; // change with the correct nampespace
using Sandbox.Models; // change with the correct nampespace
using Sandbox.Services; // change with the correct nampespace

namespace Sandbox.Helpers // change with the correct nampespace
{
    /// <summary>
    /// The Log Helper
    /// </summary>
    internal static class LogHelper
    {
        private static LogBase logger = null;

        /// <summary>
        /// Log the message
        /// </summary>
        /// <param name="target"><see cref="LogTarget"/></param>
        /// <param name="message">The message to log.</param>
        /// <param name="fileName">Default is Log</param>
        public static void LogInfo(LogTarget target, string message, string fileName = "Log")
        {
            Log(target, ParseMessageWithLogType(message, LogType.INFO), fileName);
        }

        /// <summary>
        /// Log the Warning Message
        /// </summary>
        /// <param name="target"><see cref="LogTarget"/></param>
        /// <param name="message">The message to log.</param>
        /// <param name="fileName">Default is Log</param>
        public static void LogWarning(LogTarget target, string message, string fileName = "Log")
        {
            Log(target, ParseMessageWithLogType(message, LogType.WARNING), fileName);
        }

        /// <summary>
        /// Log the Error Message
        /// </summary>
        /// <param name="target"><see cref="LogTarget"/></param>
        /// <param name="message">The message to log.</param>
        /// <param name="fileName">Default is Log</param>
        public static void LogError(LogTarget target, string message, string fileName = "Log")
        {
            Log(target, ParseMessageWithLogType(message, LogType.ERROR), fileName);
        }

        #region Private Methods
        
        private static void Log(LogTarget target, string message, string fileName)
        {
            switch (target)
            {
                case LogTarget.File:
                    logger = new FileLoggerService(fileName);
                    logger.Log(message);
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

        #endregion
    }
}
