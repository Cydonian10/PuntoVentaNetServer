namespace ApiStore.Data
{
    public class Shopping
    {
        public Guid Id { get; set; }
        public Guid ProviderId { get; set; }
        public DateTime DatePurchase { get; set; }
        public decimal TotalAmount { get; set; }
        //public virtual 

        public virtual Provider Provider { get; set; } = new Provider();
        public virtual ICollection<ShoppingItem> ShoppingItems { get; set; } = new List<ShoppingItem>();
    }
}
