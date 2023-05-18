using Microsoft.AspNetCore.Mvc;
using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Interface
{
    public interface IDrug
    {
        Task<List<Drug>> GetAllDrug();
        Task<Drug> GetDrugById(int id);
        Task<Drug>PostDrug(DrugDto drug);  
        Task<bool> PutDrugById(int id, DrugDto drug);
        Task<string> DeleteDrugById(int id);
    }
}
