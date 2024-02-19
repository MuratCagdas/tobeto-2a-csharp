
using Core.Utilities.Security.Hashing;
using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Users;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Business.Responses.Users;
using Core.Entities;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class UsersManager : IUsersService
{
    private readonly IUsersDal _userDal;
    private readonly ITokenHelper _tokenHelper;
    public UsersManager(IUsersDal userDal, ITokenHelper tokenHelper)
    {
        _userDal = userDal;
        _tokenHelper = tokenHelper;
    }

    public AccessToken Login(LoginRequest request)
    {
        user? user = _userDal.Get(i => i.Email == request.Email);
        // Business Rules...

        bool isPasswordCorrect = HashingHelper.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt);

        if (!isPasswordCorrect)
            throw new Exception("Şifre yanlış.");
        return _tokenHelper.CreateToken(user);
    }

    public void Register(RegisterRequest request)
    {
        byte[] passwordSalt, passwordHash;
        HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

        // TODO: Auto-Mapping
        user user = new user();
        user.Email = request.Email;
        user.Approved = false;
        user.PasswordSalt = passwordSalt;
        user.PasswordHash = passwordHash;

        _userDal.Add(user);
    }
}
