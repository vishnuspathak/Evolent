﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManagment.Models
{
    public class Contact
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public bool Status { get; set; }
    }
}