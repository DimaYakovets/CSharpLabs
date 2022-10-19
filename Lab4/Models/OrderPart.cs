namespace Lab4.Models;

public partial class OrderPart : IModel
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int PizzaId { get; set; }
    public double Discount { get; set; }
    public int Count { get; set; }

    public Order Order { get; set; } = null!;
    public Pizza Pizza { get; set; } = null!;
}
