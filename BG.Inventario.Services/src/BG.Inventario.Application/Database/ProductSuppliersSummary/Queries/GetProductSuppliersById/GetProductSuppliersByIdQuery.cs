using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BG.Inventario.Application.Database.ProductSuppliersSummary.Queries.GetProductSuppliersById
{
    public class GetProductSuppliersByIdQuery : IGetProductSuppliersByIdQuery
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductSuppliersByIdQuery> _logger;

        public GetProductSuppliersByIdQuery(IDatabaseService databaseService, IMapper mapper, ILogger<GetProductSuppliersByIdQuery> logger)
        {
            _databaseService = databaseService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<GetProductSuppliersByIdSupplierModel>> Execute(int supplierId)
        {
            try
            {
                _logger.LogInformation("Consultando proveedores asociados al producto ID: {SupplierId}", supplierId);

                var productSuppliers = await _databaseService.vw_ProductSupplierSumary
                    .Where(ps => ps.SupplierId == supplierId)
                    .ToListAsync();

                if (productSuppliers == null || !productSuppliers.Any())
                {
                    _logger.LogWarning("No se encontraron proveedores para el producto ID: {SupplierId}", supplierId);
                }

                return _mapper.Map<List<GetProductSuppliersByIdSupplierModel>>(productSuppliers);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error de SQL al obtener proveedores para el producto {SupplierId}", supplierId);
                throw new Exception("No se pudo recuperar la información de proveedores debido a un fallo en el servidor de datos.", ex);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error de mapeo en GetProductSuppliersByIdQuery");
                throw new Exception("Error al procesar el formato de los datos de abastecimiento.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error no controlado en GetProductSuppliersByIdQuery");
                throw new Exception("Se produjo un error inesperado al consultar los proveedores del producto.", ex);
            }
        }
    }
}
