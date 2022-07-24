using EP_Planning_BackMicroservice.Domain;
using EP_Planning_BackMicroservice.Entities;
using EP_Planning_BackMicroservice.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Planning_BackMicroservice.Service
{
    public class ProductosService
    {
        #region Public Methods
        public ProductosResponse Execute(ProductosRequest request)
        {
            ProductosResponse response = new ProductosResponse();
            response.InitializeResponse(request);
            try
            {
                if (response.LstError.Count == 0)
                {
                    switch (request.Operation)
                    {
                        case Operation.Undefined:
                            //otro metodo 
                            break;
                        case Operation.Add:
                            response.Resultado = new ProductosDomain().CreateProductos(request.Item);
                            break;
                        case Operation.Edit:
                            response.Item = new ProductosDomain().EditProductos(request.Item);
                            break;
                        case Operation.Delete:
                            response.Item = new ProductosDomain().DeleteProductos(request.Item.Id);
                            break;
                        default:
                            break;
                    }
                    response.IsSuccess = true;
                }
            }
            catch (CustomException ex)
            {
                response.LstError.Add(ex.CustomMessage);
            }
            catch (Exception ex)
            {
                response.LstError.Add("Server Error");
            }
            return response;
        }

        public ProductosItemResponse GetProductosById(ProductosItemRequest request)
        {
            ProductosItemResponse response = new ProductosItemResponse();

            response.InitializeResponse(request);
            try
            {
                if (response.LstError.Count == 0)
                {
                    switch (request.FilterType)
                    {
                        case ProductosFilterItemType.Undefined:
                            break;
                        case ProductosFilterItemType.ById:
                            response.Item = new ProductosDomain().GetById(request.Filter.Id);
                            break;
                        default:
                            break;
                    }
                    response.IsSuccess = true;
                }
            }
            catch (CustomException ex)
            {
                response.LstError.Add(ex.CustomMessage);
            }
            catch (Exception ex)
            {
                response.LstError.Add("Server Error");
            }
            return response;
        }


        public ProductosLstItemResponse GetLstProductos(ProductosLstItemRequest request)
        {
            ProductosLstItemResponse response = new ProductosLstItemResponse();
            response.InitializeResponse(request);
            try
            {
                if (response.LstError.Count == 0)
                {
                    switch (request.FilterType)
                    {
                        case ProductosFilterLstItemType.ByPrecios:
                            response.LstItem = new ProductosDomain().GetByPrecios(request.Filter, request.FilterType, request.Pagination);
                            break;
                        default:
                            break;
                    }
                    response.IsSuccess = true;
                }
            }
            catch (CustomException ex)
            {
                response.LstError.Add(ex.CustomMessage);
            }
            catch (Exception ex)
            {
                response.LstError.Add("Server Error");
            }
            return response;
        }
        #endregion
    }
}
