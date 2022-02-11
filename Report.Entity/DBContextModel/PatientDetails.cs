﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Entity.DBContextModel
{
    public class PatientDetails
    {
        [Key]
        public long PatientId { get; set; }
        [Required]
        public string? PatientName { get; set; }
        public string? DOB { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public int PostalCode { get; set; }
        [Required]
        public long Phone { get; set; }
       
    }
}
