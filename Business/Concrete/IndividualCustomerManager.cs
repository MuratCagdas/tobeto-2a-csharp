

using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.IndividualCustomer;
using Business.Responses.IndividualCustomer;
using DataAccess.Abstract;

namespace Business.Concrete;

public class IndividualCustomerManager : IindividualCustomerService
{
    private readonly IindividualCustomerDal _individualCustomerDal;
    private readonly IndvCustBusinessRules _IndvCustBusinessRules;
    private readonly IMapper _mapper;

    public IndividualCustomerManager(IindividualCustomerDal individualCustomerDal, IndvCustBusinessRules indvCustBusinessRules, IMapper mapper)
    {
        _individualCustomerDal = individualCustomerDal;
        _IndvCustBusinessRules = indvCustBusinessRules;
        _mapper = mapper;
    }
    public AddIndCusResponse Add(AddIndvCusRequest request)
    {
        throw new NotImplementedException();
    }

    public DeleteIndCusResponse Delete(DeleteIndvCusRequest request)
    {
        throw new NotImplementedException();
    }

    public GetByIdIndCusResponse GetById(GetIndCustByIdRequest id)
    {
        throw new NotImplementedException();
    }

    public GetIndCusListResponse GetList(GetIndCustListRequest request)
    {
        throw new NotImplementedException();
    }

    public UpdateIndCusResponse Update(UpdateIndCusRequest request)
    {
        throw new NotImplementedException();
    }
}
