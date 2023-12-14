using AutoMapper;
using Library.MVC.Contracts;
using Library.MVC.Models.Reservation;
using Library.MVC.Services.Base;

namespace Library.MVC.Services;

public class ReservationService(ILocalStorageService localStorage, IClient client, IMapper mapper) :
    BaseHttpService(localStorage, client), IReservationService
{
    public async Task<List<ReservationListVM>> GetReservations()
    {
        var reservationDto = await _client.ReservationAllAsync();
        return mapper.Map<List<ReservationListVM>>(reservationDto);
    }

    public async Task<List<ReservationListVM>> GetReservationsByDate(DateTime date)
    {
        var reservationDto = await _client.ReservDateAsync(date);
        return mapper.Map<List<ReservationListVM>>(reservationDto);
    }

    public async Task<List<ReservationListVM>> GetReservationsByDueDate(DateTime date)
    {
        var reservationDto = await _client.DueDate2Async(date);
        return mapper.Map<List<ReservationListVM>>(reservationDto);
    }

    public async Task<List<ReservationListVM>> GetReservationsByBookTitle(string title)
    {
        var reservationDto = await _client.BookTitle2Async(title);
        return mapper.Map<List<ReservationListVM>>(reservationDto);
    }

    public async Task<List<ReservationListVM>> GetReservationsByCustomerPhone(string phone)
    {
        var reservationDto = await _client.CustPhone3Async(phone);
        return mapper.Map<List<ReservationListVM>>(reservationDto);
    }

    public async Task<List<ReservationListVM>> GetReservationsByStatus(string status)
    {
        var reservationDto = await _client.StatusAsync(status);
        return mapper.Map<List<ReservationListVM>>(reservationDto);
    }

    public async Task<ReservationVM> GetReservation(int id)
    {
        var reservationDto = await _client.ReservationGETAsync(id);
        return mapper.Map<ReservationVM>(reservationDto);
    }

    public async Task<Response<int>> UpdateReservation(UpdateReservationVM reservation)
    {
        try
        {
            var reservationDto = mapper.Map<UpdateReservationDto>(reservation);
            var response = await _client.ReservationPUTAsync(reservationDto);
            return new Response<int>()
                { Successs = response.Success, Data = reservationDto.Id, Message = response.Message,ValidationErrors = FlattErrors(response.Errors) };
        }
        catch (ApiException ex)
        {
            return ConvertApiException(ex);
        }
    }

    public async Task<Response<int>> CreateReservation(CreateReservationVM reservation)
    {
        try
        {
            var response = new Response<int>();
            var createReservationDto = mapper.Map<CreateReservationDto>(reservation);
            var apiResponse = await _client.ReservationPOSTAsync(createReservationDto);

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

    public async Task<Response<int>> DeleteReservation(int id)
    {
        try
        {
            await _client.ReservationDELETEAsync(id);
            return new Response<int>() { Successs = true, Message = "Deleted successfully" };
        }
        catch (ApiException e)
        {
            return ConvertApiException(e);
        }
    }
}