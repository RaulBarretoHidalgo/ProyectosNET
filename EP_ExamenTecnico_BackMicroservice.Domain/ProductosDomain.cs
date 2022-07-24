using EP_Planning_BackMicroservice.Entities;
using EP_Planning_BackMicroservice.Exceptions;
using EP_Planning_BackMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Util;

namespace EP_Planning_BackMicroservice.Domain
{
    public class ProductosDomain
    {
        #region MEF
        [Import]
        private IProductosRepository _ProductosRepository { get; set; }
        #endregion

        #region Constructor
        public ProductosDomain()
        {
            _ProductosRepository = MEFContainer.Container.GetExport<IProductosRepository>();
        }
        #endregion

        #region Methods Public 
        public int CreateProductos(ProductosEntity productos)
        {
            int id = 0;
            bool exito = false;
#if !debug
            using (TransactionScope tx = new TransactionScope())
            {
#endif
                id = _ProductosRepository.InsertProductos(productos);
                if (id == 0)
                {
                    throw new FailAddProductosHeaderException();
                }
                else
                {
                    exito = true;
                }
                if (exito) tx.Complete();
            }
            return id;
        }

        public bool EditProductos(ProductosEntity productos)
        {
#if !debug
            using (TransactionScope tx = new TransactionScope())
            {
#endif
                if (_ProductosRepository.UpdateProductos(productos))
                {
                    tx.Complete();
                    return true;
                }
            }
            return false;
        }

        public bool DeleteProductos(string Id)
        {
            bool exito = false;
            exito = _ProductosRepository.DeleteProductos(Id);

            return exito;
        }

        public ProductosEntity GetById(string Id)
        {
            ProductosEntity productos = null;
            productos = _ProductosRepository.GetItemProductos(
            new ProductosFilter() { Id = Id }, ProductosFilterItemType.ById);

            return productos;
        }

        public IEnumerable<ProductosEntity> GetByPrecios(ProductosFilter filter, ProductosFilterLstItemType filterType, Pagination pagination)
        {
            List<ProductosEntity> lst = null;
            lst = _ProductosRepository.GetLstItemProductos(filter, filterType).ToList();

            return lst;
        }

        #endregion
    }
}
