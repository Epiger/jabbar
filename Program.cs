using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

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
            //interpreter.Interpret($"{Directory.GetCurrentDirectory()}{sep}exJaPro{sep}src{sep}com{sep}none{sep}helloworld{sep}HelloWorld.java");
            //interpreter.Interpret($"{Directory.GetCurrentDirectory()}{sep}exJaPro{sep}src{sep}com{sep}none{sep}helloworld{sep}InnerClassTest.java");

            foreach(string file in files){
                interpreter.Interpret(file);
            }



            


            
            

            Console.ReadKey();
        }
    }
}
