using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudyCenter.BLL;
using StudyCenter.Model;

namespace StudyCenter.UI.App_Code
{
    public class DbReference
    {
        public DbReference()
        {
            var modelContext = BllFactory.Current;
            var users = modelContext.UserService.LoadEntities(u => u.ID > 0).FirstOrDefault().Role;
            var userAndrole = modelContext.UserService.LoadEntities(u => u.ID == 1,u=>u.Role).ToList();
            var Role = new Model.Role();
            Role = userAndrole.FirstOrDefault().Role.FirstOrDefault();
        }
    }
}