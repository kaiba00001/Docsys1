namespace Clinic.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public int ClinicId { get; set; }

        public ClinicInfo Clinic { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}