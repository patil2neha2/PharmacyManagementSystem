using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PharmacyManagementSystem.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

       // [Required(ErrorMessage = "Supplier name is required.")]
        public string? SupplierName { get; set; }

        //[Required(ErrorMessage = "Please enter supplier email id")]
       // [DataType(DataType.EmailAddress)]
        public string?  SupplierEmail { get; set; }

       // [Required(ErrorMessage = "Contact information is required.")]
        public string? Contact { get; set; }

       // [Required(ErrorMessage = "Address is required.")]
        public string? Address { get; set; }

        [JsonIgnore]
        public IEnumerable<Drug> Drug { get; set; }
    }
}
