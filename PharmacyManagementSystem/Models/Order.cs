using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PharmacyManagementSystem.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

       
        [Required]
        public int OrderNo { get; set; }

   
        [Required]
        public decimal Total { get; set; }

        [JsonIgnore]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime pickupDate { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }


        public Order() { }


    }
}
