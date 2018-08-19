using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Jabbar.Data {

    public class JavaFile {
        public List<string> imports = new List<string>();
        public List<string> classes = new List<string>();
        public List<string> interfaces = new List<string>();
        public List<string> enums = new List<string>();
        public List<string> annotations = new List<string>();

    
        public string path = "";
        public string package = "";

        public void createNodeFromFile(JavaType type, int which){

        }

    }

    public class JavaCIEAHolder {

        public string content;
        public int start;
        public int end;

        public JavaCIEAHolder(string content, int start, int end){
            this.content = content;
            this.start = start;
            this.end = end;
        }


        public static JavaCIEAHolder getObject(string jsonObj){
            return JsonConvert.DeserializeObject<JavaCIEAHolder>(jsonObj);
        }

        public static string getJsonObject(JavaCIEAHolder obj){
            return JsonConvert.SerializeObject(obj);
        }

    }

    public enum JavaType{CLASS, INTERFACE, ENUM, ANNOTATION}
}