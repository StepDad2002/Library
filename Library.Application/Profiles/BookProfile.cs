using AutoMapper;
using Library.Application.DTOs.Book;
using Library.Domain.Entities.Schemas.BookSchema;

namespace Library.Application.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        
        CreateMap<Book, BookDto>()
            .ReverseMap();
        CreateMap<Book, BookDetailedDto>()
            .ReverseMap();
        CreateMap<Book, BookListDto>()
            .ReverseMap();
        CreateMap<Book, BookLoansDto>()
            .ReverseMap();
        CreateMap<Book, BookReviewsDto>()
            .ReverseMap();
        CreateMap<Book, CreateBookDto>()
            .ReverseMap();
        CreateMap<Book, UpdateBookDto>()
            .ReverseMap();
        CreateMap<Book, BookDtoNoReferences>()
            .ForMember(x => x.AuthorsId, opt => 
                opt.MapFrom(ids => ids.Authors.Select(x => x.Id).ToList()))
            .ReverseMap();
        
    }
}

