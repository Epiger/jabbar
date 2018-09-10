using System;
using System.Collections.Generic;
using Jabbar.Graph;
using Jabbar.Keywords;

namespace Jabbar {

    public class JavaReferenceIdentifier {

        static List<ReferenceArc> fallBack = new List<ReferenceArc>();


        public static void GetReferences(string sep, List<string> localVars, List<Node> nodes, int actual){
            GetAnnotation(sep, localVars, nodes, actual);


        }


        public static void GetAnnotation(string sep, List<string> localVars, List<Node> nodes, int actual){
            //Check if it is an Annotation
            if(!sep.StartsWith('@'))
                return;
            
            //Get Name
            string name;
            if(sep.Contains('(')){
                name = sep.Substring(1, sep.IndexOf('(')-1);
            }else {
                name = sep.Substring(1);
            }

            //If there is no node
            if(actual > -1 && actual < nodes.Count){
                nodes[actual].arcs.Add(new ReferenceArc((int)RefType.ANNOTATION_REF, name));
            }else {
                fallBack.Add(new ReferenceArc((int)RefType.ANNOTATION_REF, name));
            }

            //Look for content
            if(!sep.Contains('('))
                return;

            //Get and analyze content
            foreach(string part in sep.Substring(sep.IndexOf('('), sep.LastIndexOf(')') - sep.IndexOf('(')).Split(',')){
                GetReferences(part.Trim(), localVars, nodes, actual);
            }


        }

        public static void GetDeklaration(string sep, List<string> localVars, List<Node> nodes, int actual){
            List<string> releva = new List<string>();
            foreach(string sepera in sep.Split(' ')){
                if(!Java.accessLevelModifiers.Contains(sepera) && !Java.initialValue.Contains(sepera) && !Java.subclassable.Contains(sepera) && !sepera.Contains("@")){
                    releva.Add(sepera);
                }
            }
            
            int endmarker = releva.IndexOf("=");
            if(endmarker != -1){
                if(endmarker > 1){
                    localVars.Add(releva[endmarker-1]);
                    if(!Java.primitiveTypes.Contains(releva[endmarker-2])){
                        nodes[actual].arcs.Add(new ReferenceArc((int)RefType.OBJECT_DEK, releva[endmarker-2]));
                    }
                }
            }else{
                if(releva[releva.Count-1].EndsWith(";")){
                    endmarker = releva.Count;
                    RemoveChar(releva, ';');
                    localVars.Add(releva[endmarker-1]);
                    if(!Java.primitiveTypes.Contains(releva[endmarker-2])){
                        nodes[actual].arcs.Add(new ReferenceArc((int)RefType.OBJECT_DEK, releva[endmarker-2]));
                    }
                }
            }

        }

        public static void RemoveChar(List<string> list, char chr){
            for(int i = 0; i < list.Count; i++){
                while(list[i].Contains(chr)){
                    string elem = list[i].Substring(0, list[i].IndexOf(chr));
                    if(list[i].IndexOf(chr)+1 != list[i].Length){
                        elem = elem + list[i].Substring(list[i].IndexOf(chr)+1, list[i].Length - (list[i].IndexOf(chr)+1));
                    }
                    list[i] = elem;
                }
            }
        }

    }
    
}
