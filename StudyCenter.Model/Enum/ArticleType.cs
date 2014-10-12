using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCenter.Model.Enum
{
	/// <summary>
	/// 文的种类
	/// </summary>
	public enum ArticleType
	{
		/// <summary>
		/// 正宗的文章
		/// </summary>
		IsArticle=1,
		/// <summary>
		/// 别样的新闻
		/// </summary>
		IsNews = 2,
		/// <summary>
		/// 讨厌的通告
		/// </summary>
		IsNotice =3
	}
}
