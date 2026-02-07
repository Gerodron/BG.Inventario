using BG.Inventario.Application.Database.Product.Commands.CreateProduct;
using BG.Inventario.Application.Database.Product.Commands.DeleteProductById;
using BG.Inventario.Application.Database.Product.Commands.UpdateProductById;
using BG.Inventario.Application.Database.Product.Queries.GetAllProducts;
using BG.Inventario.Application.Database.Product.Queries.GetProductById;
using BG.Inventario.Application.Database.ProductSuppliersSummary.Queries.GetProductSuppliers;
using BG.Inventario.Application.Database.ProductSuppliersSummary.Queries.GetProductSuppliersById;
using BG.Inventario.Application.Database.Supplier.Commands.CreateSupplier;
using BG.Inventario.Application.Database.Supplier.Queries.GetAllSuppliers;
using BG.Inventario.Application.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;   

namespace BG.Inventario.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts(
            [FromServices] IGetAllProductsQuery services
        )
        {
            try
            {
                var data = await services.Execute();
                return Ok(ResponseApiService.Response(StatusCodes.Status200OK, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseApiService.Response(StatusCodes.Status400BadRequest, ex.Message));
            }
        }

        [HttpGet("GetProductById")]

        public async Task<IActionResult> GetProductById(
            [FromServices] IGetProductByIdQuery service,
            [FromQuery] int productId
        )
        {
            try
            {
                var data = await service.Execute(productId);
                return Ok(ResponseApiService.Response(StatusCodes.Status200OK, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseApiService.Response(StatusCodes.Status400BadRequest, ex.Message));
            }
        }

        [HttpGet("GetProductSuppliersById")]
        public async Task<IActionResult> GetProductSuppliersByIdQuery(
            [FromServices] IGetProductSuppliersByIdQuery services,
            [FromQuery] int productId
        )
        {
            try
            {
                var data = await services.Execute(productId);
                return Ok(ResponseApiService.Response(StatusCodes.Status200OK, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseApiService.Response(StatusCodes.Status400BadRequest, ex.Message));
            }
        }


        [HttpGet("GetProductSuppliers")]
        public async Task<IActionResult> GetProductSuppliers(
            [FromServices] IGetProductSuppliersQuery services
        )
        {
            try
            {
                var data = await services.Execute();
                return Ok(ResponseApiService.Response(StatusCodes.Status200OK, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseApiService.Response(StatusCodes.Status400BadRequest, ex.Message));
            }
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(
            [FromServices] ICreateProductCommand services,
            [FromBody] CreateProductModel model
        )
        {
            try
            {
                var result = await services.Execute(model);
                return Ok(ResponseApiService.Response(StatusCodes.Status200OK, result));

            }
            catch (Exception ex)
            {
                return BadRequest(ResponseApiService.Response(StatusCodes.Status400BadRequest, ex.Message));
            }
        }

        [HttpDelete("DeleteProductById")]
        public async Task<IActionResult> DeleteProductById(
            [FromServices] IDeleteProductByIdCommand service,
            [FromQuery] int id
        )
        {
            try
            {
                var result = await service.Execute(id);
                if (!result)
                    return StatusCode(StatusCodes.Status400BadRequest, result);
                return Ok(ResponseApiService.Response(StatusCodes.Status200OK, result));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseApiService.Response(StatusCodes.Status400BadRequest, ex.Message));
            }
        }

        [HttpPut("UpdateProductById")]
        public async Task<IActionResult> UpdateProductById(
            [FromServices] IUpdateProductByIdCommand service,
            [FromBody] UpdateProducByIdModel model
        )
        {
            try
            {
                var result = await service.Execute(model);
                if (!result)
                    return StatusCode(StatusCodes.Status400BadRequest, result);

                return Ok(ResponseApiService.Response(StatusCodes.Status200OK, result));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseApiService.Response(StatusCodes.Status400BadRequest, ex.Message));
            }
        }


        [HttpPost("CreateSupplier")]
        public async Task<IActionResult> CreateSupplier(
            [FromServices] ICreateSupplierCommand service,
            [FromBody] CreateSupplierModel model
        )
        {
            try
            {
                var result = await service.Execute(model);
                if (!result)
                    return StatusCode(StatusCodes.Status400BadRequest, result);
                return Ok(ResponseApiService.Response(StatusCodes.Status200OK, result));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseApiService.Response(StatusCodes.Status400BadRequest, ex.Message));
            }
        }

        [HttpGet("GetAllSuppliers")]
        public async Task<IActionResult> GetAllSuppliers(
            [FromServices] IGetAllSuppliersQuery service
        )
        {
            try
            {
                var result = await service.Execute();
                if (result is null)
                    return StatusCode(StatusCodes.Status400BadRequest, result);

                return Ok(ResponseApiService.Response(StatusCodes.Status200OK, result));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseApiService.Response(StatusCodes.Status400BadRequest, ex.Message));
            }
        }
    }
}
