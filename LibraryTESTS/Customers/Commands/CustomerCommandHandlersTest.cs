using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs;
using Library.Application.DTOs.Customer;
using Library.Application.Exeptions;
using Library.Application.Features.Customer.Handlers.Commands;
using Library.Application.Features.Customer.Requests.Commands;
using Library.Application.Profiles;
using Library.Application.Responses;
using LibraryTESTS.Mocks;
using Moq;
using Shouldly;

namespace LibraryTESTS.Customers.Commands;

public class CustomerCommandHandlersTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;

    public CustomerCommandHandlersTest()
    {
        _unitOfWorkMock = MockUnitOfWork.GetUnitOfWork();
        var mapperCfg = new MapperConfiguration(c => { c.AddProfile<CustomerProfile>(); });

        _mapper = mapperCfg.CreateMapper();
    }

    [Fact]
    public async Task TryLogIn_Should_ReturnCustomerId1_WhenGoodEmailAndPassword()
    {
        var handler = new CustomerLoginCommandHandler(_unitOfWorkMock.Object);
        LogInDto login = new LogInDto()
        {
            Email = "misha@email.com",
            Password = "111111"
        };
        var result = await handler.Handle(new CustomerLoginCommand() { Login = login },
            default);

        result.ShouldBeOfType<BaseCommandResponse>();
        result.Id.ShouldBe(1);
    }

    [Fact]
    public async Task TryLogIn_Should_Fail_WhenEmailAndPasswordIsWrong()
    {
        var handler = new CustomerLoginCommandHandler(_unitOfWorkMock.Object);
        LogInDto login = new LogInDto()
        {
            Email = "notEmail@gmail.com",
            Password = "badpassword"
        };
        var result = await handler.Handle(new CustomerLoginCommand() { Login = login },
            default);

        result.Success.ShouldBe(false);
    }

    [Fact]
    public async Task AddCustomer_Should_Success_WhenDataIsValid()
    {
        var handler = new CreateCustomerCommandHandler(_unitOfWorkMock.Object, _mapper);

        CreateCustomerDto customer = new CreateCustomerDto()
        {
            Email = "mulo@gmail.com",
            FName = "Customer",
            LName = "Customer",
            Password = "123456",
            Phone = "555-555-55-55"
        };

        var result = await handler.Handle(new CreateCustomerCommand() { Customer = customer },
            default);
        var totalCount = ((await _unitOfWorkMock.Object.CustomerRepository.GetAllAsync())!).Count;

        result.Success.ShouldBe(true);
        totalCount.ShouldBe(6);
    }

    [Fact]
    public async Task AddCustomer_Should_Fail_WhenDataIsInvalid()
    {
        var handler = new CreateCustomerCommandHandler(_unitOfWorkMock.Object, _mapper);

        CreateCustomerDto customer = new CreateCustomerDto()
        {
            //existing email
            Email = "misha@gmail.com",
            FName = "Customer",
            LName = "Customer",
            Password = "123456",
            //wrong phone format
            Phone = "555-5552-552-55"
        };

        var result = await handler.Handle(new CreateCustomerCommand() { Customer = customer },
            default);
        var totalCount = ((await _unitOfWorkMock.Object.CustomerRepository.GetAllAsync())!).Count;


        result.Success.ShouldBe(false);
        totalCount.ShouldBe(5);
    }

    [Fact]
    public async Task DeleteCustomer_Should_Success_WhenCustomerExists()
    {
        var handler = new DeleteCustomerCommandHandler(_unitOfWorkMock.Object);

        await Should.NotThrowAsync(async () =>
        {
            await handler.Handle(new DeleteCustomerCommand() { Id = 1 }, default);
        });

        (await _unitOfWorkMock.Object.CustomerRepository.GetAllAsync()).Count.ShouldBe(4);
    }

    [Fact]
    public async Task DeleteCustomer_Should_Fail_WhenCustomerDoseNotExist()
    {
        var handler = new DeleteCustomerCommandHandler(_unitOfWorkMock.Object);

        await Should.ThrowAsync<NotFoundException>(async () =>
        {
            await handler.Handle(new DeleteCustomerCommand() { Id = 10 }, default);
        });

        (await _unitOfWorkMock.Object.CustomerRepository.GetAllAsync()).Count.ShouldBe(5);
    }

    [Fact]
    public async Task UpdateCustomer_Should_Success_WhenDataIsValid()
    {
        var handler = new UpdateCustomerCommandHandler(_unitOfWorkMock.Object, _mapper);

        UpdateCustomerDto customer = new UpdateCustomerDto()
        {
            Email = "newemail@mail.com",
            FName = "KOLOBOK",
            Phone = "777-777-77-77",
            LName = "KIBA",
            Id = 2,
            Password = "256325"
        };

        var result = await handler.Handle(new UpdateCustomerCommand() {Customer = customer},
            default);
        
        result.Success.ShouldBe(true);
        result.UpdatedMember.ShouldBe(null);
    }
    
    [Fact]
    public async Task UpdateCustomer_Should_Fail_WhenDataIsInvalid()
    {
        var handler = new UpdateCustomerCommandHandler(_unitOfWorkMock.Object, _mapper);

        UpdateCustomerDto customer = new UpdateCustomerDto()
        {
            Email = "misha@mail.com",
            FName = "KOLOBOK",
            Phone = "7773-7277-77-77",
            LName = "KIBA",
            Id = 10,
            Password = "256325"
        };

        var result = await handler.Handle(new UpdateCustomerCommand() {Customer = customer},
            default);
        
        result.Success.ShouldBe(false);
        result.UpdatedMember.ShouldBe(customer);
    }
}