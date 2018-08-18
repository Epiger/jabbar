using System;
using System.IO;

namespace Jabbar {

    
    class Program{

        static string jabbarLo = "\r\n\r\n    ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n    ░░░░░░░██░████████░████████░████████░░████████░███████░░░\r\n    ░░░░░░░██░██░░░░██░██░░░░██░██░░░░░██░██░░░░██░██░░░░██░░\r\n    ░░░░░░░██░██░░░░██░██░░░░██░██░░░░░██░██░░░░██░██░░░░██░░\r\n    ░░░░░░░██░██░░░░██░██░░░░██░██░░░░░██░██░░░░██░██░░░░██░░\r\n    ░░░░░░░██░████████░████████░████████░░████████░███████░░░\r\n    ░░░░░░░██░██░░░░██░██░░░░██░██░░░░░██░██░░░░██░██░░██░░░░\r\n    ░░░░░░░██░██░░░░██░██░░░░██░██░░░░░██░██░░░░██░██░░░██░░░\r\n    ░░███████░██░░░░██░██░░░░██░████████░░██░░░░██░██░░░░██░░\r\n    ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░";

        static FileFinder fileFinder;
        static void Main(string[] args){
            if(args.Length == 0){
                Console.WriteLine(jabbarLo);
                Console.WriteLine("\r\n         ##############################################\r\n         # Project analyzer for removing unused files #\r\n         ##############################################");
                Console.WriteLine("\r\n\r\n-------------------------------------------------------------------\r\n");
            }

            Console.WriteLine("Enter working directory, [Enter] for the current directory");
            Console.Write($"{Directory.GetCurrentDirectory()}> ");
            string dir = Console.ReadLine();

            if(dir == "")
                dir = Directory.GetCurrentDirectory();
            

            if(!Directory.Exists(dir)){
                Console.WriteLine("This directory doesn't exist!!");
                Console.ReadKey();
                return;
            }


            fileFinder = new FileFinder($"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}exJaPro");

            foreach(string file in fileFinder.FindJavaFiles()){
                Console.WriteLine(file);
            }
            

            
            

            Console.ReadKey();
        }
    }
}
