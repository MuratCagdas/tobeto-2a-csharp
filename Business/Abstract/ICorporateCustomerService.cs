
using Business.Requests.CorporateCustomer;
using Business.Responses.CorporateCustomer;

namespace Business.Abstract;

public interface ICorporateCustomerService
{
    public AddCorpCustResponse Add(AddCorpCustRequest request);
    public GetCorpCustListResponse GetList(GetCorpCustListRequest request);
    public GetByIdCorpCustResponse GetById(GetCorpCustByIdRequest id);
    public DeleteCorpCustResponse Delete(DeleteCorpCustRequest request);
    public UpdateCorpCustResponse Update(UpdateCorpCustRequest request);
}
