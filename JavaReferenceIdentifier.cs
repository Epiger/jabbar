using System;
using System.Collections.Generic;
using Jabbar.Graph;

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


    }

}