
namespace Jabbar.Graph {

    public class References {

        public void getClassReferences(InterpreterPack pack){
            


        }

    }

    namespace Jabbar.Graph.References {

        public class NewClassRef : ReferenceArc{
            
            private NewClassRef(string target) : base((int)RefType.NEW_CLASS, target){}

            public static void GetRefrence(InterpreterPack pack){
                
            }

        }




    }
}