namespace ApiStore.Data
{
    public class ShoppingItem
    {
        public Guid Id { get; set; }
        public Guid ShoppingId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Quantity { get; set; }
        public UnitMeasurement UnitMeasurement { set; get; }

        public Shopping Shopping { get; set; } = new Shopping();
        public Product Product { get; set; } = new Product();

    }
}
