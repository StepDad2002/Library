using AutoMapper;
using Library.MVC.Contracts;
using Library.MVC.Models;
using Library.MVC.Models.Staff;
using Library.MVC.Services.Base;

namespace Library.MVC.Services;

public class StaffService(ILocalStorageService localStorage, IClient client, IMapper mapper) :
    BaseHttpService(localStorage, client), IStaffService
{
    public async Task<List<StaffListVM>> GetStaffs()
    {
        var staffDtos = await _client.StaffAllAsync();
        return mapper.Map<List<StaffListVM>>(staffDtos);
    }

    public async Task<StaffVM> GetStaff(int id)
    {
        var staffDto = await _client.StaffGETAsync(id);
        return mapper.Map<StaffVM>(staffDto);
    }

    public async Task<Response<int>> UpdateStaff(UpdateStaffVM staff)
    {
        try
        {
            var staffDto = mapper.Map<UpdateStaffDto>(staff);
            var response = await _client.StaffPUTAsync(staffDto);
            return new Response<int>()
                { Successs = response.Success, Data = staffDto.Id, Message = response.Message,ValidationErrors = FlattErrors(response.Errors) };
        }
        catch (ApiException ex)
        {
            return ConvertApiException(ex);
        }
    }

    public async Task<Response<int>> CreateStaff(CreateStaffVM staff)
    {
        try
        {
            var response = new Response<int>();
            var createStaffDto = mapper.Map<CreateStaffDto>(staff);
            var apiResponse = await _client.StaffPOSTAsync(createStaffDto);

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

    public async Task<Response<int>> DeleteStaff(int id)
    {
        try
        {
            await _client.StaffDELETEAsync(id);
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
            var loginResponse = await _client.LogStfAsync(log);
            return new Response<int>() { Successs = loginResponse.Success, Message = loginResponse.Message, Data = loginResponse.Id};
        }
        catch (ApiException e)
        {
            return ConvertApiException(e);
        }
    }
}