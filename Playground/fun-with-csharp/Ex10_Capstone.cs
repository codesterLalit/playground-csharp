namespace Play.fun;

public interface IPayable
{
    decimal Amount {get;}
    string Describe();
}

public abstract record PaymentMethod;
public sealed record CreditCard(string last4, decimal Amount): PaymentMethod, IPayable
{
    public string Describe()
    {
        return $"Credit card ending in {last4}: ${Amount}";
    }
}

public sealed record BankTransfer(string Iban, decimal Amount): PaymentMethod, IPayable
{
    public string Describe()
    {
        return $"Bank trasnfer amount with Iban {Iban}: {Amount}";
    }
}

public sealed record CashOnDelivery(decimal Amount): PaymentMethod, IPayable
{
    public string Describe()
    {
        return $"Cash on delivery amount: {Amount}";
    }
}

public static class Ex10_Capstone
{
    public static decimal CaclulateProcessingFee(IPayable method)
    {
        decimal result = method switch
        {
          CreditCard c => c.Amount * 0.025m,
          BankTransfer bt =>  1,
          CashOnDelivery cd => 0,
        _ => throw new ArgumentOutOfRangeException(nameof(method))
        };
        return result;
    }
    public static void Run()
    {
        List<IPayable> payables = new() {new BankTransfer("12323dd", 32), new CreditCard("lded", 320)};
        
        foreach(var payable in payables)
        {
            Console.WriteLine(payable.Describe());
            decimal processingFee = CaclulateProcessingFee(payable);
            Console.Write($"Total amount: {processingFee + payable.Amount}");
        }
    }
}