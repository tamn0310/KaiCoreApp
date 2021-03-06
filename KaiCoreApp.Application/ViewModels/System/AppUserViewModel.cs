﻿using KaiCoreApp.Data.Enums;
using System;
using System.Collections.Generic;

namespace KaiCoreApp.Application.ViewModels.System
{
    public class AppUserViewModel
    {
        public AppUserViewModel()
        {
            Roles = new List<string>();
        }

        public Guid? Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public Status Status { get; set; }
        public string Gender { get; set; }
        public DateTime DateCreated { get; set; }
        public string Avatar { get; set; }
        public string BirthDay { get; set; }
        public List<string> Roles { get; set; }
    }
}