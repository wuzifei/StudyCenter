using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyCenter.Model;

namespace StudyCenter.IBLL
{
    public partial interface IUserService
    {
        User Login(string userName, string userPwd);
        User Login(int userId,string  userPwd);
    }
}
