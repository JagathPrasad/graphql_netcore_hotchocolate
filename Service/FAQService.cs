using GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Service
{
    public class FAQService : IFAQService
    {
        ImmihubContext db;
        public FAQService()
        {
            db = new ImmihubContext();
        }

        public async Task<List<Faq>> GetFaq()
        {
            try
            {
                return await db.Faqs.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> CreateFaq(Models.Faq faq)
        {
            try
            {
                db.AddAsync(faq);
                return await db.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> UpdateFaq(Models.Faq faq)
        {
            try
            {
                db.Attach(faq);
                return await db.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


    public interface IFAQService
    {
        Task<bool> CreateFaq(Models.Faq visatype);
        Task<bool> UpdateFaq(Models.Faq visatype);
        Task<List<Faq>> GetFaq();
    }
}
