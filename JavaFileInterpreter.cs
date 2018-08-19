using System;
using System.IO;
using Jabbar.Data;
using Jabbar.Keywords;
using System.Collections.Generic;
using Jabbar.Exceptions;

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
            //Read file
            string file = ReadFile(path);
            //Package
            Console.WriteLine(GetPackage(file));
            //Imports
            foreach(string import in GetImports(file)){
                Console.WriteLine(import);
            }
            //Classes
            foreach(string clas in GetClasses(path, file)){
                Console.WriteLine(JavaCIEAHolder.getObject(clas).content);
            }
            //Interfaces
            foreach(string inter in GetInterfaces(path, file)){
                Console.WriteLine(JavaCIEAHolder.getObject(inter).content);
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

        public List<string> GetClasses(string path, string file){
            List<string> classes = new List<string>();
            int offset = 0;
            while(file.IndexOf("class", offset) > -1) {
                int clas = file.IndexOf("class", offset);
                int start = 0;
                int end = 0;

                bool foundStart = false;

                foreach(string keyword in Java.accessLevelModifiers){
                    if(file.IndexOf(keyword, clas - 30, 30) > -1){
                        start = file.IndexOf(keyword, clas - 30, 30);
                        foundStart = true;
                        break;
                    }                 
                }


                if(file.IndexOf(Java.initialValue[0], clas - 20, 20) > -1 && !foundStart){
                    start = file.IndexOf(Java.initialValue[0], clas - 20, 20);
                }

                //If there is no accessLevelModifer and no static it will search for final or abstract
                foreach(string keyword in Java.subclassable){
                    if(file.IndexOf(keyword, clas - 12, 12) > -1 && !foundStart){
                        start = file.IndexOf(keyword, clas - 12, 12);
                        foundStart = true;
                        break;
                    }                 
                }

                //If there is no private, public, protected, static, final or abstract the begin of the class is set to the class keyword
                if(!foundStart){
                    start = clas;
                }


                int openBrackets = 0;
                int nextBracketOffset = start;
                do {
                    int nextOpen = file.IndexOf("{", nextBracketOffset);
                    int nextClose = file.IndexOf("}", nextBracketOffset);
                    if(nextOpen == -1){
                        if(nextClose != -1){
                            //01
                            openBrackets--;
                            nextBracketOffset = file.IndexOf("}", nextBracketOffset)+1;
                        }else {
                            //00
                            throw new NotClosedBracketsException($"Some of the brackets in file: {path}, weren\'t closed!");
                        }
                    }else if(nextClose == -1 && nextOpen != -1){
                        //10
                        throw new NotClosedBracketsException($"Some of the brackets in file: {path}, weren\'t closed!");
                    }else if(file.IndexOf("{", nextBracketOffset) < file.IndexOf("}", nextBracketOffset)){
                        //11
                        openBrackets++;
                        nextBracketOffset = file.IndexOf("{", nextBracketOffset)+1;
                    }else {
                        //11
                        openBrackets--;
                        nextBracketOffset = file.IndexOf("}", nextBracketOffset)+1;
                    }

                } while (openBrackets != 0);


                end = nextBracketOffset;
                offset = end;
                //offset = clas + 5;

                //classes.Add(file.Substring(start, end - start));
                classes.Add(JavaCIEAHolder.getJsonObject(new JavaCIEAHolder(file.Substring(start, end - start), start, end)));



            }


            return classes;
        }


        public List<string> GetInterfaces(string path, string file) {
            List<string> interfaces = new List<string>();
            int offset = 0;
            while(file.IndexOf("interface", offset) > -1) {
                int inter = file.IndexOf("interface", offset);
                int start = 0;
                int end = 0;

                bool foundStart = false;

                foreach(string keyword in Java.accessLevelModifiers){
                    if(file.IndexOf(keyword, inter - 30, 30) > -1){
                        start = file.IndexOf(keyword, inter - 30, 30);
                        foundStart = true;
                        break;
                    }                 
                }


                if(file.IndexOf(Java.initialValue[0], inter - 20, 20) > -1 && !foundStart){
                    start = file.IndexOf(Java.initialValue[0], inter - 20, 20);
                }

                //If there is no accessLevelModifer and no static it will search for final or abstract
                foreach(string keyword in Java.subclassable){
                    if(file.IndexOf(keyword, inter - 12, 12) > -1 && !foundStart){
                        start = file.IndexOf(keyword, inter - 12, 12);
                        foundStart = true;
                        break;
                    }                 
                }

                //If there is no private, public, protected, static, final or abstract the begin of the class is set to the class keyword
                if(!foundStart){
                    start = inter;
                }


                int openBrackets = 0;
                int nextBracketOffset = start;
                do {
                    int nextOpen = file.IndexOf("{", nextBracketOffset);
                    int nextClose = file.IndexOf("}", nextBracketOffset);
                    if(nextOpen == -1){
                        if(nextClose != -1){
                            //01
                            openBrackets--;
                            nextBracketOffset = file.IndexOf("}", nextBracketOffset)+1;
                        }else {
                            //00
                            throw new NotClosedBracketsException($"Some of the brackets in file: {path}, weren\'t closed!");
                        }
                    }else if(nextClose == -1 && nextOpen != -1){
                        //10
                        throw new NotClosedBracketsException($"Some of the brackets in file: {path}, weren\'t closed!");
                    }else if(file.IndexOf("{", nextBracketOffset) < file.IndexOf("}", nextBracketOffset)){
                        //11
                        openBrackets++;
                        nextBracketOffset = file.IndexOf("{", nextBracketOffset)+1;
                    }else {
                        //11
                        openBrackets--;
                        nextBracketOffset = file.IndexOf("}", nextBracketOffset)+1;
                    }

                } while (openBrackets != 0);


                end = nextBracketOffset;
                //offset = end;
                offset = inter + 5;

                //interfaces.Add(file.Substring(start, end - start));
                interfaces.Add(JavaCIEAHolder.getJsonObject(new JavaCIEAHolder(file.Substring(start, end - start), start, end)));



            }


            return interfaces;
        }






        


    }


}