

using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Customers;
using Business.Responses.Customers;
using DataAccess.Abstract;

namespace Business.Concrete;

public class CustomersManager : ICustomersService
{
    private readonly ICustomersDal _customersDal;
    private readonly CustomersBusinessRules _customersBusinessRules;
    private readonly IMapper _mapper;

    public CustomersManager(ICustomersDal customersDal, CustomersBusinessRules customersBusinessRules, IMapper mapper)
    {
        _customersDal = customersDal;
        _customersBusinessRules = customersBusinessRules;
        _mapper = mapper;
    }
    public AddCustomersResponse Add(AddCustomersRequest request)
    {
        throw new NotImplementedException();
    }

    public DeleteCustomersResponse Delete(DeleteCustomersRequest request)
    {
        throw new NotImplementedException();
    }

    public GetByIdCustomersResponse GetById(GetCustomersByIdRequest id)
    {
        throw new NotImplementedException();
    }

    public GetCustomersListResponse GetList(GetCustomersListRequest request)
    {
        throw new NotImplementedException();
    }

    public UpdateCustomersResponse Update(UpdateCustomersRequest request)
    {
        throw new NotImplementedException();
    }
}
