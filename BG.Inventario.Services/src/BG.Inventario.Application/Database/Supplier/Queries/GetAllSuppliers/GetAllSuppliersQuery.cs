using AutoMapper;
using BG.Inventario.Application.Database.Product.Commands.CreateProduct;
using BG.Inventario.Application.Database.Product.Queries.GetAllProducts.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Application.Database.Supplier.Queries.GetAllSuppliers
{
    public class GetAllSuppliersQuery : IGetAllSuppliersQuery
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateProductCommand> _logger;

        public GetAllSuppliersQuery(IDatabaseService databaseService, IMapper mapper, ILogger<CreateProductCommand> logger)
        {
            _databaseService = databaseService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<GetAllSuppliersModel>> Execute()
        {
            try
            {
                _logger.LogInformation("Iniciando consulta global de proveedores.");

                var productEntities = await _databaseService.Supplier.Where(x => x.Status == "ACTIVE").ToListAsync();

                return _mapper.Map<List<GetAllSuppliersModel>>(productEntities);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error de infraestructura al listar proveedores.");
                throw new Exception("No se pudo obtener el catálogo de proveedores debido a un error de conexión.", ex);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogCritical(ex, "Fallo en el mapeo de la lista de proveedores.");
                throw new Exception("Error al procesar el formato de la lista de proveedores.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado en GetAllSuppliersModel.");
                throw new Exception("Ocurrió un error interno al recuperar el catálogo.", ex);
            }
        }
    }
}
