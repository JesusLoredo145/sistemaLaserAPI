using sistemaLaserAPI.Dtos;
using sistemaLaserAPI.Models;

namespace sistemaLaserAPI.Interfaces
{
    public interface IIncidentService
    {
        Task<Incident> CreateAsync (CreateIncidentDto dto);
        Task<List<Incident>> GetAllAsync ();
        Task<Incident?> GetByIdAsync(int id);
        Task<int> CountAsync();
        Task<Incident?> GetLatestAsync();
        Task<bool> DeleteAsync(int id);
        Task DeleteAllAsync();
    }
}
