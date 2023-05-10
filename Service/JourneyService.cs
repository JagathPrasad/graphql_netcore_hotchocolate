using GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Service
{
    public class JourneyService : IJourneyService
    {
        ImmihubContext db;
        public JourneyService()
        {
            db = new ImmihubContext();
        }

        public async Task<List<Journey>> GetJourney()
        {
            try
            {
                return await db.Journeys.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> CreateJourney(Models.Journey   journey)
        {
            try
            {
                db.AddAsync(journey);
                return await db.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> UpdateJourney(Models.Journey journey)
        {
            try
            {
                db.Attach(journey);
                return await db.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


    public interface IJourneyService
    {
        Task<bool> CreateJourney(Models.Journey journey);
        Task<bool> UpdateJourney(Models.Journey journey);
        Task<List<Journey>> GetJourney();
    }
}
