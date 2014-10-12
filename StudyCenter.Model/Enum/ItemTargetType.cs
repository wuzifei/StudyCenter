using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCenter.Model.Enum
{
	/// <summary>
	/// 道具可供使用的目标种类
	/// </summary>
	public enum  ItemTargetType
	{
		/// <summary>
		/// 自己使用
		/// </summary>
		ToUserSelf=0,
		/// <summary>
		/// 对他人使用
		/// </summary>
		ToOtherUser,
		/// <summary>
		/// 可同时对自己和他人使用
		/// </summary>
		ToUserSelfAndOtherUser,
		/// <summary>
		/// 可对自己或他人使用
		/// </summary>
		ToUserSelfOrOtherUser,
		/// <summary>
		/// 对文章使用
		/// </summary>
		ToArticle ,
		/// <summary>
		/// 对文章标题使用
		/// </summary>
		ToArticleTitle,
		/// <summary>
		/// 对文章评论使用
		/// </summary>
		ToArticleComment 
	}
}
