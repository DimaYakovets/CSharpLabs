namespace Lab6.Models;

public partial class Order : IModel
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int ClientId { get; set; }

    public Client Client { get; set; }
    public ICollection<OrderPart> OrderParts { get; set; }
}
