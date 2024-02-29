using Library.Application.Contracts.Persistence;
using Library.Domain.Entities.Schemas.Management;
using Moq;
using Range = Moq.Range;

namespace LibraryTESTS.Mocks;

public class MockCustomerRepository
{
    public static Mock<ICustomerRepository> GetCustomerRepository()
    {
        var customers = new List<Customer>()
        {
            new Customer()
            {
                FName = "Misha",
                CreatedBy = "ADMIN",
                CreatedDate = DateTime.Now,
                Email = "misha@email.com",
                Id = 1,
                LName = "Chernysh",
                ModifiedBy = "ADMIN",
                ModifiedDate = DateTime.Now,
                Password = "111111",
                Phone = "111-111-11-11"
            },
            new Customer()
            {
                FName = "Yasha",
                CreatedBy = "ADMIN",
                CreatedDate = DateTime.Now,
                Email = "yasha@email.com",
                Id = 2,
                LName = "Kiakra",
                ModifiedBy = "ADMIN",
                ModifiedDate = DateTime.Now,
                Password = "222222",
                Phone = "222-222-22-22"
            },
            new Customer()
            {
                FName = "Lolka",
                CreatedBy = "ADMIN",
                CreatedDate = DateTime.Now,
                Email = "lolka@email.com",
                Id = 3,
                LName = "Polka",
                ModifiedBy = "ADMIN",
                ModifiedDate = DateTime.Now,
                Password = "333333",
                Phone = "333-333-33-33"
            },
            new Customer()
            {
                FName = "Tumba",
                CreatedBy = "ADMIN",
                CreatedDate = DateTime.Now,
                Email = "tumba@email.com",
                Id = 4,
                LName = "Stolovich",
                ModifiedBy = "ADMIN",
                ModifiedDate = DateTime.Now,
                Password = "444444",
                Phone = "444-444-44-44"
            },
            new Customer()
            {
                FName = "Poduska",
                CreatedBy = "ADMIN",
                CreatedDate = DateTime.Now,
                Email = "podushka@email.com",
                Id = 5,
                LName = "krovatovna",
                ModifiedBy = "ADMIN",
                ModifiedDate = DateTime.Now,
                Password = "555555",
                Phone = "555-555-55-55"
            }
        };
        
        var mockRepo = new Mock<ICustomerRepository>();

        mockRepo.Setup(r => r.GetAllAsync())
            .ReturnsAsync(customers);

        mockRepo.Setup(r => r.GetAsync(It.IsAny<int>()))
            .ReturnsAsync((int id) =>
            {
                if (id < 0 || id > customers.Count)
                    return null;
                return customers[id];
            });

        mockRepo.Setup(x => x.GetByPhoneAsync(It.IsRegex(@"\d{3}-\d{3}-\d{2}-\d{2}")))
            .ReturnsAsync((string phone) => customers.FirstOrDefault(x => x.Phone == phone));

        mockRepo.Setup(r => r.GetByEmailAsync(It.IsRegex(@"^\S+@\S+\.\S+$")))
            .ReturnsAsync((string email) => customers.FirstOrDefault(x => x.Email == email));

        mockRepo.Setup(r => r.ExistEmailAsync(It.IsRegex(@"^\S+@\S+\.\S+$")))
            .ReturnsAsync((string email) => customers.FirstOrDefault(x => x.Email == email) != null);

        mockRepo.Setup(r => r.ExistPasswordAsync(It.IsAny<string>()))
            .ReturnsAsync((string password) => customers.FirstOrDefault(x => x.Password == password) != null);
            
        mockRepo.Setup(r => r.ExistsAsync(It.IsInRange(1,5, Range.Inclusive)))
            .ReturnsAsync((int id) => customers.Exists(x => x.Id == id));

        mockRepo.Setup(r => r.TryLogInAsync(It.IsRegex(@"^\S+@\S+\.\S+$"), It.IsAny<string>()))
            .ReturnsAsync((string email, string password) =>
            {
                var cust = customers.FirstOrDefault(x => x.Email == email && x.Password == password);
                if (cust == null)
                    return -1;
                return cust.Id;
            });

        mockRepo.Setup(r => r.AddAsync(It.IsAny<Customer>()))
            .ReturnsAsync((Customer customer) =>
            {
                customers.Add(customer);
                return customer;
            });
        
        mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Customer>()))
            .Returns(async (Customer customer) =>
            {
                if(customers.Find(x => x.Id == customer.Id) != null)
                    customers[customer.Id] = customer;
            });
        mockRepo.Setup(r => r.DeleteAsync(It.IsAny<Customer>()))
            .Returns(async (Customer customer) =>
            {
                if(customers.Find(x => x.Id == customer.Id) != null)
                    customers.RemoveAt(customer.Id);
            });
        
        return mockRepo;
    }
}

