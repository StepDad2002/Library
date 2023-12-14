using Library.MVC.Contracts;
using Library.MVC.Models;
using Library.MVC.Models.Review;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Library.MVC.Controllers;

public class ReviewController(IReviewService reviewService) : Controller
{
    
    
    [HttpPost]
    public async Task<IActionResult>  Create(CreateReviewVM review)
    {
        try
        {
            var response = await reviewService.CreateReview(review);
            if (response.Successs)
            {
                return RedirectToAction("Details", "Book", new {id = review.BookId});
            }
            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return RedirectToAction("Details", "Book", new {id = review.BookId});
    }

    public async Task<IActionResult> Edit(int id)
    {
        var review = await reviewService.GetReview(id);
        return View(review);
    }
    
    
    [HttpPost]
    public async Task<IActionResult>  Edit(UpdateReviewVM reviewToUpdate, int customerId)
    {
        try
        {
            var response = await reviewService.UpdateReview(reviewToUpdate);
            if (response.Successs)
            {
                return RedirectToAction("Reviews", "Customer", new {customerId});
            }
            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }
        
        return RedirectToAction("Reviews", "Customer", new {customerId});
    }
    
    [HttpPost]
    public async Task<IActionResult>  EditFromManagement(UpdateReviewVM reviewToUpdate)
    {
        try
        {
            var response = await reviewService.UpdateReview(reviewToUpdate);
            if (response.Successs)
            {
                return RedirectToAction(nameof(Manage));
            }
            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }
        
        return View("Edit",reviewToUpdate);
    }
    
    [HttpGet]
    public async Task<IActionResult> Manage()
    {
        var reviews = await reviewService.GetReviews();
        return View(reviews);
    }
    
    public async Task<IActionResult> Search(ReviewSearchOptionsVM review)
    {
        List<ReviewVM> reviews = new();
        if (review.ReviewDate.HasValue)
        {
            reviews.AddRange(await reviewService.GetReviewsByDate(review.ReviewDate.Value));
        }

        if (!string.IsNullOrWhiteSpace(review.BookTitle))
        {
            reviews.AddRange(await reviewService.GetReviewsByBookTitle(review.BookTitle));
        }      
        
        if (!string.IsNullOrWhiteSpace(review.CustomerPhone))
        {
            reviews.AddRange(await reviewService.GetReviewsByCustomerPhone(review.CustomerPhone));
        }

        if (review.MinRating > 0 && review.MaxRating > 0)
        {
            reviews.AddRange(await reviewService.GetReviewsByRating(review.MinRating, review.MaxRating));
        }
        
        if (review.MinRating > 0 && review.MaxRating == 0)
        {
            reviews.AddRange(await reviewService.GetReviewsByRating(review.MinRating, 10));
        }

        if (reviews.Count == 0)
            return RedirectToAction("Manage");
        return View("Manage", reviews.DistinctBy(x => x.Id));
    }

    public async Task<IActionResult> Delete(int id, int? userId)
    {
        try
        {
            var response = await reviewService.DeleteReview(id);

            if (response.Successs)
                return RedirectToAction("Reviews", "Customer" ,new{ customerId = userId});
            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return RedirectToAction("Reviews", "Customer" ,new{ customerId = userId});
    }
    
    public async Task<IActionResult> DeleteFromManagement(int id)
    {
        try
        {
            var response = await reviewService.DeleteReview(id);

            if (response.Successs)
                return RedirectToAction(nameof(Manage));
            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return RedirectToAction(nameof(Manage));
    }
}