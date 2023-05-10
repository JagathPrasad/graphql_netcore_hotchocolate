namespace GraphQL.Helper
{
    public class User
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? MobileNo { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? CreatedBy { get; set; }
    }




   public record UserInput(string? Name, string? email, string? password, string? mobileno, bool? isactive, bool? isdeleted);
}
