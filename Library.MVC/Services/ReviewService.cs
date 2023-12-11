using AutoMapper;
using Library.MVC.Contracts;
using Library.MVC.Models.Review;
using Library.MVC.Services.Base;

namespace Library.MVC.Services;

public class ReviewService(ILocalStorageService localStorage, IClient client, IMapper mapper) :
    BaseHttpService(localStorage, client), IReviewService
{
    public async Task<List<ReviewVM>> GetReviews()
    {
        var reviewDtos = await _client.ReviewAllAsync();
        return mapper.Map<List<ReviewVM>>(reviewDtos);
    }

    public async Task<ReviewVM> GetReview(int id)
    {
        var reviewDto = await _client.ReviewGETAsync(id);
        return mapper.Map<ReviewVM>(reviewDto);
    }

    public async Task<Response<int>> UpdateReview(UpdateReviewVM review)
    {
        try
        {
            var reviewDto = mapper.Map<UpdateReviewDto>(review);
            var response = await _client.ReviewPUTAsync(reviewDto);
            return new Response<int>()
                { Successs = response.Success, Data = reviewDto.Id, Message = response.Message,ValidationErrors = FlattErrors(response.Errors) };
        }
        catch (ApiException ex)
        {
            return ConvertApiException(ex);
        }
    }

    public async Task<Response<int>> CreateReview(CreateReviewVM review)
    {
        try
        {
            var response = new Response<int>();
            var createReviewDto = mapper.Map<CreateReviewDto>(review);
            var apiResponse = await _client.ReviewPOSTAsync(createReviewDto);

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

    public async Task<Response<int>> DeleteReview(int id)
    {
        try
        {
            await _client.ReviewDELETEAsync(id);
            return new Response<int>() { Successs = true, Message = "Deleted successfully" };
        }
        catch (ApiException e)
        {
            return ConvertApiException(e);
        }
    }
}