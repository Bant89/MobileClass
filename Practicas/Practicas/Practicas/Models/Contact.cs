﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Practicas.Models
{
    class Contact
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Company { get; set; }

        public long Phone { get; set; }

        public long Mobile { get; set; }

        public string Email { get; set; }

        public string Direction { get; set; }

        public Contact( string firstName, string lastName, long phone)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Phone = phone;
        }

        public Contact() { }

    }
}
