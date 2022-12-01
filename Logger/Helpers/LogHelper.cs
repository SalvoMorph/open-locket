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
        public static void Log(LogTarget target, string message, string fileName = "Log")
        {
            switch (target)
            {
                case LogTarget.File:
                    logger = new FileLoggerService(fileName);
                    logger.Log(message);
                    break;
                case LogTarget.Console:
                    logger = new ConsoleLoggerService();
                    logger.Log(message);
                    break;
                case LogTarget.Both:
                    logger = new ConsoleLoggerService();
                    logger.Log(message);
                    logger = new FileLoggerService(fileName);
                    logger.Log(message);
                    break;
                default: return;
            }
        }
    }
}
