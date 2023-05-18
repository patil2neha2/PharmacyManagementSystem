using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.Data;
using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Interface;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Repository
{
    public class SupplierRepository : ISupplier
    {

        private readonly PharmacyManagementSystemContext _context;

        public SupplierRepository(PharmacyManagementSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Supplier>> GetAllSupplier()
        {
            try
            {
                var suppliers = await _context.Suppliers.ToListAsync();
                return suppliers;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving suppliers.", ex);
            }
        }

        public async Task<Supplier> GetSupplierById(int id)
        {
            try
            {
                var supplier = await _context.Suppliers.FindAsync(id);
                return supplier;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the supplier.", ex);
            }
        }

        public async Task<Supplier> PostSupplier(SupplierDto supplier)
        {
            Supplier existingSupplier = new Supplier();
            existingSupplier.SupplierName = supplier.SupplierName;
            existingSupplier.SupplierEmail = supplier.supplierEmail;
            existingSupplier.Contact = supplier.Contact;
            existingSupplier.Address = supplier.Address;

            _context.Suppliers.Add(existingSupplier);
            await _context.SaveChangesAsync();

            return existingSupplier;
        }

        public async Task<bool> PutSupplierById(int id, SupplierDto supplier)
        {
            try
            {
                var existingSupplier = await _context.Suppliers.FindAsync(id);
                if (existingSupplier == null)
                    return false;

                existingSupplier.SupplierName = supplier.SupplierName;
                existingSupplier.SupplierEmail = supplier.supplierEmail;
                existingSupplier.Contact = supplier.Contact;
                existingSupplier.Address = supplier.Address;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the supplier.", ex);
            }
        }

        public async Task<string> DeleteSupplierById(int id)
        {
            try
            {
                var supplier = await _context.Suppliers.FindAsync(id);
                if (supplier == null)
                    return "Couldn't find the supplier";

                _context.Suppliers.Remove(supplier);
                await _context.SaveChangesAsync();

                return "Supplier deleted successfully";
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the supplier.", ex);
            }
        }


    }
}
