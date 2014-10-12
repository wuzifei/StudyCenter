using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCenter.Model.Enum
{
	public enum ItemType
	{
		/// <summary>
		/// 使用之后，就马上生效，一次性的，一般为永久效果
		/// </summary>
		IsOneTime=0,
		/// <summary>
		/// 使用之后，会有持续性效果，一般持续几天就结束了
		/// </summary>
		IsLongTime=1
	}
}
