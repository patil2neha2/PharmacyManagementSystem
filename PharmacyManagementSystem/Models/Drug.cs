using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PharmacyManagementSystem.Interface;
using System.Text.Json.Serialization;

namespace PharmacyManagementSystem.Models
{
    public class Drug
    {
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int DrugId { get; set; }

        [Required(ErrorMessage = "Drug name is required.")]
        public string DrugName { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Expiry date is required.")]
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }

        //[Required(ErrorMessage = "Supplier ID is required.")]
        [JsonIgnore]
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public  Supplier Supplier { get; set; }
        public List<Order> Orders { get; set; }
        
    }
}
