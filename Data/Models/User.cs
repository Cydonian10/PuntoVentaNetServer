namespace ApiStore.Data;

public class User
{
    public Guid Id { get; set; }
    public Guid RoleId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;
    public Role Role { get; set; } = new Role();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
