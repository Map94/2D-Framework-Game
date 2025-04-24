using System;
using System.Diagnostics;
using System.IO;

namespace _2D_Framework_Game.Utilities
{
    public static class LoggingConfig
    {
        public static void Configure()
        {
            // Add TraceListener for the console
            Trace.Listeners.Add(new ConsoleTraceListener());

            // Specify the file path where you want the log file to be saved
            string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "game_log.txt");

            // Ensure the directory exists
            string directory = Path.GetDirectoryName(logFilePath);
            if (!Directory.Exists(directory))
            {
                Console.WriteLine($"Directory for log file doesn't exist, creating it: {directory}");
                Directory.CreateDirectory(directory);
            }

            // Add the TextWriterTraceListener for file output
            Trace.Listeners.Add(new TextWriterTraceListener(logFilePath));

            // Optionally, you can flush after writing to the file and console
            Trace.AutoFlush = true;

            // Make sure the listeners are flushed properly to the console
            Trace.Flush();
        }
    }
}
