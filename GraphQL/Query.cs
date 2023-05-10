using GraphQL.Models;
using GraphQL.Service;
using HotChocolate.Authorization;

namespace GraphQL.GraphQL
{
    public class Query
    {
        //private readonly IUserService user;

        //public Query(IUserService _user)
        //{
        //    this.user = _user;
        //}

        //[UseProjection]
        //[UseFiltering]
        //[UseSorting]
        //public string Users => "ste";




        //[UseProjection]
        //[UseFiltering]
        //[UseSorting]
        public async Task<List<Journey>> GetJourney(JourneyService journey) => await journey.GetJourney();

        //[Authorize]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<List<User>> GetUser(UserService user) => await user.GetUser();

        public async Task<List<VisaType>> GetVisaTypes(VisaTypeService visatype) => await visatype.GetVisaTypes();

        public async Task<List<Faq>> GetFaq(FAQService faq) => await faq.GetFaq();

    }
}
