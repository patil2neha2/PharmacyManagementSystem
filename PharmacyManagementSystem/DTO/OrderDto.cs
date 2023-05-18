using System.ComponentModel.DataAnnotations;

namespace PharmacyManagementSystem.DTO
{
    public class OrderDto
    {
        public int Total { get; set; }


        public int UserId { get; set; }
        [DataType(DataType.Date)]
        public DateTime pickupDate { get; set; }






    }
}
