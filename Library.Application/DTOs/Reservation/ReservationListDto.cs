﻿using Library.Application.DTOs.Book;
using Library.Application.DTOs.Common;
using Library.Application.DTOs.Customer;

namespace Library.Application.DTOs.Reservation;

public class ReservationListDto : BaseDto
{
    public CustomerListDto Customer { get; set; }

    public BookDtoNoReferences Book { get; set; }

    public int Amount { get; set; }
    
    public string Status { get; set; }
    
    public DateTime ReservationDate { get; set; }
    public DateTime DueDate { get; set; }
}