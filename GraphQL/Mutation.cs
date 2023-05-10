using GraphQL.Helper;
using GraphQL.Service;
using HotChocolate.Subscriptions;

namespace GraphQL.GraphQL
{
    public class Mutation
    {

        //private readonly IUserService user;

        //public Mutation(IUserService _user)
        //{
        //    this.user = _user;
        //}

        public async Task<string> CheckUser(UserService user, LoginInput input) => await user.CheckUser(input);
        public async Task<bool> CreateUser(UserService userService, string name, string password) => await userService.CreateUser(name, password);
        public async Task<bool> CreateVisaType(VisaTypeService visatypeservice, Models.VisaType visatype) => await visatypeservice.CreateVisaType(visatype);
        public async Task<bool> CreateFaq(FAQService faqservice, Models.Faq faq) => await faqservice.CreateFaq(faq);

        //public async Task<Book> PublishBook(string title, [Service] ITopicEventSender sender)
        //{
        //    var book = new Book("C#", "Tseting");
        //    await sender.SendAsync(nameof(PublishBook), book);
        //    return book;

        //}



        //public bool Create(string str)
        //{
        //    return true;
        //} 
        //=> await user.CreateUser(userdetails); 
    }
}