public class MockStaffRepository
{
    public static Mock<IStaffRepository> GetStaffRepository()
    {
        var staffs = new List<Staff>()
        {
            new()
            {
                FName = "Kolya",
                CreatedBy = "ADMIN",
                CreatedDate = DateTime.Now,
                Email = "kolya@email.com",
                Id = 1,
                LName = "Kolyan",
                ModifiedBy = "ADMIN",
                ModifiedDate = DateTime.Now,
                Password = "111111",
                Phone = "121-121-12-12"
            },
            new()
            {
                FName = "Pavel",
                CreatedBy = "ADMIN",
                CreatedDate = DateTime.Now,
                Email = "pavel@email.com",
                Id = 2,
                LName = "Pavlenko",
                ModifiedBy = "ADMIN",
                ModifiedDate = DateTime.Now,
                Password = "222222",
                Phone = "131-131-13-13"
            },
            new()
            {
                FName = "Jeka",
                CreatedBy = "ADMIN",
                CreatedDate = DateTime.Now,
                Email = "jeka@email.com",
                Id = 3,
                LName = "Jekovich",
                ModifiedBy = "ADMIN",
                ModifiedDate = DateTime.Now,
                Password = "333333",
                Phone = "141-141-14-14"
            },
            new()
            {
                FName = "Luba",
                CreatedBy = "ADMIN",
                CreatedDate = DateTime.Now,
                Email = "luba@email.com",
                Id = 4,
                LName = "Lubovna",
                ModifiedBy = "ADMIN",
                ModifiedDate = DateTime.Now,
                Password = "444444",
                Phone = "151-151-15-15"
            },
            new()
            {
                FName = "Olga",
                CreatedBy = "ADMIN",
                CreatedDate = DateTime.Now,
                Email = "olga@email.com",
                Id = 5,
                LName = "Olgovna",
                ModifiedBy = "ADMIN",
                ModifiedDate = DateTime.Now,
                Password = "555555",
                Phone = "161-161-16-16"
            }
        };
        
        var mockRepo = new Mock<IStaffRepository>();

        mockRepo.Setup(r => r.GetAllAsync())
            .ReturnsAsync(staffs);

        mockRepo.Setup(r => r.GetAsync(It.IsAny<int>()))
            .ReturnsAsync((int id) =>
            {
                if (id < 0 || id > staffs.Count)
                    return null;
                return staffs[id];
            });

        mockRepo.Setup(x => x.GetByPhoneAsync(It.IsRegex(@"\d{3}-\d{3}-\d{2}-\d{2}")))
            .ReturnsAsync((string phone) => staffs.FirstOrDefault(x => x.Phone == phone));

        mockRepo.Setup(r => r.GetByEmailAsync(It.IsRegex(@"^\S+@\S+\.\S+$")))
            .ReturnsAsync((string email) => staffs.FirstOrDefault(x => x.Email == email));

        mockRepo.Setup(r => r.ExistsEmailAsync(It.IsRegex(@"^\S+@\S+\.\S+$")))
            .ReturnsAsync((string email) => staffs.FirstOrDefault(x => x.Email == email) != null);

        mockRepo.Setup(r => r.ExistPasswordAsync(It.IsAny<string>()))
            .ReturnsAsync((string password) => staffs.FirstOrDefault(x => x.Password == password) != null);
            
        mockRepo.Setup(r => r.ExistsAsync(It.IsInRange(1,5, Range.Inclusive)))
            .ReturnsAsync((int id) => staffs.Exists(x => x.Id == id));

        mockRepo.Setup(r => r.TryLogInAsync(It.IsRegex(@"^\S+@\S+\.\S+$"), It.IsAny<string>()))
            .ReturnsAsync((string email, string password) =>
            {
                var cust = staffs.FirstOrDefault(x => x.Email == email && x.Password == password);
                if (cust == null)
                    return -1;
                return cust.Id;
            });

        mockRepo.Setup(r => r.AddAsync(It.IsAny<Staff>()))
            .ReturnsAsync((Staff staff) =>
            {
                staffs.Add(staff);
                return staff;
            });

        mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Staff>()));
        mockRepo.Setup(r => r.DeleteAsync(It.IsAny<Staff>()));
        
        
        
        return mockRepo;
    }
}