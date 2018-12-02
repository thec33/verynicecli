using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace verynicecli
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string currentInput = Console.ReadLine();
            switch(currentInput.Split(' ')[0])
            {
                default:
                    break;

                case "r":
                    startProcess(GetShortcutDir()+FileName(currentInput)+FileType(currentInput));
                    break;
            }
            startProcess(GetShortcutDir()+currentInput);

        }

        public static string FileName(string input)
        {
            return(input.Split(' ')[1]);
        }

        public static string FileType(string input)
        {
            return("."+input.Split(' ')[2]);
        }

        public static string GetShortcutDir()
        {
            string shortcutDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            shortcutDirectory = Regex.Split(shortcutDirectory, @"bin")[0] + @"shortcuts\";
            return(shortcutDirectory);
        }
        public static void startProcess(string filename)
        {
            Process ExternalProcess = new Process();
            ExternalProcess.StartInfo.FileName = filename;
            ExternalProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            ExternalProcess.StartInfo.UseShellExecute = true;
            ExternalProcess.Start();
            System.Environment.Exit(0);
        }
    }
}
