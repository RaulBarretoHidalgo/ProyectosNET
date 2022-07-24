using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Planning_BackMicroservice.Exceptions
{
    public class FailAddProductosHeaderException : CustomException
    {
        public override string CustomMessage
        {
            get
            {
                return "Prueba Fail inserting header";
            }
        }
    }
}
