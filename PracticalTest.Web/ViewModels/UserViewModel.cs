using PracticalTest.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticalTest.Web.ViewModels
{
    public class UserViewModel
    {
        public System.Guid Id { get; set; }

        [Required(ErrorMessage = "Enter Your Name")]
        [StringLength(50, ErrorMessage = "Name should be less than or equal to fifty characters.")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter Your DOB.")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [CustomValidationAttributeDemo.ValidBirthDate(ErrorMessage = "Birth Date can not be greater than current date")]
        public string Birthdate { get; set; }

        [Required(ErrorMessage = "Enter Your EmailID")]
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Your must provide a Mobile")]
        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Enter Age")]
        public Nullable<int> Age { get; set; }

        [Required(ErrorMessage = "Select Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Select Role")]
        public Nullable<int> RoleId { get; set; }
        public string ProfileUrl { get; set; }

        public Nullable<bool> IsActive { get; set; }

        public Nullable<System.DateTime> CreatedAt { get; set; }

        public Nullable<System.DateTime> UpdatedAt { get; set; }

        public virtual tbl_rolemaster tbl_rolemaster { get; set; }
    }

    public class CustomValidationAttributeDemo
    {
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
        public sealed class ValidBirthDate : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    DateTime _birthJoin = Convert.ToDateTime(value);
                    if (_birthJoin > DateTime.Now)
                    {
                        return new ValidationResult("Birth date can not be greater than current date.");
                    }
                }
                return ValidationResult.Success;
            }
        }
    }
}