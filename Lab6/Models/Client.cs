namespace Lab6.Models;

public partial class Client : IModel
{
    public int Id { get; set; }
    public string Firstname { get; set; } 
    public string Surname { get; set; } 
    public string Patronymic { get; set; } 
    public string Phone { get; set; } 
    public int AddressId { get; set; }

    public Address Address { get; set; }
    public ICollection<Order> Orders { get; set; }
}
