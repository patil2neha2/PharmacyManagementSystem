using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Interface
{
    public interface ISupplier
    {
        Task<List<Supplier>> GetAllSupplier();
        Task<Supplier> GetSupplierById(int id);
        Task<Supplier> PostSupplier(SupplierDto supplier);
        Task<bool> PutSupplierById(int id,SupplierDto supplier);
        Task<string> DeleteSupplierById(int id);
    }
}
