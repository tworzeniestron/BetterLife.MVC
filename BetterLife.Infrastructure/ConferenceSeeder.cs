using BetterLife.Domain.Entities;
using BetterLife.Infrastructure.Persistence;

namespace BetterLife.Infrastructure
{
    public class ConferenceSeeder
    {
        private readonly ConferenceDbContext _dbContext;

        public ConferenceSeeder(ConferenceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Conferences.Any())
                {
                    var conferences = new Domain.Entities.Conference()
                    {
                        Type = "Testowa konferencja",
                        TicketPrice = 99.00,
                        Addresses = new ConferenceAddress()
                        {
                            Country = "Polska",
                            City = "Warszawa",
                            Street = "Zagloby",
                            PostalCode = "02-495",
                        },
                    };

                    conferences.EncodeType();

                    _dbContext.Conferences.Add(conferences);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
