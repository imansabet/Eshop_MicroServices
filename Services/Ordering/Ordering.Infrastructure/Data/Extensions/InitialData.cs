namespace Ordering.Infrastructure.Data.Extensions;

internal class InitialData
{
    public static IEnumerable<Customer> Customers =>
       new List<Customer>
       {
            Customer.Create(CustomerId.Of(new Guid("e06d1511-8044-4e4e-be6b-102e4e6e44a7")),"iman","dev.imansabet@gmail.com"),
            Customer.Create(CustomerId.Of(new Guid("217ba6e5-c7f5-4037-80b6-15b79fe2ff60")),"john","john@gmail.com")
       };
}
