using GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Service
{
    public class VisaTypeService : IVisaTypeService
    {
        ImmihubContext db;
        public VisaTypeService()
        {
            db = new ImmihubContext();
        }

        public async Task<List<VisaType>> GetVisaTypes()
        {
            try
            {
                return await db.VisaTypes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> CreateVisaType(Models.VisaType visatype)
        {
            try
            {
                db.AddAsync(visatype);
                return await db.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> UpdateVisaType(Models.VisaType visatype)
        {
            try
            {
                db.Attach(visatype);
                return await db.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


    public interface IVisaTypeService
    {
        Task<bool> CreateVisaType(Models.VisaType visatype);
        Task<bool> UpdateVisaType(Models.VisaType visatype);
        Task<List<VisaType>> GetVisaTypes();
    }
}
