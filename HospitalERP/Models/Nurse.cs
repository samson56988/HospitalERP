using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalERP.Models
{
    public class Nurse
    {
        [Display(Name = "Nurse ID")]
        public string N_ID { get; set; }
        [Display(Name = "Fullname")]
        public string N_Fullname { get; set; }
        [Display(Name = "Firstname")]
        public string N_Firstname { get; set; }
        [Display(Name = "Lastname")]
        public string N_Lastname { get; set; }
        [Display(Name = "Middlename")]
        public string N_Middlename { get; set; }
        [Display(Name = "Address")]
        public string N_Address { get; set; }
        [Display(Name = "Phone")]
        public string N_Phone { get; set; }
        [Display(Name = "Speciality")]
        public string N_Speciality { get; set; }
        [Display(Name = "Date of Employment")]
        public string N_Dob { get; set; }
        Random random = new Random();
        public Nurse()
        {
            N_ID = "N" + Convert.ToString((long)Math.Floor(random.NextDouble() * 9_000_000_000L + 1_000_000_000L));
            N_Fullname = $"{N_Firstname}  {N_Middlename} {N_Lastname}";
            UserID = "U" + Convert.ToString((long)Math.Floor(random.NextDouble() * 9_000_000_000L + 1_000_000_000L));
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string IsActive { get; set; }
        public string UserID { get; set; }
        public string Response { get; set; }
    }
}
