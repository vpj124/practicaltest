using PracticalTest.Web.Models;
using PracticalTest.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticalTest.Web.Services
{
    public class UserService
    {
        public List<UserViewModel> GetAll()
        {
            using (PracticalTestEntities _context = new PracticalTestEntities())
            {
                var _RetObj = new List<UserViewModel>();
                _RetObj = _context.tbl_usermaster.Where(x => x.IsActive == true).AsEnumerable().Select(t => t.ToModel()).ToList();
                return _RetObj;
            }
        }

        public UserViewModel GetUserbyID(string Id)
        {
            using (PracticalTestEntities _context = new PracticalTestEntities())
            {
                var _id = Guid.Parse(Id);
                var _RetObj = new UserViewModel();
                _RetObj = _context.tbl_usermaster.AsEnumerable().Select(t => t.ToModel()).FirstOrDefault(q => q.Id == _id);
                return _RetObj;
            }
        }

        public bool InsertOrUpdate(UserViewModel User)
        {
            bool isUpdated = false;
            using (PracticalTestEntities _context = new PracticalTestEntities())
            {
                if (User.Id == null || User.Id == Guid.Empty)
                {
                    // Insert
                    tbl_usermaster _RetObj = new tbl_usermaster();
                    _RetObj.Id = Guid.NewGuid();
                    _RetObj.Name = User.Name;
                    _RetObj.Birthdate = Convert.ToDateTime(User.Birthdate);
                    _RetObj.Email = User.Email;
                    _RetObj.Mobile = User.Mobile;
                    _RetObj.Age = User.Age;
                    _RetObj.Gender = User.Gender;
                    _RetObj.RoleId = User.RoleId;
                    _RetObj.ProfileUrl = User.ProfileUrl;
                    _RetObj.IsActive = true;
                    _RetObj.CreatedAt = DateTime.Now;
                    _RetObj.UpdatedAt = DateTime.Now;
                    _context.tbl_usermaster.Add(_RetObj);
                }
                else
                {
                    // Update
                    tbl_usermaster _RetObj = _context.tbl_usermaster.AsEnumerable().FirstOrDefault(q => q.Id == User.Id);
                    _RetObj.Id = User.Id;
                    _RetObj.Name = User.Name;
                    _RetObj.Birthdate = Convert.ToDateTime(User.Birthdate);
                    _RetObj.Email = User.Email;
                    _RetObj.Mobile = User.Mobile;
                    _RetObj.Age = User.Age;
                    _RetObj.Gender = User.Gender;
                    _RetObj.RoleId = User.RoleId;
                    _RetObj.ProfileUrl = User.ProfileUrl;
                    _RetObj.UpdatedAt = DateTime.Now;
                }
                _context.SaveChanges();
                isUpdated = true;
            }
            return isUpdated;
        }

        public bool Delete(string Id)
        {
            bool isUpdated = false;
            using (PracticalTestEntities _context = new PracticalTestEntities())
            {
                var _id = Guid.Parse(Id);
                tbl_usermaster _RetObj = _context.tbl_usermaster.AsEnumerable().FirstOrDefault(q => q.Id == _id);
                if (_RetObj.IsActive == true)
                {
                    _RetObj.IsActive = false;
                }
                else
                {
                    _RetObj.IsActive = true;
                }
                _context.SaveChanges();
                isUpdated = true;
                return isUpdated;
            }
        }

        public bool Exist(string Email, string id)
        {
            bool isUpdated = true;
            using (PracticalTestEntities _context = new PracticalTestEntities())
            {
                var _id = Guid.Parse(id);
                tbl_usermaster _RetObj = _context.tbl_usermaster.AsEnumerable().FirstOrDefault(q => q.Email == Email);

                if (_RetObj == null)
                {
                    isUpdated = false;
                }

                if (_id != Guid.Empty)
                {
                    isUpdated = _RetObj.Id != _id ? true : false;
                }
                return isUpdated;
            }
        }
    }
}