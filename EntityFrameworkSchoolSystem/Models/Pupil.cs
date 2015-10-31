using System;
using System.Collections.Generic;

namespace EntityFrameworkSchoolSystem.Models
{
    public partial class Pupil
    {
        public int PupilId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Adderss2 { get; set; }
        public string PostalZipCode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
    }
}
