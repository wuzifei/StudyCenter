using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using StudyCenter.IBLL;
using StudyCenter.Model;
using System.Web;
namespace StudyCenter.BLL
{
    public partial class UserService:IUserService
    {
        public bool Regist(User nerUser)
        {
            return true;
        }

        //根据用户id登陆
        public User Login(int userId, string userPwd)
        {
            var user = CurrentDal.LoadEntities(u => u.UserNumber == userId.ToString()
                                        && u.UserPwd == userPwd)
                                        .SingleOrDefault();
            if (user == null)
                return null;
             return user;
        }

        //根据用户姓名登陆
        public User Login(string userName, string userPwd)
        {
            var user = CurrentDal.LoadEntities(u => u.UserName == userName
                                                    && u.UserPwd == userPwd).SingleOrDefault();
            if (user != null)
                return user;
            return null;

        }
    }
}
