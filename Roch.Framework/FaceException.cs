using System;
using System.Collections.Generic;
using System.Text;

namespace Roch.Framework
{
    public class FaceException : ApplicationException
    {
        public FaceException(string message)
            : base(message)
        {
 
        }

        public FaceException(int code,string message)
            : base(message)
        {

        }
    }
}
