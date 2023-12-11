using AutoMapper;
using Library.MVC.Models;
using Library.MVC.Models.Book;
using Library.MVC.Services.Base;

namespace Library.MVC.Mapping_Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<BookDto, BookVM>().ReverseMap();
        CreateMap<BookDto, BookDetailedVM>().ReverseMap();
        CreateMap<BookDtoNoReferences, BookNoReferencesVM>()
            .ReverseMap();
        CreateMap<BookListDto, BookListVM>().ReverseMap();
        CreateMap<BookLoansDto, BookLoansVM>().ReverseMap();
        CreateMap<BookReviewsDto, BookReviewsVM>().ReverseMap();
        CreateMap<UpdateBookDto, UpdateBookVM>().ReverseMap();
        CreateMap<CreateBookDto, CreateBookVM>().ReverseMap();
    }
}