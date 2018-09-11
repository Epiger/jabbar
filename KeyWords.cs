using System;
using System.Collections.Generic;

namespace Jabbar.Keywords {




    public static class Java {

        public static List<string> accessLevelModifiers = new List<string>(){"public", "private", "protected"};

        public static List<string> initialValue = new List<string>(){"static"};

        public static List<string> subclassable = new List<string>(){"abstract", "final"};

        public static List<string> ignorable = new List<string>(){"transient", "volatile"};

        public static List<string> primitiveTypes = new List<string>(){"boolean", "byte", "char", "short", "int", "long", "float", "double"};


        public static List<string> oneOpOperators = new List<string>(){"-", "+", "!", "++", "--", "~",};

        public static List<string> twoOpOperators = new List<string>(){"*","/", "%", "+", "-", "<<", ">>", "<<<", ">>>", "<", ">", "<=", ">=", "instanceof", "==", "!=", "&", "^", "|", "&&", "||", "?", ":", "=", "+=", "-=", "*=", "/=", "%=", "<<=", ">>=", "<<<=", ">>>=", "&=", "|=", "^="};

        public static List<string> complexOperators = new List<string>(){"()", "[]", ".", "new", "(#)"};

    }


}