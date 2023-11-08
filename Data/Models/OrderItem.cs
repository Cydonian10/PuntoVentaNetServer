using System.Text.Json.Serialization;

namespace ApiStore.Data
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public UnitMeasurement UnitMeasurement { set; get; }


        [JsonIgnore]        
        public virtual Product Product { get; } = new Product();

        [JsonIgnore]
        public virtual Order Order { get; set; } = new Order();
    }
}
  