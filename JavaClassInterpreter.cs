using System;
using Jabbar.Graph;
using System.Collections.Generic;
using Jabbar.Data;
using System.IO;



namespace Jabbar {

    public class JavaClassInterpreter {
        
        
        

        public List<Node> InterpretClass(string clas, string package){
            List<Node> nodes = new List<Node>();

            //Initialize the ClassStram Reader
            ClassStreamReader csr = new ClassStreamReader();
            csr.Setup(JavaCIEAHolder.getObject(clas).content, null);

            //Fill a List with all parts of the class
            List<string> seps = new List<string>();
            do {
                seps.Add(csr.readTillNextSep());
                Console.WriteLine(seps[seps.Count-1]);
            }while (seps[seps.Count-1] != null && seps[seps.Count-1] != "");



            

            return nodes;
        }

        //ClassName, Class implements, Class extends
        public string GetNameAfterKeyword(List<string> clasSeps, string keyword){
            foreach(string sep in clasSeps){
                if(sep.Contains(keyword)){
                    string[] parts = sep.Split(" ");
                    int gotcha = -1;
                    for(int i = 0; i < parts.Length; i++){
                        if(parts[i].Contains(keyword)){
                            return RemoveChar(parts[i+1], '{');
                        }
                    }
                }
            }
            return "";
        }


        public string RemoveChar(string str, char which){
            while(str.Contains(which)){
                str = str.Remove(str.IndexOf(which), 1);
            }
            return str;
        }


    }

    public class InterpreterPack {

        public List<Node> nodes;
        public int actualNode;
        public List<string> seps;
        public int actualSep;
        public List<List<string>> vars;
        public List<string> imports;
        public string package;

        public InterpreterPack(List<Node> nodes, int actualNode, List<string> seps, int actualSep, List<List<string>> vars, List<string> imports, string package){
            this.nodes = nodes;
            this.actualNode = actualNode;
            this.seps = seps;
            this.actualSep = actualSep;
            this.vars = vars;
            this.imports = imports;
            this.package = package;
        }

    }


    public class ClassStreamReader {

        string clas = "";
        List<char> seperators = new List<char>{'{', ';', '}'};
        int offset = 0;

        public void Setup(string clas, List<char> streamSeps){
            this.clas = clas;
            if(streamSeps != null){
                seperators = streamSeps;
            } 
        }


        public string readTillNextSep(){
            if(clas == "")
                return null;
            
            int nextSep = -2;
            foreach(char sepera in seperators){
                int actSep = clas.IndexOf(sepera, offset);
                if(nextSep < 0){
                    nextSep = actSep;
                }else if(actSep < nextSep){
                    nextSep = actSep;
                }
            }

            if(clas.Substring(offset).Trim().StartsWith('@')){
                nextSep = clas.IndexOf("\n", clas.IndexOf('@', offset));
            }

            if(nextSep < 0)
                return "";

            string next = clas.Substring(offset, (nextSep - offset) +1).Trim();
            offset = nextSep+1;

            return next;
        }


        public void Close(){
            offset = 0;
        }


    }


}