using EP_Planning_BackMicroservice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Planning_BackMicroservice.Service
{
    public static class ProductosRequestValidator
    {
        #region Validate 
        public static void ValidateRequest(this ProductosResponse response, ProductosRequest request)
        {
            if (request.Item == null)
            {
                response.LstError.Add("Se requiere la entidad Estructura");
            }
            if (string.IsNullOrEmpty(request.ServerName))
            {
                response.LstError.Add("No se identifico el servidor de origen para la solicitud");
            }
            if (string.IsNullOrEmpty(request.UserName))
            {
                response.LstError.Add("No se identifico el usuario que realizo la solicitud");
            }
        }
        #endregion

        #region Initialize 
        public static void InitializeResponse(this ProductosResponse response, ProductosRequest request)
        {
            response.Ticket = request.Ticket;
            response.ServerName = request.ServerName;
            response.UserName = request.UserName;
        }
        public static void InitializeResponse(this ProductosItemResponse response, ProductosItemRequest request)
        {
            response.Ticket = request.Ticket;
            response.ServerName = request.ServerName;
            response.UserName = request.UserName;
        }
        public static void InitializeResponse(this ProductosLstItemResponse response, ProductosLstItemRequest request)
        {
            response.Ticket = request.Ticket;
            response.ServerName = request.ServerName;
            response.UserName = request.UserName;
            response.Pagination = request.Pagination;
        }
        #endregion
    }
}
