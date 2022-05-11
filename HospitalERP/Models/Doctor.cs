using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalERP.Models
{
    public class Doctor
    {
        [Display(Name = "Doctor ID")]
        public string D_ID { get; set; }
        [Display(Name = "Fullname")]
        public string D_Fullname { get; set; }
        [Display(Name = "Firstname")]
        public string D_Firstname { get; set; }
        [Display(Name = "Lastname")]
        public string D_Lastname { get; set; }
        [Display(Name = "Middlename")]
        public string D_Middlename { get; set; }
        [Display(Name = "Address")]
        public string D_Address { get; set; }
        [Display(Name = "Phone No")]
        public string D_Phone { get; set; }
        [Display(Name = "Speciality")]
        public string D_Speciality { get; set; }
        [Display(Name = "Date of Birth")]
        public string D_Dob { get; set; }

   

        Random random = new Random();
        public Doctor()
        {
            D_ID = "D" + Convert.ToString((long)Math.Floor(random.NextDouble() * 9_000_000_000L + 1_000_000_000L));
            UserID ="U" + Convert.ToString((long)Math.Floor(random.NextDouble() * 9_000_000_000L + 1_000_000_000L));
        }
        public string Username { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }
        public string Role { get; set; }
        public string IsActive { get; set; }
        public string UserID { get; set; }
        public string Response { get; set; }


    }
}
