using KaiCoreApp.Data.Enums;
using KaiCoreApp.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KaiCoreApp.Data.Entities
{
    [Table("AppUsers")]
    public class AppUser : IdentityUser<Guid>, IDateTracking, ISwitchable
    {
        public AppUser()
        {
        }

        public AppUser(Guid id, string fullname,
            string avatar, string email, string phonenumber, Status status, string username)
        {
            Id = id;
            FullName = fullname;
            Avatar = avatar;
            Email = email;
            PhoneNumber = phonenumber;
            Status = status;
            UserName = username;
        }

        public string FullName { get; set; }

        public DateTime? BirthDay { set; get; }

        public decimal Balance { get; set; }

        public string Avatar { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime DateModified { get; set; }
        public Status Status { get; set; }
    }
}