﻿
using System.Security.Cryptography;
using System.Text;
namespace Core.Utilities.Security.Hashing;

public class HashingHelper
{
    //Boilerplate code
    public static void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
    {
        using(var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
    public static bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            byte[] computedHash = hmac.ComputeHash (Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (passwordHash[i] != computedHash[i])
                    return false;
            }
            return true;
        }
    }
}
