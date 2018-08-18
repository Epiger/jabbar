using System;
using System.Collections.Generic;

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

    public enum JavaType{CLASS, INTERFACE, ENUM, ANNOTATION}
}