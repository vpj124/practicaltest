using PracticalTest.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticalTest.Web.ViewModels
{
    public static class MappingExtension
    {
        #region User
        public static UserViewModel ToModel(this tbl_usermaster Entity)
        {
            if (Entity == null)
                throw new ArgumentException("Entity");

            return new UserViewModel()
            {
                Id = Entity.Id,
                Name = Entity.Name,
                Birthdate = Entity.Birthdate.Value.ToString("yyyy-MM-dd"),
                Email = Entity.Email,
                Mobile = Entity.Mobile,
                Age = Entity.Age,
                Gender = Entity.Gender,
                RoleId = Entity.RoleId,
                ProfileUrl = Entity.ProfileUrl,
                IsActive = Entity.IsActive,
                CreatedAt = Entity.CreatedAt != null ? Entity.CreatedAt.Value : DateTime.Now,
                UpdatedAt = Entity.UpdatedAt != null ? Entity.UpdatedAt.Value : DateTime.Now
            };
        }
        public static tbl_usermaster ToEntity(this UserViewModel Entity)
        {
            if (Entity == null)
                throw new ArgumentException("Entity");

            return new tbl_usermaster()
            {
                Id = Entity.Id,
                Name = Entity.Name,
                Birthdate = Convert.ToDateTime(Entity.Birthdate),
                Email = Entity.Email,
                Mobile = Entity.Mobile,
                Age = Entity.Age,
                Gender = Entity.Gender,
                RoleId = Entity.RoleId,
                ProfileUrl = Entity.ProfileUrl,
                IsActive = Entity.IsActive,
                CreatedAt = Entity.CreatedAt != null ? Entity.CreatedAt.Value : DateTime.Now,
                UpdatedAt = Entity.UpdatedAt != null ? Entity.UpdatedAt.Value : DateTime.Now
            };
        }
        #endregion
    }
}