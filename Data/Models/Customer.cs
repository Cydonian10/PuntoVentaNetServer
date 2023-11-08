﻿namespace ApiStore.Data
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
