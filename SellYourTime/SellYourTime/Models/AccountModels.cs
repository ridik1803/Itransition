﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using Microsoft.VisualBasic.ApplicationServices;

namespace SellYourTime.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Dislike> Dislikes { get; set; } 
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public virtual int UserId { get; set; }

        public virtual string UserName { get; set; }
        public virtual string Email { get; set; }
        public virtual string ContactData { get; set; }
        public virtual string Role { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<Order> YourOrders { get; set; }
        public virtual ICollection<Order> BuyingFromYou { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual int? NumberLikes { get; set; }
        public virtual ICollection<Dislike> Dislikes { get; set; }
        public virtual int? NumberDislikes { get; set; }
        public virtual double? Rating { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contact data")]
        public string ContactData { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }

}
