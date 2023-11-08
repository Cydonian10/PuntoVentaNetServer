using System.Text.Json.Serialization;

namespace ApiStore.Data;

public class Product
{
    public Guid Id { set; get; }
    public Guid CategoryId { set; get; }
    public string Name { set; get; } = string.Empty;
    public decimal Price { set; get; }
    public decimal Stock { set; get; }
    public string Description { set; get; } = string.Empty;
    public string Image { set; get; } = string.Empty;
    public int Igv { get; set; }
    public DateTime FechaCreacion { set; get; }
    public UnitMeasurement UnitMeasurement { set; get; }
    public virtual Category Category { set; get; } = new Category();

    [JsonIgnore]
    public virtual ICollection<Provider> Providers { set; get; } = new List<Provider>();

    [JsonIgnore]
    public virtual ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    [JsonIgnore]
    public virtual ICollection<ShoppingItem> ShoppingItems { get; set; } = new List<ShoppingItem>();


}
