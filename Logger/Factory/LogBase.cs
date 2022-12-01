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
        /// Log method
        /// </summary>
        /// <param name="message">Message to print</param>
        public abstract void Log(string message);
    }
}
