namespace Core.Entities;

public class user :Entity<int>
{
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public bool Approved { get; set; }

    //Genel user fieldları


    // şifre abc123 => Plain Text
    // Hashing  SHA512, MD5 => DWEQWEKQWJEQWJEKQ şifreleme 
    // Salting 

}
