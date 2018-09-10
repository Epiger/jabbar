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


    public enum RefType : int{
        CLASS_IMPLEMENTS = 0,
        CLASS_EXTENDS = 1,
        NEW_CLASS = 2,
        STATIC_METHOD_REF = 3,
        STATIC_FIELD_REF = 4,
        OBJECT_DEK = 5,
        OBJECT_INIT = 6,
        OBJECT_FIELD_REF = 7,
        OBJECT_METHOD_REF = 8,
        RETURN_TYPE_REF = 9,
        PARAMETER_REF = 10,
        GENERIC_REF = 11,
        ANNOTATION_REF = 12,
        IMPORT_REF = 13


    }

}