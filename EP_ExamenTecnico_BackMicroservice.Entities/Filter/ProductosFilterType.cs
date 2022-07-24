using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Planning_BackMicroservice.Entities
{
    public enum ProductosFilterItemType : byte
    {
        Undefined,
        ById
    }

    public enum ProductosFilterLstItemType : byte
    {
        Undefined,
        ByPrecios       
    }
}
