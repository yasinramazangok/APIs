namespace YummyRestaurant.WebApi.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string MapInformation { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OpenHours { get; set; }
    }
}
