using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jabbar.Data;

namespace Jabbar {

    
    class Program{

        static string jabbarLo = "\r\n\r\n    ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n    ░░░░░░░██░████████░████████░████████░░████████░███████░░░\r\n    ░░░░░░░██░██░░░░██░██░░░░██░██░░░░░██░██░░░░██░██░░░░██░░\r\n    ░░░░░░░██░██░░░░██░██░░░░██░██░░░░░██░██░░░░██░██░░░░██░░\r\n    ░░░░░░░██░██░░░░██░██░░░░██░██░░░░░██░██░░░░██░██░░░░██░░\r\n    ░░░░░░░██░████████░████████░████████░░████████░███████░░░\r\n    ░░░░░░░██░██░░░░██░██░░░░██░██░░░░░██░██░░░░██░██░░██░░░░\r\n    ░░░░░░░██░██░░░░██░██░░░░██░██░░░░░██░██░░░░██░██░░░██░░░\r\n    ░░███████░██░░░░██░██░░░░██░████████░░██░░░░██░██░░░░██░░\r\n    ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░";
        static char sep = Path.DirectorySeparatorChar;
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
            List<string> files = fileFinder.FindJavaFiles();
            foreach(string file in files){
                Console.WriteLine(file);
            }
            
            JavaFileInterpreter interpreter = new JavaFileInterpreter();

            List<JavaFile> jfiles = new List<JavaFile>();


            foreach(string file in files){
                jfiles.Add(interpreter.Interpret(file));
            }


            //JavaClassInterpreter tests
            JavaClassInterpreter classInterpreter = new JavaClassInterpreter();
            classInterpreter.InterpretClass(jfiles[2].classes[0], jfiles[2].package);



            


            
            

            Console.ReadKey();
        }
    }
}
