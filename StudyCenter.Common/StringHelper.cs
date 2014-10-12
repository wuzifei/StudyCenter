using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCenter.Common
{
    public static class StringHelper
    {
        /// <summary>
        /// 将String数组转换为Int数组
        /// </summary>
        /// <param name="strIds">string数组</param>
        /// <returns>int数组</returns>
        public static int[] StringsToInts(string[] strIds)
        {
            int[] intIds = new int[strIds.Length];
            for (var i = 0; i < strIds.Length; i++)
            {
                intIds[i] = int.Parse(strIds[i]);
            }
            return intIds;
        }

        /// <summary>
        /// 将字符串转换成Int数组
        /// </summary>
        /// <param name="str">数字组成的字符串</param>
        /// <param name="sep">分解符</param>
        /// <returns>int数组</returns>
        public static int[] ToInts(this string str, char[] sep)
        {
            int[] intIds = {};
            var ids = str.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            intIds = new int[ids.Length];
            for (var i = 0; i < ids.Length; i++)
            {
                intIds[i] = int.Parse(ids[i]);
            }
            return intIds;
        }
    }
}