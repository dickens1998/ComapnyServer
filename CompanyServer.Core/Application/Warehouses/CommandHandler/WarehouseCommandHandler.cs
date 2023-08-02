using CompanyServer.Core.Application.Warehouses.Commands;
using CompanyServer.Core.Domain.Companys;
using CompanyServer.Core.Domain.Warehouses;
using MediatR;

namespace CompanyServer.Core.Application.Warehouses.CommandHandler;

public class WarehouseCommandHandler : IRequestHandler<AddWarehouseCommand, Guid>,
    IRequestHandler<DeleteWarehouseCommand, bool>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IWarehouseChecker _warehouseChecker;

    public WarehouseCommandHandler(ICompanyRepository companyRepository, IWarehouseRepository warehouseRepository,
        IWarehouseChecker warehouseChecker)
    {
        _companyRepository = companyRepository;
        _warehouseRepository = warehouseRepository;
        _warehouseChecker = warehouseChecker;
    }

    public async Task<Guid> Handle(AddWarehouseCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyRepository.GetByIdAsync(request.CompanyId).ConfigureAwait(false);
        if (!_warehouseChecker.IsUniqueWithName(company.Id, request.Name))
            throw new WarehouseBusinessValidateException("Warehouse name must be unique");

        var warehouse = company.AddWarehouse(request.Name, request.Code, request.Address, request.Description);

        await _warehouseRepository.AddAsync(warehouse).ConfigureAwait(false);
        return warehouse.Id;
    }

    public async Task<bool> Handle(DeleteWarehouseCommand request, CancellationToken cancellationToken)
    {
        var warehouse = await _warehouseRepository.GetByIdAsync(request.WarehouseId);

        if (_warehouseChecker.CalculateWarehouseUsers(warehouse.Id) > 0)
            throw new WarehouseBusinessValidateException("Warehouse in use");

        _warehouseRepository.Delete(warehouse);
        return await _warehouseRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken).ConfigureAwait(false);
    }
}