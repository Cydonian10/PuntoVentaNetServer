using System.Text.Json.Serialization;

namespace ApiStore.Data
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CustomerId { get; set; }
        public bool Pay { get; set; }
        public decimal TotalAmount  { get; set; }
        public DateTime OrderDate { get; set; }


        [JsonIgnore]
        public virtual Customer Customer { get; set; } = new Customer();
        [JsonIgnore]
        public virtual User User { get; set; } = new User();
        public virtual ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

    }
}
