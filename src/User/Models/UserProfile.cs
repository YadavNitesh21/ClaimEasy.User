using System.ComponentModel.DataAnnotations;

namespace User.Models
{
    public class UserProfile
    {
        public Guid Id { get; set; }               // Primary Key (same as Auth User Id for linking)
        public string Username { get; set; }       // To link with Auth service (optional if needed)
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }          // Redundant but useful for profile display
        public string Phone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

}
