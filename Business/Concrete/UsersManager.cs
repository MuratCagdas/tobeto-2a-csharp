
using Core.Utilities.Security.Hashing;
using AutoMapper;
using Business.Abstract;
using Business.Requests.Users;
using Core.Utilities.Security.JWT;
using Core.Entities;
using DataAccess.Abstract;
using Business.BusinessRules;
namespace Business.Concrete;

public class UsersManager : IUsersService
{
    private readonly IUsersDal _userDal;
    private readonly ITokenHelper _tokenHelper;
    private readonly UsersBusinessRules _usersBusinessRules;
    public UsersManager(IUsersDal userDal, ITokenHelper tokenHelper, UsersBusinessRules usersBusinessRules)
    {
        _userDal = userDal;
        _tokenHelper = tokenHelper;
        _usersBusinessRules = usersBusinessRules;
    }

    public AccessToken Login(LoginRequest request)
    {
        User? user = _userDal.Get(i => i.Email == request.Email);
        ICollection<Role> roles = _usersBusinessRules.Roles(user);
        // Business Rules...

        bool isPasswordCorrect = HashingHelper.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt);

        if (!isPasswordCorrect)
            throw new Exception("Şifre yanlış.");
        return _tokenHelper.CreateToken(user/*,roles*/);
    }

    public void Register(RegisterRequest request)
    {
        byte[] passwordSalt, passwordHash;
        HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

        // TODO: Auto-Mapping
        User user = new User();
        user.Email = request.Email;
        user.Approved = false;
        user.PasswordSalt = passwordSalt;
        user.PasswordHash = passwordHash;

        _userDal.Add(user);
    }
}
