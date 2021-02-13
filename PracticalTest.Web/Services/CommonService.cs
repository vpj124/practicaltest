using PracticalTest.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticalTest.Web.Services
{
    public class CommonService
    {
        private readonly PracticalTestEntities _context;
        public CommonService(PracticalTestEntities context)
        {
            this._context = context;
        }

        public List<tbl_rolemaster> GetRoles()
        {
            var roles = _context.tbl_rolemaster.Where(x => x.IsActive == true).ToList();
            return roles;
        }
    }
}