using System.ComponentModel.DataAnnotations;

namespace PharmacyManagementSystem.DTO
{
    public class SupplierDto
    {
        [Required(ErrorMessage = "Supplier name is required.")]
        public string? SupplierName { get; set; }

        [Required(ErrorMessage = "Please enter supplier email id")]
        [DataType(DataType.EmailAddress)]
        public string? supplierEmail { get; set; }

        [Required(ErrorMessage = "Contact information is required.")]
        public string? Contact { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string? Address { get; set; }
    }
}
