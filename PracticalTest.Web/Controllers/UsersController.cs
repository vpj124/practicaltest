using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PracticalTest.Web.Models;
using PracticalTest.Web.Services;
using PracticalTest.Web.ViewModels;

namespace PracticalTest.Web.Controllers
{
    public class UsersController : Controller
    {
        UserService _service = new UserService();
        CommonService _commonService = new CommonService(new PracticalTestEntities());

        // GET: Users
        public ActionResult Index()
        {
            var objList = _service.GetAll();
            return View(objList);
        }

        public ActionResult CreateUpdate(string Id = null)
        {
            UserViewModel model = new UserViewModel();
            if (Id == null)
            {
                //Create
                ViewBag.TitleName = "Create";
            }
            else
            {
                //Update
                ViewBag.TitleName = "Update";
                var getData = _service.GetUserbyID(Id);
                model = getData;
            }
            ViewBag.Roles = new SelectList(_commonService.GetRoles(), "Id", "Name");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult CreateUpdate(UserViewModel model, HttpPostedFileBase ImageFile)
        {
            ViewBag.Roles = new SelectList(_commonService.GetRoles(), "Id", "Name");
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Please fill all the details.";
                TempData["status"] = "error";
                return View(model);
            }

            if (_service.Exist(model.Email, model.Id.ToString()))
            {
                TempData["Message"] = "Email id is already exist.";
                TempData["status"] = "error";
                return View(model);
            }

            //Use Namespace called :  System.IO  
            string FileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);

            //To Get File Extension  
            string FileExtension = Path.GetExtension(ImageFile.FileName);

            //Add Current Date To Attached File Name  
            FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;

            //Get Upload path from Web.Config file AppSettings.  
            string folderPath = Server.MapPath("~/Content/Files/");

            //Check whether Directory (Folder) exists.
            if (!Directory.Exists(folderPath))
            {
                //If Directory (Folder) does not exists. Create it.
                Directory.CreateDirectory(folderPath);
            }

            if (FileExtension == ".jpg" || FileExtension == ".jpeg" || FileExtension == ".png")
            {
                // Get the complete folder path and store the file inside it.  
                ImageFile.SaveAs(Path.Combine(folderPath, FileName));
                model.ProfileUrl = "~/Content/Files/" + FileName;
            }
            else
            {
                TempData["Message"] = "you have to upload only image.";
                TempData["status"] = "error";
            }

            var result = _service.InsertOrUpdate(model);
            if (model.Id != Guid.Empty)
            {
                //Update
                TempData["Message"] = "User has been updated successfully.";
                TempData["status"] = "success";
            }
            else
            {
                //Create
                TempData["Message"] = "User has been created successfully.";
                TempData["status"] = "success";
            }

            if (result)
            {
                return RedirectToAction("Index", "Users");
            }
            else
            {
                TempData["Message"] = "Something went wrong! Please try again.";
                TempData["status"] = "error";
                return View(model);
            }
        }

        [HttpPost]
        public JsonResult Delete(string id = null)
        {
            if (_service.Delete(id))
                return Json("This user has been deleted successfully.", JsonRequestBehavior.AllowGet);
            else
                return Json("Some error occured when you trying to deleting data.", JsonRequestBehavior.AllowGet);
        }
    }
}
