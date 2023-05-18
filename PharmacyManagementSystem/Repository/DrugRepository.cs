using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.Data;
using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Interface;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Repository
{
    public class DrugRepository : IDrug
    {
        private readonly PharmacyManagementSystemContext _context;

        public DrugRepository(PharmacyManagementSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Drug>> GetAllDrug()
        {
            try
            {
                var drugs = await _context.Drugs.Include(n => n.Supplier).ToListAsync();
                return drugs;
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while retrieving drugs.", ex);
            }
        }

        public async Task<Drug> GetDrugById(int id)
        {
            try
            {
                var drug = await _context.Drugs.FindAsync(id);
                return drug;
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while retrieving the drug.", ex);
            }
        }

        public async Task<Drug> PostDrug(DrugDto drug)
        {
            Drug addedDrug = new Drug();
            addedDrug.DrugName = drug.DrugName;
            addedDrug.ExpiryDate = drug.ExpiryDate;
            addedDrug.Quantity = drug.Quantity;
            addedDrug.Price = drug.Price;
            addedDrug.SupplierId = drug.SupplierId;
       

            _context.Drugs.Add(addedDrug);

            await _context.SaveChangesAsync();

            return addedDrug;
        }


        public async Task<bool> PutDrugById(int id, DrugDto drug)
        {
            try
            {
                var existingDrug = await _context.Drugs.FindAsync(id);
                if (existingDrug == null)
                    return false;
                existingDrug.DrugId = id;
                existingDrug.DrugName = drug.DrugName;
                existingDrug.Quantity = drug.Quantity;
                existingDrug.Price = drug.Price;
                existingDrug.ExpiryDate = drug.ExpiryDate;
               // existingDrug.SupplierId = drug.SupplierId;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while updating the drug.", ex);
            }
        }

        public async Task<string> DeleteDrugById(int id)
        {
            try
            {
                var drug = await _context.Drugs.FindAsync(id);
                if (drug == null)
                    return "Couldn't Find the product";

                _context.Drugs.Remove(drug);
                await _context.SaveChangesAsync();
                return "Drug Deleted Successfully";
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while deleting the drug.", ex);
            }
        }




    }
}
