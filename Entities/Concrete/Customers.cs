
using Core.Entities;

namespace Entities.Concrete;

public class Customers : Entity<int>
{
    public Customers(int userId, int customersId)
    {
        UserId = userId;
        CustomersId = customersId;
    }
    public Customers()
    {

    }
    public int UserId { get; set; }
    public int CustomersId { get; set; }
}
