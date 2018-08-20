using System;

namespace Jabbar.Exceptions {

    [System.Serializable]
    public class NotClosedBracketsException : System.Exception{
        public NotClosedBracketsException() { }
        public NotClosedBracketsException(string message) : base(message) { }
        public NotClosedBracketsException(string message, System.Exception inner) : base(message, inner) { }
        protected NotClosedBracketsException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}