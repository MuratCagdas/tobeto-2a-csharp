using Core.Entities;

namespace Entities.Concrete;

public class IndividualCustomer : Entity<int>
{
    public IndividualCustomer(string firstName, string lastName, string nationalIdentity, int customersId)
    {
        FirstName = firstName;
        LastName = lastName;
        NationalIdentity = nationalIdentity;
        CustomersId = customersId;
    }
    public IndividualCustomer()
    {

    }
    public int CustomersId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalIdentity { get; set; }
}
