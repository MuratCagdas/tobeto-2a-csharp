

using Core.CrossCuttingConcers.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;

namespace Business.BusinessRules;

public class ModelBusinessRules
{
    private readonly IModelDal _modelDal;

    public ModelBusinessRules(IModelDal modelDal)
    {
        _modelDal = modelDal;
    }

    public void CheckIfModelNameExists(string name)
    {
        bool isNameExists = _modelDal.Get(m => m.Name == name) != null;
        if (isNameExists)
            throw new BusinessException("Model name already exists.");
    }
}
