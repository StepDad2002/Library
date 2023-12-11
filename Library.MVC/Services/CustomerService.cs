using AutoMapper;
using Library.MVC.Contracts;
using Library.MVC.Models;
using Library.MVC.Models.Customer;
using Library.MVC.Services.Base;

namespace Library.MVC.Services;

public class CustomerService(ILocalStorageService localStorage, IClient client, IMapper mapper) :
    BaseHttpService(localStorage, client), ICustomerService
{
    public async Task<List<CustomerListVM>> GetCustomers()
    {
        var customerDto = await _client.CustomerAllAsync();
        return mapper.Map<List<CustomerListVM>>(customerDto);
    }

    public async Task<CustomerVm?> GetCustomer(int id)
    {
        var customerDto = await _client.CustomerGETAsync(id);
        return mapper.Map<CustomerVm>(customerDto);
    }

    public async Task<CustomerLoansVM> GetCustomerLoans(int id)
    {
        var customerDto = await _client.LoansAsync(id);
        return mapper.Map<CustomerLoansVM>(customerDto);
    }

    public async Task<CustomerFinePaymentsVM> GetCustomerFinePayments(int id)
    {
        var customerDto = await _client.FinePaymentsAsync(id);
        return mapper.Map<CustomerFinePaymentsVM>(customerDto);
    }

    public async Task<CustomerReservationsVM> GetCustomerReservations(int id)
    {
        var customerDto = await _client.ReservationsAsync(id);
        return mapper.Map<CustomerReservationsVM>(customerDto);
    }

    public async Task<CustomerReviewsVM> GetCustomerReviews(int id)
    {
        var customerDto = await _client.ReviewsAsync(id);
        return mapper.Map<CustomerReviewsVM>(customerDto);
    }

    public async Task<Response<int>> UpdateCustomer(UpdateCustomerVM customer)
    {
        try
        {
            var customerDto = mapper.Map<UpdateCustomerDto>(customer);
            var response = await _client.CustomerPUTAsync(customerDto);
            return new Response<int>()
                { Successs = response.Success, Data = customerDto.Id, Message = response.Message,ValidationErrors = FlattErrors(response.Errors) };
        }
        catch (ApiException ex)
        {
            return ConvertApiException(ex);
        }
    }

    public async Task<Response<int>> CreateCustomer(CreateCustomerVM customer)
    {
        try
        {
            var response = new Response<int>();
            var createCustomerDto = mapper.Map<CreateCustomerDto>(customer);
            var apiResponse = await _client.CustomerPOSTAsync(createCustomerDto);

            if (apiResponse.Success)
            {
                response.Data = apiResponse.Id;
                response.Successs = apiResponse.Success;
                response.Message = apiResponse.Message;
            }
            else
            {
                response.ValidationErrors = FlattErrors(apiResponse.Errors);
            }

            return response;
        }
        catch (ApiException ex)
        {
            return ConvertApiException(ex);
        }
    }

    public async Task<Response<int>> DeleteCustomer(int id)
    {
        try
        {
            await _client.CustomerDELETEAsync(id);
            return new Response<int>() { Successs = true, Message = "Deleted successfully" };
        }
        catch (ApiException e)
        {
            return ConvertApiException(e);
        }
    }

    public async Task<Response<int>> LogIn(LoginVM login)
    {
        try
        {
            var log = mapper.Map<LogInDto>(login);
            var loginResponse = await _client.LogCusAsync(log);
            return new Response<int>() { Successs = loginResponse.Success, Message = loginResponse.Message, Data = loginResponse.Id};
        }
        catch (ApiException e)
        {
            return ConvertApiException(e);
        }
    }
}