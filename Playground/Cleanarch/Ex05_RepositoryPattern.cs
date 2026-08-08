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
    public CustomerService()
    {
        
    }
}