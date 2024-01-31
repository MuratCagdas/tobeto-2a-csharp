

using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.CorporateCustomer;
using Business.Responses.CorporateCustomer;
using DataAccess.Abstract;

namespace Business.Concrete;

public class CorporateCustomerManager : ICorporateCustomerService
{
    private readonly ICorporateCustomerDal _corpCustDal;
    private readonly CorpCustBusinessRules _CorpCustBusinessRules;
    private readonly IMapper _mapper;

    public CorporateCustomerManager(ICorporateCustomerDal corpCustDal, CorpCustBusinessRules corpCustBusinessRules, IMapper mapper)
    {
        _corpCustDal = corpCustDal;
        _CorpCustBusinessRules = corpCustBusinessRules;
        _mapper = mapper;
    }
    public AddCorpCustResponse Add(AddCorpCustRequest request)
    {
        throw new NotImplementedException();
    }

    public DeleteCorpCustResponse Delete(DeleteCorpCustRequest request)
    {
        throw new NotImplementedException();
    }

    public GetByIdCorpCustResponse GetById(GetCorpCustByIdRequest id)
    {
        throw new NotImplementedException();
    }

    public GetCorpCustListResponse GetList(GetCorpCustListRequest request)
    {
        throw new NotImplementedException();
    }

    public UpdateCorpCustResponse Update(UpdateCorpCustRequest request)
    {
        throw new NotImplementedException();
    }
}
