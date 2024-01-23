
namespace Core.CrossCuttingConcers.Exceptions;

public class BusinessException :Exception 
{
    public BusinessException(string massage) : base(massage)
    {
        
    }
}
