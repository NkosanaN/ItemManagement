using System.ComponentModel.DataAnnotations;

namespace ItemManagementControl.Model
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Type { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public int Qty { get; set; } = default!;
    }
}