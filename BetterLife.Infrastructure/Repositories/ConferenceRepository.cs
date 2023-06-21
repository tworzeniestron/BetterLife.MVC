using BetterLife.Domain.Interfaces;
using BetterLife.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BetterLife.Infrastructure.Repositories
{
    internal class ConferenceRepository : IConferenceRepository
    {
        private readonly ConferenceDbContext _dbContext;

        public ConferenceRepository(ConferenceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Commit() => _dbContext.SaveChangesAsync();

        public async Task Create(Domain.Entities.Conference conference)
        {
            _dbContext.Add(conference);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Conference>> GetAll()
            => await _dbContext.Conferences.ToListAsync();
        public async Task<Domain.Entities.Conference?> GetByEncodedType(string encodedType)//3 spr_unikalności
            => await _dbContext.Conferences.FirstOrDefaultAsync(c => c.EncodedType.ToLower() == encodedType.ToLower());
    }
}