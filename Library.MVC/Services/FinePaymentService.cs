using AutoMapper;
using Library.MVC.Contracts;
using Library.MVC.Models.FinePayment;
using Library.MVC.Services.Base;

namespace Library.MVC.Services;

public class FinePaymentService(ILocalStorageService localStorage, IClient client, IMapper mapper) :
    BaseHttpService(localStorage, client), IFinePaymentService
{
    public async Task<List<FinePaymentListVM>> GetFinePayments()
    {
        var paymentDtos = await _client.FinePaymentAllAsync();
        return mapper.Map<List<FinePaymentListVM>>(paymentDtos);
    }

    public async Task<List<FinePaymentListVM>> GetFinePaymentsByDate(DateTime paymentDate)
    {
        var paymentDtos = await _client.DateAsync(paymentDate);
        return mapper.Map<List<FinePaymentListVM>>(paymentDtos);
    }

    public async Task<List<FinePaymentListVM>> GetFinePaymentsByCustomerPhone(string phone)
    {
        var paymentDtos = await _client.CustPhoneAsync(phone);
        return mapper.Map<List<FinePaymentListVM>>(paymentDtos);
    }

    public async Task<FinePaymentVM> GetFinePayment(int id)
    {
        var paymentDto = await _client.FinePaymentGETAsync(id);
        return mapper.Map<FinePaymentVM>(paymentDto);
    }

    public async Task<Response<int>> UpdateFinePayment(UpdateFinePaymentVM payment)
    {
        try
        {
            var finePaymentDto = mapper.Map<UpdateFinePaymentDto>(payment);
            var response = await _client.FinePaymentPUTAsync(finePaymentDto);
            return new Response<int>()
                { Successs = response.Success, Data = finePaymentDto.Id, Message = response.Message,ValidationErrors = FlattErrors(response.Errors) };
        }
        catch (ApiException ex)
        {
            return ConvertApiException(ex);
        }
    }

    public async Task<Response<int>> CreateFinePayment(CreateFinePaymentVM payment)
    {
        try
        {
            var response = new Response<int>();
            var createFinePaymentDto = mapper.Map<CreateFinePaymentDto>(payment);
            var apiResponse = await _client.FinePaymentPOSTAsync(createFinePaymentDto);

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

    public async Task<Response<int>> DeleteFinePayment(int id)
    {
        try
        {
            await _client.FinePaymentDELETEAsync(id);
            return new Response<int>() { Successs = true, Message = "Deleted successfully" };
        }
        catch (ApiException e)
        {
            return ConvertApiException(e);
        }
    }
}