using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalERP.Models
{
    public class Login
    {
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Username { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }
        public string Role { get; set; }
        public string IsActive { get; set; }
        public string UserID { get; set; }
        public string Response { get; set; }

        Random random = new Random();
        public Login()
        {
            UserID = Convert.ToString((long)Math.Floor(random.NextDouble() * 9_000_000_000L + 1_000_000_000L));
        }
    }
}
