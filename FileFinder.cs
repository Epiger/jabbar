using System.IO;
using System;
using System.Collections.Generic;

namespace Jabbar{

    public class FileFinder{
        
        string path = "";
        public FileFinder(string dirPath){
            path = dirPath;
        }


        public List<string> FindJavaFiles(){
            List<string> javaFiles = new List<string>();
            javaFiles = GetAllFiles(path);
            for(int i = 0; i < javaFiles.Count; i++){
                if(!javaFiles[i].EndsWith(".java", true, null)){
                    javaFiles.RemoveAt(i);
                }
            }
            return javaFiles;
        }

        ///<summary>
        ///IDK THis is just a test
        ///</summary>
        public List<string> GetAllFiles(string dir){
            List<string> files = new List<string>();
            List<int> index = new List<int>();
            string currentDir = dir;
            bool movedDown = false;
            
            do{
                if(!movedDown){
                    index.Add(0);
                    files = addFilesToList(files, currentDir);
                }
                string[] a = Directory.GetDirectories(currentDir);
                if(a.Length <= index[index.Count-1]){
                    index.RemoveAt(index.Count-1);
                    if(index.Count != 0){
                        index[index.Count-1] += 1;
                        cddotdot(currentDir);
                        movedDown = true;
                    }
                }else {
                    currentDir = a[index[index.Count-1]];
                    movedDown = false;
                }
            }while(index.Count != 0);

            


            return files;
        }

        public List<string> addFilesToList(List<string> list, string path){
            foreach(string file in Directory.GetFiles(path)){
                list.Add(file);
            }
            return list;
        }

        
        public string cddotdot(string path){
            string topath = path;
            if(path.LastIndexOf(Path.DirectorySeparatorChar) == path.Length-1){
                topath = path.Substring(0, path.Length-1);
            }
            topath = topath.Substring(0, path.LastIndexOf(Path.DirectorySeparatorChar));
            return topath;
        }


    }

}