namespace WebApi.Models;

public class Employee
{
    public int Id { get; set; }
    public required  string FirstName { get; set; }
    public required string LastName { get; set; }
    public int  Age { get; set; }
    public required string Position { get; set; }
    public required string Address { get; set; }
    public required string Email { get; set; }
    public int CompanyId { get; set; }
    public int DepartmentId { get; set; }
}