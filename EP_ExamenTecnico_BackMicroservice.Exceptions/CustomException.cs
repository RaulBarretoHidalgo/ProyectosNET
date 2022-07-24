using System;
using System.Collections.Generic;
using System.Text;

namespace EP_Planning_BackMicroservice.Exceptions
{
    public class CustomException : ApplicationException
    {
        public virtual string CustomMessage { get; }
    }
}
