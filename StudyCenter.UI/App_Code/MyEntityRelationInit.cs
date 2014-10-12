using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using StudyCenter.BLL;
using StudyCenter.Model;

namespace StudyCenter.UI.App_Code 
{
    public class MyEntityRelationInit<TContext> where TContext:DbContext 
    {
        public MyEntityRelationInit()
        {
            var modelContext = BllFactory.Current;  
				 var user = modelContext.UserService.LoadEntities(u => u.ID == 1).SingleOrDefault();
                if (user != null)
                     user.Role.Add(modelContext.RoleService.LoadEntities(r=>r.ID==1).SingleOrDefault());
            modelContext.UserService.Savechanges();
        }
    }
}