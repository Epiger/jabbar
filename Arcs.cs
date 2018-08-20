using System;

namespace Jabbar.Graph {

    public class ReferenceArc {

        public int type;

        public string target;


        public ReferenceArc(int type, string target){
            this.type = type;
            this.target = target;
        }

    }

}