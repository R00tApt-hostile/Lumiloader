using System;
using System.Diagnostics;
using System.IO;

namespace LumiaSideloadToolkit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lumia Sideloading Toolkit");
            Console.WriteLine("Enter the path to the app package (.appx or .appxbundle):");
            string appPackagePath = Console.ReadLine();

            if (File.Exists(appPackagePath))
            {
                InstallApp(appPackagePath);
            }
            else
            {
                Console.WriteLine("Invalid file path. Please check and try again.");
            }
        }

        static void InstallApp(string appPackagePath)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-Command \"Add-AppxPackage -Path '{appPackagePath}'\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(processInfo))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.WriteLine(result);
                }
            }

            Console.WriteLine("Installation process completed.");
        }
    }
}
