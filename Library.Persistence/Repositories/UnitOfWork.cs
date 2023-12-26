using Library.Application.Contracts.Persistence;

// ReSharper disable NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract

namespace Library.Persistance.Repositories;

public class UnitOfWork(LibraryDbContext context) : IUnitOfWork
{
    public void Dispose()
    {
        context.Dispose();
        GC.SuppressFinalize(this);
    }

    private IAuthorRepository _authorRepository;

    public IAuthorRepository AuthorRepository
    {
        get => _authorRepository ?? new AuthorRepository(context);
    }

    private IBookRepository _bookRepository;

    public IBookRepository BookRepository
    {
        get => _bookRepository ?? new BookRepository(context);
    }

    private ICustomerRepository _customerRepository;

    public ICustomerRepository CustomerRepository
    {
        get => _customerRepository ?? new CustomerRepository(context);
    }

    private IFinePaymentRepository _finePaymentRepository;

    public IFinePaymentRepository FinePaymentRepository
    {
        get => _finePaymentRepository ?? new FinePaymentRepository(context);
    }

    private ILoanRepository _loanRepository;

    public ILoanRepository LoanRepository
    {
        get => _loanRepository ?? new LoanRepository(context);
    }

    private IPublisherRepository _publisherRepository;

    public IPublisherRepository PublisherRepository
    {
        get => _publisherRepository ?? new PublisherRepository(context);
    }

    private IReservationRepository _reservationRepository;

    public IReservationRepository ReservationRepository
    {
        get => _reservationRepository ?? new ReservationRepository(context);
    }

    private IReviewRepository _reviewRepository;

    public IReviewRepository ReviewRepository
    {
        get => _reviewRepository ?? new ReviewRepository(context);
    }

    private IShelfRepository _shelfRepository;

    public IShelfRepository ShelfRepository
    {
        get => _shelfRepository ?? new ShelfRepository(context);
    }

    private IStaffRepository _staffRepository;

    public IStaffRepository StaffRepository
    {
        get => _staffRepository ?? new StaffRepository(context);
    }

    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }
}