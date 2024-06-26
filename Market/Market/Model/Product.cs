﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Market.Model
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public string Image { get; set; }
        public int Category_ID { get; set; }
        [ForeignKey("Category_ID")]
        [JsonIgnore]
        public Category Category { get; set; }
        public ICollection<CartItems> CartItems { get; set; }
    }
}
