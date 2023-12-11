namespace Library.Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{
    public IAuthorRepository AuthorRepository { get; }

    public IBookRepository BookRepository { get;}

    public ICustomerRepository CustomerRepository { get; }

    public IFinePaymentRepository FinePaymentRepository { get; }

    public ILoanRepository LoanRepository { get; }

    public IPublisherRepository PublisherRepository { get; }

    public IReservationRepository ReservationRepository { get; }

    public IReviewRepository ReviewRepository { get; }

    public IShelfRepository ShelfRepository { get;  }

    public IStaffRepository StaffRepository { get; }

    Task<int> SaveAsync();
}