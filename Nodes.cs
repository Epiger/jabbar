using System;
using System.Collections.Generic;

namespace Jabbar.Graph {

    public class Node {

        public string name;

        public int type;

        List<ReferenceArc> arcs = new List<ReferenceArc>();

        public Node(string name, int type){
            this.name = name;
            this.type = type;
        }


    }



    public class ClassNode : Node{

        public string package;

        public string location;

        public bool entryPoint = false;

        public ClassNode(string name) : base(name, (int) NodeType.CLASS) {}

    }

    public class InterfaceNode : Node{

        public string package;

        public string location;

        public InterfaceNode(string name) : base(name, (int) NodeType.INTERFACE) {}

    }

    public class EnumNode : Node{

        public string package;

        public string location;

        public EnumNode(string name) : base(name, (int) NodeType.INTERFACE) {}

    }


    public class AnnotationNode : Node{

        public string package;

        public string location;

        public AnnotationNode(string name) : base(name, (int) NodeType.INTERFACE) {}

    }



    public enum NodeType : int {
        CLASS = 0, INTERFACE = 1, ENUM = 2, ANNOTATION = 3
    }

}