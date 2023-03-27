using System.ComponentModel.DataAnnotations;

namespace AssetLogWeb.Models
{
    public class Asset
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        public bool BeingServiced { get; set; }
        public string? Notes { get; set; }
        public string? ImgPath { get; set; }
        public DateTime DateAddedToInventory { get; set; } = DateTime.Now;

        public Asset()
        {
            BeingServiced = false;
        }

        //Relationships
    }
}
