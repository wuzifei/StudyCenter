using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCenter.Model.Enum
{
    public enum  PaperType
    {
        /// <summary>
        /// 作业,课余测试专用
        /// </summary>
        HomeWork = 0,
        /// <summary>
        /// 试卷,考试专用
        /// </summary>
        ForTest = 1,
        /// <summary>
        /// 公开,所有用户均可查看
        /// </summary>
        Public = 2,
        /// <summary>
        /// 私有,只有创建试卷的人才可以查看
        /// </summary>
        Private =3,
    }
}
