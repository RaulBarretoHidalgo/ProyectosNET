using EP_Planning_BackMicroservice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Planning_BackMicroservice.Repository
{
    public interface IProductosRepository : IGenericRepository<ProductosEntity>
    {
        int InsertProductos(ProductosEntity item);
        ProductosEntity GetItemProductos(ProductosFilter filter, ProductosFilterItemType filterType);
        IEnumerable<ProductosEntity> GetLstItemProductos(ProductosFilter filter, ProductosFilterLstItemType filterType);
        bool UpdateProductos(ProductosEntity item);
        bool DeleteProductos(string Id);
    }
}
