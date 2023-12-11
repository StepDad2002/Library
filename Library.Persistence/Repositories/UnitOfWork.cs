using Library.Application.Contracts.Persistence;

// ReSharper disable NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract

namespace Library.Persistance.Repositories;

public class UnitOfWork(LibraryDbContext context) : IUnitOfWork
{
    private readonly LibraryDbContext _context = context;

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    private IAuthorRepository _authorRepository;

    public IAuthorRepository AuthorRepository
    {
        get => _authorRepository ?? new AuthorRepository(_context);
    }

    private IBookRepository _bookRepository;

    public IBookRepository BookRepository
    {
        get => _bookRepository ?? new BookRepository(_context);
    }

    private ICustomerRepository _customerRepository;

    public ICustomerRepository CustomerRepository
    {
        get => _customerRepository ?? new CustomerRepository(_context);
    }

    private IFinePaymentRepository _finePaymentRepository;

    public IFinePaymentRepository FinePaymentRepository
    {
        get => _finePaymentRepository ?? new FinePaymentRepository(_context);
    }

    private ILoanRepository _loanRepository;

    public ILoanRepository LoanRepository
    {
        get => _loanRepository ?? new LoanRepository(_context);
    }

    private IPublisherRepository _publisherRepository;

    public IPublisherRepository PublisherRepository
    {
        get => _publisherRepository ?? new PublisherRepository(_context);
    }

    private IReservationRepository _reservationRepository;

    public IReservationRepository ReservationRepository
    {
        get => _reservationRepository ?? new ReservationRepository(_context);
    }

    private IReviewRepository _reviewRepository;

    public IReviewRepository ReviewRepository
    {
        get => _reviewRepository ?? new ReviewRepository(_context);
    }

    private IShelfRepository _shelfRepository;

    public IShelfRepository ShelfRepository
    {
        get => _shelfRepository ?? new ShelfRepository(_context);
    }

    private IStaffRepository _staffRepository;

    public IStaffRepository StaffRepository
    {
        get => _staffRepository ?? new StaffRepository(_context);
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}