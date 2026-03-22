using System;
using System.Collections.Generic;
using System.Text;

namespace FMStatHub.Utilities
{
    public static class Logger
    {
        private static readonly string LogPath = "fmstathub_log.txt";

        public static void Info(string message)
        {
            WriteLog("INFO", message);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[INFO] {message}");
            Console.ResetColor();
        }

        public static void Success(string message)
        {
            WriteLog("OK", message);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[OK] {message}");
            Console.ResetColor();
        }

        public static void Warning(string message)
        {
            WriteLog("WARN", message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[WARN] {message}");
            Console.ResetColor();
        }

        public static void Error(string message)
        {
            WriteLog("ERROR", message);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] {message}");
            Console.ResetColor();
        }

        private static void WriteLog(string level, string message)
        {
            try
            {
                string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
                File.AppendAllText(LogPath, entry + Environment.NewLine);
            }
            catch
            {
                // Αν αποτύχει το logging, δεν σκοτώνουμε το πρόγραμμα
            }
        }
    }
}
