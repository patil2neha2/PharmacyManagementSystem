using System.ComponentModel.DataAnnotations;

namespace PharmacyManagementSystem.DTO
{
    public class DrugDto
    {
        [Key]
       

        
        public string DrugName { get; set; }

        public int Quantity { get; set; }

    
        public decimal Price { get; set; }

      
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }

        public int SupplierId { get; set; }

    }
}
