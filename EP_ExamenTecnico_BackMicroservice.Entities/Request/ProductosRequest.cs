using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Planning_BackMicroservice.Entities
{
    public class ProductosRequest : OperationRequest<ProductosEntity>
    {
    }

    public class ProductosItemRequest : FilterItemRequest<ProductosFilter, ProductosFilterItemType>
    {
    }

    public class ProductosLstItemRequest : FilterLstItemRequest<ProductosFilter, ProductosFilterLstItemType>
    {
    }
}
