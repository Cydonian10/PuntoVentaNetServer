﻿using System.Text.Json.Serialization;

namespace ApiStore.Data;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    [JsonIgnore]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

}
