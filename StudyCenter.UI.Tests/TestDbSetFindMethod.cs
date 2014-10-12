using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyCenter.BLL;
using StudyCenter.Model;
using StudyCenter.Model.ViewModel;
using StudyCenter.UI.ViewModel;

namespace StudyCenter.UI.Tests
{
    [TestClass]
    public class TestDbSetFindMethod
    {
        private ModelContainer dbContext = new ModelContainer();

        [TestMethod]
        public void TestDbSetFind()
        {
        }

        [TestMethod]
        public void TestPagination()
        {
            var p = new Pagination();
            Assert.IsFalse(p.IsAjax);
        }

        [TestMethod]
        public void DateTime2ToDataTime()
       { 
            var str = "2014-5-8 23:22:51";
            var dStr = DateTime.Now.ToLongTimeString();
            DateTime time1 = DateTime.Now;
            DateTime time = DateTime.Parse(str);
        }

        [TestMethod]
        public void DistinctUnion()
        {
            var listA = new List<int>();
            for (var i = 0; i < 3; i++)
            {
                listA.Add(i);
            }
            var l = new EqualInt();
            var listB = new List<int>();
            for (var i = 9; i > 1; i--)
            {
                listB.Add(i);
            }
            var union = listA.Union(listB);//并集
            var except = listA.Except(listB);//差集
            var intercet = listA.Intersect(listB);//交集
        }
        [TestMethod]
        public void ConvertTimeString()
        {
            var str = "8/11/2014 23:37";
            DateTimeFormatInfo dt = new DateTimeFormatInfo();
            dt.LongDatePattern = "MM/dd/yyyy HH:MM";
            var t = Convert.ToDateTime(str,new DateTimeFormatInfo(){LongDatePattern = "MM/dd/yyyy HH:MM"});
            //var stTime = DateTime.ParseExact(str, "MM/dd/yyyy HH:mm", CultureInfo.CurrentCulture);
            var time = t.ToString("u");
        }
    }

    public class EqualInt : IEqualityComparer<int>
    {

        public bool Equals(int x, int y)
        {
            return x == y;
        }

        public int GetHashCode(int obj)
        {
            throw new NotImplementedException();
        }
    }


}
