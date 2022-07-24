using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Planning_BackMicroservice.Entities
{
    public class ProductosResponse : ItemResponse<bool>
    {
    }

    public class ProductosItemResponse : ItemResponse<ProductosEntity>
    {
    }

    public class ProductosLstItemResponse : LstItemResponse<ProductosEntity>
    {
    }
}
