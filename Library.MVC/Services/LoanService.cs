using AutoMapper;
using Library.MVC.Contracts;
using Library.MVC.Models.Loan;
using Library.MVC.Services.Base;

namespace Library.MVC.Services;

public class LoanService(ILocalStorageService localStorage, IClient client, IMapper mapper) :
    BaseHttpService(localStorage, client), ILoanService
{
    public async Task<List<LoanListVM>> GetLoans()
    {
        var loanDtos = await _client.LoanAllAsync();
        return mapper.Map<List<LoanListVM>>(loanDtos);
    }

    public async Task<List<LoanListVM>> GetLoansByLoanDate(DateTime date)
    {
        var loanDtos = await _client.Date2Async(date);
        return mapper.Map<List<LoanListVM>>(loanDtos);
    }

    public async Task<List<LoanListVM>> GetLoansByReturnedDate(DateTime date)
    {
        var loanDtos = await _client.DueDateAsync(date);
        return mapper.Map<List<LoanListVM>>(loanDtos);
    }

    public async Task<List<LoanListVM>> GetLoansByDueDate(DateTime date)
    {
        var loanDtos = await _client.RetDateAsync(date);
        return mapper.Map<List<LoanListVM>>(loanDtos);
    }

    public async Task<List<LoanListVM>> GetLoansByBookTitle(string title)
    {
        var loanDtos = await _client.BookTitleAsync(title);
        return mapper.Map<List<LoanListVM>>(loanDtos);
    }

    public async Task<List<LoanListVM>> GetLoansByCustomerPhone(string phone)
    {
        var loanDtos = await _client.CustPhone2Async(phone);
        return mapper.Map<List<LoanListVM>>(loanDtos);
    }

    public async Task<LoanVM> GetLoan(int id)
    {
        var loanDto = await _client.LoanGETAsync(id);
        return mapper.Map<LoanVM>(loanDto);
    }

    public async Task<Response<int>> UpdateLoan(UpdateLoanVM loan)
    {
        try
        {
            var loanDto = mapper.Map<UpdateLoanDto>(loan);
            var response = await _client.LoanPUTAsync(loanDto);
            return new Response<int>()
                { Successs = response.Success, Data = loanDto.Id, Message = response.Message,ValidationErrors = FlattErrors(response.Errors) };
        }
        catch (ApiException ex)
        {
            return ConvertApiException(ex);
        }
    }

    public async Task<Response<int>> CreateLoan(CreateLoanVM loan)
    {
        try
        {
            var response = new Response<int>();
            var createLoanDto = mapper.Map<CreateLoanDto>(loan);
            var apiResponse = await _client.LoanPOSTAsync(createLoanDto);

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

    public async Task<Response<int>> DeleteLoan(int id)
    {
        try
        {
            await _client.LoanDELETEAsync(id);
            return new Response<int>() { Successs = true, Message = "Deleted successfully" };
        }
        catch (ApiException e)
        {
            return ConvertApiException(e);
        }
    }
}