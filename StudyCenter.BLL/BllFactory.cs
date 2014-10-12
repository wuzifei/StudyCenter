using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using StudyCenter.Common;
using StudyCenter.IBLL;

namespace StudyCenter.BLL
{
    public class BllFactory
    {
        private static IBllSession _bllSession;
        /// <summary>
        /// 对外访问接口,所有的服务都可以从这里获取
        /// </summary>
        public static IBllSession Current
        {
            get
            {
                _bllSession = CallContext.GetData("BllSession") as BllSession;
                if (_bllSession != null)
                    return _bllSession;

                //_bllSession = new BllSession();

                //TODO:使用Spring进行依赖注入
                _bllSession = SpringHelper.GetObject("BllSession") as IBllSession;

                CallContext.SetData("BllSession",_bllSession);
                return _bllSession;
            }
        }
    }
}
