using System.ComponentModel.DataAnnotations;

namespace RetailStore.Models.Domain
{
    public class Item
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Quantity { get; set; }
        public Double? Price { get; set; }

    }
}
