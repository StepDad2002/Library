using Library.Application.DTOs.Customer;
using Library.Application.Features.Customer.Requests.Commands;
using Library.Application.Features.Customer.Requests.Queries;
using Library.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController(IMediator _mediator) : ControllerBase
{

   [HttpGet]
   public async Task<ActionResult<List<CustomerListDto>>> Get()
   {
      var customers = await _mediator.Send(new GetCustomerListRequest());
      return Ok(customers);
   }

   [HttpGet("{id}")]
   public async Task<ActionResult<CustomerDto>> Get(int id)
   {
      var customer = await _mediator.Send(new GetCustomerRequest() {Id = id});
      return Ok(customer);
   }
   
   [HttpGet("search/phone")]
   public async Task<ActionResult<CustomerListDto>> GetByPhone(string phone)
   {
      var response = await _mediator.Send(new GetCustomerByPhoneRequest() { Phone = phone });
      return Ok(response);
   }
    
   [HttpGet("search/email")]
   public async Task<ActionResult<CustomerListDto>> GetByEmail(string email)
   {
      var response = await _mediator.Send(new GetCustomerByEmailRequest() { Email = email });
      return Ok(response);
   }
   
   [HttpGet("/loans")]
   public async Task<ActionResult<CustomerLoansDto>> GetLoans(int id)
   {
      var customer = await _mediator.Send(new GetCustomerLoansRequest() {Id = id});
      return Ok(customer);
   }
   
   [HttpGet("/reservations")]
   public async Task<ActionResult<CustomerReservationsDto>> GetReservations(int id)
   {
      var customer = await _mediator.Send(new GetCustomerReservationsRequest() {Id = id});
      return Ok(customer);
   }
   
   [HttpGet("/fine-payments")]
   public async Task<ActionResult<CustomerFinePaymentsDto>> GetFinePayments(int id)
   {
      var customer = await _mediator.Send(new GetCustomerFinePaymentsRequest() {Id = id});
      return Ok(customer);
   }
   
   [HttpGet("/reviews")]
   public async Task<ActionResult<CustomerReviewsDto>> GetReviews(int id)
   {
      var customer = await _mediator.Send(new GetCustomerReviewsRequest() {Id = id});
      return Ok(customer);
   }

   [HttpPost]
   public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCustomerDto customer)
   {
      var command = new CreateCustomerCommand() { Customer = customer };
      var response = await _mediator.Send(command);
      return Ok(response);
   }
   
   [HttpPut]
   public async Task<ActionResult<UpdateCommandResponse>> Put([FromBody] UpdateCustomerDto customer)
   {
      var command = new UpdateCustomerCommand() { Customer = customer };
      var response = await _mediator.Send(command);
      return Ok(response);
   }
   
   [HttpDelete("{id}")]
   public async Task<ActionResult> Delete(int id)
   {
      var command = new DeleteCustomerCommand() { Id = id };
      await _mediator.Send(command);
      return NoContent();
   }
}