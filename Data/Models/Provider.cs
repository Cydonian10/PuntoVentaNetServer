using System.Text.Json.Serialization;

namespace ApiStore.Data
{
    public class Provider
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        [JsonIgnore]
        public virtual ICollection<Shopping> Shoppings { get; set; } = new List<Shopping>();
    }
}
