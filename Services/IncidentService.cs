using Microsoft.EntityFrameworkCore;
using sistemaLaserAPI.Data;
using sistemaLaserAPI.Dtos;
using sistemaLaserAPI.Interfaces;
using sistemaLaserAPI.Models;

namespace sistemaLaserAPI.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly ApplicationDbContext _context;
        public IncidentService(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<Incident> CreateAsync(CreateIncidentDto dto)
        {
            var incident = new Incident
            {
                deviceId = dto.deviceId,
                counter = dto.counter,
                signalValue = dto.signalValue,
                detectionDate = dto.detectionDate,
                created = DateTime.UtcNow
            };
            _context.Incidents.Add(incident);
            await _context.SaveChangesAsync();
            return incident;
        }
        public async Task<List<Incident>> GetAllAsync()
        {
            return await _context.Incidents.OrderByDescending(x=> x.id).ToListAsync();
        }
        public async Task<Incident?> GetByIdAsync(int id)
        {
            return await _context.Incidents.FindAsync(id);
        }

        public async Task<int> CountAsync()
        {
            return await _context.Incidents.CountAsync();
        }

        public async Task<Incident?> GetLatestAsync()
        {
            return await _context.Incidents.OrderByDescending(x => x.id).FirstOrDefaultAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var incident = await _context.Incidents.FindAsync(id);
            if (incident == null)
                return false;
            _context.Incidents.Remove(incident);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task DeleteAllAsync()
        {
            _context.Incidents.RemoveRange(_context.Incidents);
            await _context.SaveChangesAsync();
        }
    }
}
