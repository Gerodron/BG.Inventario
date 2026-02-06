using AutoMapper;
using BG.Inventario.Application.Database.ProductSuppliersSummary.Queries.GetProductSuppliersById;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Application.Database.ProductSuppliersSummary.Queries.GetProductSuppliers
{
    public class GetProductSuppliersQuery : IGetProductSuppliersQuery
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductSuppliersQuery> _logger;


        public GetProductSuppliersQuery(IDatabaseService databaseService, IMapper mapper, ILogger<GetProductSuppliersQuery> logger)
        {
            _databaseService = databaseService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<GetProductSuppliersModel>> Execute()
        {
            try
            {
                _logger.LogInformation("Iniciando consulta de proveedores y productos asociados");

                var productSuppliers = await _databaseService.vw_ProductSupplierSumary.ToListAsync();

                if (productSuppliers == null || !productSuppliers.Any())
                {
                    _logger.LogWarning("No se encontraron proveedores asociados a productos en la base de datos");
                }
                else
                {
                    _logger.LogInformation("Se encontraron {Count} registros de proveedores asociados a productos", productSuppliers.Count);
                }

                return _mapper.Map<List<GetProductSuppliersModel>>(productSuppliers);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error de base de datos al obtener los proveedores y productos");
                throw new Exception("No se pudo recuperar la información de proveedores y productos debido a un error en la base de datos.", ex);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error de mapeo de datos al convertir la información de proveedores y productos");
                throw new Exception("Ocurrió un error al procesar los datos de proveedores y productos.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al consultar proveedores y productos");
                throw new Exception("Se produjo un error inesperado al consultar los proveedores y productos.", ex);
            }
        }


    }
}
