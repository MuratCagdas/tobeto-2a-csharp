

namespace Core.Entities;

public class Role : Entity<int>
{
    public string RoleName { get; set; }
    public ICollection<UserRole> Users{ get; set; }
}
