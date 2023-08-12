using CompanyServer.Core.Application.Warehouses.CommandHandler;
using CompanyServer.Core.Application.Warehouses.Commands;
using CompanyServer.Core.Domain.Companys;
using CompanyServer.Core.Domain.Warehouses;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace CompanyServer.UnitTetst.Domain;

public class WarehouseCommandHandlerTests
{
    private WarehouseCommandHandler _handler;
    private ICompanyRepository _companyRepository;
    private IWarehouseRepository _warehouseRepository;
    private IWarehouseChecker _warehouseChecker;

    [SetUp]
    public void SetUp()
    {
        _companyRepository = Substitute.For<ICompanyRepository>();
        _warehouseRepository = Substitute.For<IWarehouseRepository>();
        _warehouseChecker = Substitute.For<IWarehouseChecker>();
        _handler = new WarehouseCommandHandler(_companyRepository, _warehouseRepository, _warehouseChecker);
    }

    [Test]
    public void ShouldThroWarehouseIsAlreadyExists()
    {
        var company = CompanyProvider.CreateCompany("刀手", "3213465@qq.com", "test", "123456789");

        _companyRepository.GetByIdAsync(company.Id).Returns(company);
        _warehouseChecker.IsUniqueWithName(company.Id,Arg.Any<string>()).Returns(false);
        
        Should.Throw<WarehouseBusinessValidateException>(async () =>
        {
            await _handler.Handle(new AddWarehouseCommand()
            {
                Address = "test",
                Code = "test",
                CompanyId = company.Id,
                Description = "test1",
                Name = "test22"
            }, default);
        });
    }
    
    [Test]
    public async Task Handle_UniqueName_AddsWarehouse()
    {
        // Arrange
        var company =  CompanyProvider.CreateCompany("刀手", "3213465@qq.com", "test", "123456789");
    
        _companyRepository.GetByIdAsync(company.Id).Returns(company);
        _warehouseChecker.IsUniqueWithName(company.Id, Arg.Any<string>()).Returns(true);
    
        var handler = new WarehouseCommandHandler(_companyRepository, _warehouseRepository, _warehouseChecker);
        var command = new AddWarehouseCommand
        {
            CompanyId = company.Id,
            Name = "New Warehouse",
            Code = "W001",
            Address = "123 Main St",
            Description = "Test warehouse"
        };

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        await _companyRepository.Received(1).GetByIdAsync(company.Id);
        await _warehouseRepository.Received(1).AddAsync(Arg.Any<Warehouse>());
        result.ShouldBe(Guid.Empty);
    }

}