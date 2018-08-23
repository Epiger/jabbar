using System;
using System.Collections.Generic;

namespace Jabbar.Graph {

    public class Node {

        public string name;

        public int type;

        public List<ReferenceArc> arcs = new List<ReferenceArc>();

        public Node(int type){
            this.type = type;
        }


    }



    public class ClassNode : Node{

        public string package;

        public string location;

        public bool entryPoint = false;

        public ClassNode() : base((int) NodeType.CLASS) {}

    }

    public class InterfaceNode : Node{

        public string package;

        public string location;

        public InterfaceNode() : base((int) NodeType.INTERFACE) {}

    }

    public class EnumNode : Node{

        public string package;

        public string location;

        public EnumNode() : base((int) NodeType.INTERFACE) {}

    }


    public class AnnotationNode : Node{

        public string package;

        public string location;

        public AnnotationNode() : base((int) NodeType.INTERFACE) {}

    }



    public enum NodeType : int {
        CLASS = 0, INTERFACE = 1, ENUM = 2, ANNOTATION = 3
    }

}