using System;
using System.IO;
using Jabbar.Data;
using System.Collections.Generic;

namespace Jabbar{

    public class JavaFileInterpreter{


        public string ReadFile(string path){
            using(StreamReader sr = new StreamReader(path)){
                return sr.ReadToEnd();
            }
            //He says unreachable code
            //return "";
        }


        public JavaFile Interpret(string path){
            string file = ReadFile(path);
            Console.WriteLine(GetPackage(file));
            foreach(string import in GetImports(file)){
                Console.WriteLine(import);
            }



            return null;
        }

        public string GetPackage(string file){
            int pack = file.IndexOf("package");
            return file.Substring(pack+7, file.IndexOf(";", pack) - (pack+7)).Trim();
        }

        public List<string> GetImports(string file){
            List<string> imports = new List<string>();
            int offset = 0;

            while(file.IndexOf("import", offset) > -1){

                int impo = file.IndexOf("import", offset);
                imports.Add(file.Substring(impo+6, file.IndexOf(";", impo) - (impo+6)).Trim());
                offset = file.IndexOf(";", impo)+1;

            }
            return imports;
        }


    }


}