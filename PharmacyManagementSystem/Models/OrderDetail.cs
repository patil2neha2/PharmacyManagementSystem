using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PharmacyManagementSystem.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }

        [JsonIgnore]
        public Order Order { get; set; }
        public int OrderId { get; set; }

        [JsonIgnore]
        [ForeignKey("Drug")]
        public int DrugId { get; set; }
        public Drug Drug { get; set; }

        [Required]
        public int DrugQuantity { get; set; }

        [Required]
        public decimal subTotal { get; set; }


    }
}
