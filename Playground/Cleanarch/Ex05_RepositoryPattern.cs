using Microsoft.Extensions.DependencyInjection;

namespace Play.cleanarch;

public record Customer(int Id, string Name, string Email);

public interface ICustomerRepository
{
    public void Add(Customer customer);
    public Customer GetById(int id);
    public IEnumerable<Customer> GetAll();
}

public class InMemoryCustomerRepository: ICustomerRepository
{
    private readonly List<Customer> _customers =[];

    public void Add(Customer customer)
    {
        _customers.Add(customer);
    }

    public Customer GetById(int id)
    {
        return _customers.FirstOrDefault(c => c.Id == id);
    }

    public IEnumerable<Customer> GetAll()
    {
        return _customers;
    }
}

public class CustomerService
{
    private ICustomerRepository _customerRepository;
    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public void RegisterCustomer(string name, string email)
    {
        // Random random = new Random();
        // int number = random.Next(1, 9999);
        var person = new Customer(20, name, email);
        _customerRepository.Add(person);
    }

    public Customer FindCustomer(int id)
    {
       var customer =  _customerRepository.GetById(id);
       return customer;
    }
}

public static class Ex05_RepositoryPattern
{
    public static void Run()
    {
        var services = new ServiceCollection();

        services.AddSingleton<ICustomerRepository, InMemoryCustomerRepository>();
        services.AddSingleton<CustomerService>();
        
        using var provider = services.BuildServiceProvider();
        var customerService = provider.GetRequiredService<CustomerService>();

        customerService.RegisterCustomer("Lalit ", "laalit.sunaar@gmail.com");
        var customer = customerService.FindCustomer(20);
        Console.WriteLine($"Custom: {customer.Name}");
    }
}