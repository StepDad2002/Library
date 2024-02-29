using Library.Application.Contracts.Persistence;
using Moq;

namespace LibraryTESTS.Mocks;

public class MockUnitOfWork
{
    public static Mock<IUnitOfWork> GetUnitOfWork()
    {
        var mockUow = new Mock<IUnitOfWork>();

        mockUow.Setup(r => r.CustomerRepository).Returns(MockCustomerRepository.GetCustomerRepository().Object);
        mockUow.Setup(r => r.StaffRepository).Returns(MockStaffRepository.GetStaffRepository().Object);

        return mockUow;
    }
}