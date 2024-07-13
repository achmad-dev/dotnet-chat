#pragma warning disable CA1050 // Declare types in namespaces
public class User
#pragma warning restore CA1050 // Declare types in namespaces
{
    public Guid Id { get; set; }
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
}