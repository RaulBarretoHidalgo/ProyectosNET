using Dapper;
using EP_Planning_BackMicroservice.Entities;
using EP_Planning_BackMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Planning_BackMicroservice.Infraestructure
{
    [Export(typeof(IProductosRepository))]
    public class ProductosRepository : BaseRepository, IProductosRepository
    {
        #region Constructor
        [ImportingConstructor]
        public ProductosRepository(IConnectionFactory cn) : base(cn)
        {
        }
        #endregion

        #region Public Methods
        public int InsertProductos(ProductosEntity item)
        {
            int afect = 0;           
            var query = "dbo.USP_Productos_Insert";
            var param = new DynamicParameters();
            param.Add("@Id", item.Id, DbType.String);
            param.Add("@Name", item.Name, DbType.String);
            param.Add("@Type", item.Type, DbType.String);
            param.Add("@Price", item.Price, DbType.Decimal);          

            afect = SqlMapper.Execute(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
                      
            return afect;
        }

        public bool UpdateProductos(ProductosEntity item)
        {
            bool exito = false;
            int afect = 0;           
            var query = "dbo.USP_Productos_Update";
            var param = new DynamicParameters();
            param.Add("@Id", item.Id, DbType.String);
            param.Add("@Name", item.Name, DbType.String);
            param.Add("@Type", item.Type, DbType.String);
            param.Add("@Price", item.Price, DbType.Decimal);

            afect = SqlMapper.Execute(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);

            exito = afect > 0;

            return exito;
        }

        public bool DeleteProductos(string Id)
        {
            bool exito = false;
            var afect = 0;
            var query = "dbo.USP_Productos_Delete";
            var param = new DynamicParameters();
            param.Add("@Id", Id, DbType.String );

            afect = SqlMapper.Execute(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);

            exito = afect > 0;

            return exito;
        }

        public ProductosEntity GetItemProductos(ProductosFilter filter, ProductosFilterItemType filterType)
        {
            ProductosEntity itemFound = null;

            switch (filterType)
            {
                case ProductosFilterItemType.ById:
                    itemFound = this.GetById(filter.Id);
                    break;
                default:
                    break;
            }
            return itemFound;
        }

        public IEnumerable<ProductosEntity> GetLstItemProductos(ProductosFilter filter, ProductosFilterLstItemType filterType)
        {
            IEnumerable<ProductosEntity> lstItemFound = new List<ProductosEntity>();
            switch (filterType)
            {              
                case ProductosFilterLstItemType.ByPrecios:
                    lstItemFound = this.GetByPrecios(filter.PrecioInicial,filter.PrecioFinal);
                    break;
                default:
                    break;
            }
            return lstItemFound;
        }



        public bool Update(ProductosEntity item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Methods
        private ProductosEntity GetById(string Id)
        {
            ProductosEntity itemFound = null;
            var query = "dbo.Productos_Get";
            var param = new DynamicParameters();
            param.Add("@Id", Id, DbType.Int32);

            itemFound = SqlMapper.QueryFirstOrDefault<ProductosEntity>(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);

            return itemFound;
        }

        private IEnumerable<ProductosEntity> GetByPrecios(decimal pPrecioInicial,decimal pPrecioFinal)
        {
            IEnumerable<ProductosEntity> lstFound = new List<ProductosEntity>();
            var query = "USP_Productos_Get_ByPrice";
            var param = new DynamicParameters();
            param.Add("@pPrecioInicial", pPrecioInicial, DbType.Decimal);
            param.Add("@pPrecioFinal", pPrecioFinal, DbType.Decimal);

            lstFound = SqlMapper.Query<ProductosEntity>(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);

            return lstFound;
        }
        #endregion
    }
}
