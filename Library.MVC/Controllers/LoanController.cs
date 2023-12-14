using Library.MVC.Contracts;
using Library.MVC.Models;
using Library.MVC.Models.FinePayment;
using Library.MVC.Models.Loan;
using Microsoft.AspNetCore.Mvc;

namespace Library.MVC.Controllers;

public class LoanController(ILoanService loanService, ICustomerService customerService, IBookService bookService)
    : Controller
{
    // GET
    public IActionResult Index()
    {
        return Ok();
    }

    public async Task<IActionResult> Manage()
    {
        var loans = await loanService.GetLoans();
        return View(loans);
    }
    
    public async Task<IActionResult> Search(LoanSearchOptionsVM loan)
    {
        var loans = new List<LoanListVM>();

        if (loan.DueDate.HasValue)
        {
            loans.AddRange(await loanService.GetLoansByDueDate(loan.DueDate.Value));
        }
        
        if (loan.ReturnedDate.HasValue)
        {
            loans.AddRange(await loanService.GetLoansByReturnedDate(loan.ReturnedDate.Value));
        }
        
        if (loan.LoanDate.HasValue)
        {
            loans.AddRange(await loanService.GetLoansByLoanDate(loan.LoanDate.Value));
        }

        if (!string.IsNullOrWhiteSpace(loan.BookTitle))
        {
            loans.AddRange(await loanService.GetLoansByBookTitle(loan.BookTitle));
        }
        
        if (!string.IsNullOrWhiteSpace(loan.CustomerPhone))
        {
            loans.AddRange(await loanService.GetLoansByCustomerPhone(loan.CustomerPhone));
        }
        
        if (loans.Count == 0)
            return RedirectToAction(nameof(Manage));

        return View(nameof(Manage), loans.DistinctBy(x => x.Id));
    }

    public async Task<IActionResult> Delete(int id, string returnUrl)
    {
        try
        {
            var response = await loanService.DeleteLoan(id);

            if (response.Successs)
                return LocalRedirect(returnUrl);
            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return BadRequest($"The requested loan was not founded [{id}]");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var loan = await loanService.GetLoan(id);
        return View(loan);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UpdateLoanVM loan)
    {
        try
        {
            var response = await loanService.UpdateLoan(loan);

            if (response.Successs)
                return RedirectToAction(nameof(Manage));
            
            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return View(loan);
    }

    public async Task<IActionResult> Create()
    {
        var customersPnones = (await customerService.GetCustomers()).Select(x => new { x.Id, x.Phone });
        var booksIsbns = (await bookService.GetBooks()).Select(x => new { x.Id, x.Isbn });
        ViewBag.CustomersPhones = customersPnones;
        ViewBag.BooksIsbn = booksIsbns;
        
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateLoanVM loan)
    {
        try
        {
            var response = await loanService.CreateLoan(loan);

            if (response.Successs)
                return RedirectToAction(nameof(Manage));
            
            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }
        var customersPnones = (await customerService.GetCustomers()).Select(x => new { x.Id, x.Phone });
        var booksIsbns = (await bookService.GetBooks()).Select(x => new { x.Id, x.Isbn });
        ViewBag.CustomersPhones = customersPnones;
        ViewBag.BooksIsbn = booksIsbns;
        return View(loan);
    }
}