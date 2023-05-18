using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PharmacyManagementSystem.Models
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }

        [Required(ErrorMessage = "Drug ID is required.")]

        [JsonIgnore]
        [ForeignKey("Drug")]
        public int DrugId { get; set; }
        public  Drug Drug { get; set; }

        [Required(ErrorMessage = "Quantity sold is required.")]
        public int QuantitySold { get; set; }

        [Required(ErrorMessage = "Total amount is required.")]
        public decimal TotalAmount { get; set; }
    }
}
