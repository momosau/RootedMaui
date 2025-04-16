using SharedLibraryy.Services;
using SharedLibraryy.Models;
using RootedBack.Data;
using Microsoft.EntityFrameworkCore;

namespace RootedBack.Services
{
    public class FarmerApplicationsService : IFarmerApplicationsService
    {
        private readonly RootedDBContext _context;
        public FarmerApplicationsService(RootedDBContext context)
        {
            _context = context;
        }

        public async Task<List<FarmerApplication>> GetAllAsync()
        {
            return await _context.FarmerApplications.ToListAsync();
        }

        public async Task<List<FarmerApplication>> GetPendingAsync()
        {
            return await _context.FarmerApplications
                .Where(a => a.VerificationStatus == false)
                .ToListAsync();
        }

        public async Task<FarmerApplication?> GetByIdAsync(int id)
        {
            return await _context.FarmerApplications.FindAsync(id);
        }

        public async Task<FarmerApplication> CreateAsync(FarmerApplication app)
        {
            
            var specIds = app.Specifications.Select(s => s.SpecificationId).ToList();

           
            var fullSpecs = await _context.Specifications
                                          .Where(s => specIds.Contains(s.SpecificationId))
                                          .ToListAsync();

      
            app.Specifications = fullSpecs;

          
            _context.FarmerApplications.Add(app);
            await _context.SaveChangesAsync();

            return app;
        }


        public async Task<bool> UpdateAsync(int id, FarmerApplication app)
        {
            if (id != app.AppilicationId)
                return false;

            _context.Entry(app).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.FarmerApplications.AnyAsync(e => e.AppilicationId == id))
                    return false;
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var app = await _context.FarmerApplications.FindAsync(id);
            if (app == null)
                return false;

            _context.FarmerApplications.Remove(app);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Farmer> AcceptApplicationAsync(int id)
        {
            var application = await _context.FarmerApplications.FindAsync(id);
            if (application == null)
                return null;

            var farmer = new Farmer
            {
                Name = application.Name,
                PhoneNumber = application.PhoneNumber,
                Description=application.Description,
                Email = application.Email,
                Password = application.Password,
                UserName = application.UserName,
                ImageUrl = application.ImageUrl,
                Certificate = application.Certificate,
                City = application.City,
                FarmName = application.FarmName,
                Neighborhood = application.Neighborhood,
                Street = application.Street,
                FarmNum = application.FarmNum,
            };

            _context.Farmers.Add(farmer);
            _context.FarmerApplications.Remove(application);
            await _context.SaveChangesAsync();

            return farmer;
        }

        public async Task<bool> RejectApplicationAsync(int id)
        {
            var application = await _context.FarmerApplications.FindAsync(id);
            if (application == null)
                return false;

            _context.FarmerApplications.Remove(application);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
