﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopContactApp.Classes
{
    public class Contacts
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Email} - {Phone}";
        }

    }
}