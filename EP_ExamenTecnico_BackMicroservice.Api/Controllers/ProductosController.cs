using EP_Planning_BackMicroservice.Entities;
using EP_Planning_BackMicroservice.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EP_Planning_BackMicroservice.Api.Controllers
{
    /// <summary>
    /// api/[controller]
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        #region Operations
        /// <summary>
        /// Insert
        /// </summary>
        [HttpPost("Insert")]
        public IActionResult Post([FromBody] ProductosEntity productos)
        {
            ProductosResponse response = null;
            ProductosRequest request = new ProductosRequest()
            {
                Item = productos,
                Operation = Operation.Add
            };
            try
            {
                response = new ProductosService().Execute(request);
                if (!response.IsSuccess)
                    return BadRequest(response);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }

        /// <summary>
        /// Update
        /// </summary>
        [HttpPut("Update")]
        public IActionResult Put([FromBody] ProductosEntity productos)
        {
            ProductosResponse response = null;
            ProductosRequest request = new ProductosRequest()
            {
                Item = productos,
                Operation = Operation.Edit
            };
            try
            {
                response = new ProductosService().Execute(request);
                if (!response.IsSuccess)
                    return BadRequest(response);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }

        /// <summary>
        /// Delete
        /// </summary>
        [HttpDelete("Delete")]
        public IActionResult Delete(string Id)
        {
            ProductosResponse response = null;
            ProductosRequest request = new ProductosRequest()
            {
                Item = new ProductosEntity() { Id = Id },
                Operation = Operation.Delete
            };
            try
            {
                response = new ProductosService().Execute(request);
                if (!response.IsSuccess)
                    return BadRequest(response);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }

        /// <summary>
        /// GetById
        /// </summary>
        [HttpGet("{Id}", Name = "Productos_GetById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetById(string Id)
        {
            ProductosItemResponse response = null;
            ProductosItemRequest request = new ProductosItemRequest()
            {
                Filter = new ProductosFilter() { Id = Id },
                FilterType = ProductosFilterItemType.ById
            };

            try
            {
                response = new ProductosService().GetProductosById(request);
                if (!response.IsSuccess)
                    return BadRequest(response);
            }
            catch (Exception)
            {
                throw;
            }

            return Ok(response);
        }


        /// <summary>
        /// GetByPlan
        /// </summary>
        [HttpGet("GetByPrecios", Name = "Productos_GetByPrecios")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetByPrecios(decimal PrecioInicial, decimal PrecioFinal)
        {

            ProductosLstItemResponse response = null;
            ProductosLstItemRequest request = new ProductosLstItemRequest()
            {
                Filter = new ProductosFilter() { PrecioInicial = PrecioInicial, PrecioFinal = PrecioFinal },
                FilterType = ProductosFilterLstItemType.ByPrecios
            };

            try
            {
                response = new ProductosService().GetLstProductos(request);
                if (!response.IsSuccess)
                    return BadRequest(response);
            }
            catch (Exception)
            {
                throw;
            }

            return Ok(response);
        }
        #endregion
    }
}
