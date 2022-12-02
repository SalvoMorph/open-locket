using System.Diagnostics.CodeAnalysis;

namespace Sandbox.Factory // change with the correct nampespace
{
    /// <summary>
    /// The Log Base
    /// </summary>
    internal abstract class LogBase
    {
        protected readonly object lockObj = new object();

        /// <summary>
        /// Log the message
        /// </summary>
        /// <param name="message">Message to log</param>
        public abstract void Log(string message);
    }
}
