using System;
using System.Diagnostics.CodeAnalysis;
using Sandbox.Factory; // change with the correct nampespace

namespace Sandbox.Services // change with the correct nampespace
{
    /// <inheritdoc cref="LogBase"/>
    internal class ConsoleLoggerService : LogBase
    {
        /// <inheritdoc cref="LogBase.Log(string)"/>
        public override void Log(string message)
        {
            lock (lockObj)
            {
                Console.WriteLine(message);
            }
        }
    }
}
