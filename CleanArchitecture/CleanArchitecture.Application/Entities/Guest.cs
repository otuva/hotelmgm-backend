namespace CleanArchitecture.Core.Entities
{
    public class Guest : AuditableBaseEntity
    {
        public char Gender { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int AddressId { get; set; }
        public string DateOfBirth { get; set; }
        public string AnniversaryDate { get; set; }
        public string IdName { get; set; }
        public string IdValue { get; set; }
        public string Nationality { get; set; }

        //Database Modified
    }
}
