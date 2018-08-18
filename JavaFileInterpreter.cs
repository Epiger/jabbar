using System;
using System.IO;
using Jabbar.Data;

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
            
            return null;
        }


    }


}