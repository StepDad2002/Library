using AutoMapper;
using Library.Application.DTOs.Customer;
using Library.Application.Exeptions;
using Library.Application.Features.Customer.Requests.Queries;
using Library.Application.Profiles;
using LibraryTESTS.Mocks;
using Shouldly;

namespace LibraryTESTS.Customers.Queries;

public class CustomerRequestHandlersTest
{
    private readonly IMapper _mapper;

    public CustomerRequestHandlersTest()
    {
        var mapperCfg = new MapperConfiguration(c => { c.AddProfile<CustomerProfile>(); });

        _mapper = mapperCfg.CreateMapper();
    }

    [Fact]
    public async Task GetCustomerListRequestHandler_Should_Return_5()
    {
        var handler = new GetCustomerListRequestHandler(MockUnitOfWork.GetUnitOfWork().Object, _mapper);

        var resulet = await handler.Handle(new GetCustomerListRequest(), default);

        resulet.ShouldBeOfType<List<CustomerListDto>>();

        resulet.Count.ShouldBe(5);
    }

    [Fact]
    public async Task GetCustomerById_2_Should_NotBeNull()
    {
        var handler = new GetCustomerRequestHandler(MockUnitOfWork.GetUnitOfWork().Object, _mapper);

        var result = await handler.Handle((new GetCustomerRequest() { Id = 2 }), default);

        result.ShouldNotBeNull();
        result.ShouldBeOfType<CustomerDto>();
    }

    [Fact]
    public async Task GetCustomerById_10_Should_ThrowException_WhenNotFound()
    {
        var handler = new GetCustomerRequestHandler(MockUnitOfWork.GetUnitOfWork().Object, _mapper);

        await Should.ThrowAsync<NotFoundException>(async () =>
        {
            await handler.Handle((new GetCustomerRequest() { Id = 10 }), default);
        });
    }

    [Fact]
    public async Task GetCustomerByPhone_Should_BeCorrect_WhenPhoneFormatIsGood()
    {
        var handler = new GetCustomerByPhoneRequestHandler(MockUnitOfWork.GetUnitOfWork().Object, _mapper);

        var result = await handler.Handle(new GetCustomerByPhoneRequest()
            { Phone = "111-111-11-11" }, default);

        result.ShouldBeOfType<CustomerListDto>();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task GetCustomerByPhone_Should_BeIncorrect_WhenPhoneFormatIsBad()
    {
        var handler = new GetCustomerByPhoneRequestHandler(MockUnitOfWork.GetUnitOfWork().Object, _mapper);

        await Should.ThrowAsync<NotFoundException>(async () =>
        {
            await handler.Handle(new GetCustomerByPhoneRequest()
                { Phone = "111-111-1-1" }, default);
        });
    }

    [Fact]
    public async Task GetCustomerByEmail_Should_BeCorrect_WhenEmailFormatIsGood()
    {
        var handler = new GetCustomerByEmailRequestHandler(MockUnitOfWork.GetUnitOfWork().Object, _mapper);

        var result = await handler.Handle(new GetCustomerByEmailRequest()
            { Email = "podushka@email.com" }, default);

        result.ShouldBeOfType<CustomerListDto>();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task GetCustomerByEmail_Should_BeIncorrect_WhenEmailFormatIsBad()
    {
        var handler = new GetCustomerByEmailRequestHandler(MockUnitOfWork.GetUnitOfWork().Object, _mapper);

        await Should.ThrowAsync<NotFoundException>(async () =>
        {
            await handler.Handle(new GetCustomerByEmailRequest()
                { Email = "notMail" }, default);
        });
    }
}