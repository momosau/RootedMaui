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
            return await _context.FarmerApplications
                .Include(f => f.Specification) // Include Specification in the query
                .ToListAsync();
        }

        public async Task<List<FarmerApplication>> GetPendingAsync()
        {
            return await _context.FarmerApplications
                .Where(a => a.VerificationStatus == false)
                .Include(f => f.Specification) // Include Specification here too
                .ToListAsync();
        }

        public async Task<FarmerApplication?> GetByIdAsync(int id)
        {
            return await _context.FarmerApplications
                .Include(f => f.Specification) // Include Specification when fetching by ID
                .FirstOrDefaultAsync(f => f.ApplicationId == id);
        }

        public async Task<FarmerApplication> CreateAsync(FarmerApplication app)
        {
            int appSpec = app.Specification?.SpecificationId ?? -1;

            // Check if the specification ID provided in the application is valid
            var spec = await _context.Specifications
                                      .FirstOrDefaultAsync(s => s.SpecificationId == appSpec);

            if (spec == null)
                throw new Exception("Invalid specification ID");

            // Associate the Specification with the FarmerApplication
            app.Specification = spec;

            // Add the new FarmerApplication to the context
            _context.FarmerApplications.Add(app);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return the newly created FarmerApplication
            return app;
        }

        public async Task<bool> UpdateAsync(int id, FarmerApplication app)
        {
            if (id != app.ApplicationId)
                return false;

            var existingApp = await _context.FarmerApplications
                                            .Include(f => f.Specification) // Include Specification for navigation
                                            .FirstOrDefaultAsync(f => f.ApplicationId == id);

            if (existingApp == null)
                return false;

            // Update basic fields
            existingApp.Name = app.Name;
            existingApp.PhoneNumber = app.PhoneNumber;
            existingApp.Description = app.Description;
            existingApp.Email = app.Email;
            existingApp.Password = app.Password;
            existingApp.UserName = app.UserName;
            existingApp.ImageUrl = app.ImageUrl;
            existingApp.Certificate = app.Certificate;
            existingApp.City = app.City;
            existingApp.FarmName = app.FarmName;
            existingApp.Neighborhood = app.Neighborhood;
            existingApp.Street = app.Street;
            existingApp.FarmNum = app.FarmNum;
            existingApp.VerificationStatus = app.VerificationStatus;

            // Handle specification update (if necessary)
            if (app.Specification != null)
            {
                // Update the Specification or create a new one
                existingApp.Specification = app.Specification;
            }

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.FarmerApplications.AnyAsync(e => e.ApplicationId == id))
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
            var application = await _context.FarmerApplications
                                              .Include(f => f.Specification) // Include Specification for the new Farmer
                                              .FirstOrDefaultAsync(f => f.ApplicationId == id);
            if (application == null)
                return null;

            var farmer = new Farmer
            {
                Name = application.Name,
                PhoneNumber = application.PhoneNumber,
                Description = application.Description,
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
                VerificationStatus=true,
            };

            // If necessary, add Specification info to the Farmer
            if (application.Specification != null)
            {
                // Link or add Specification details if required
                farmer.Specification = application.Specification;
            }

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
