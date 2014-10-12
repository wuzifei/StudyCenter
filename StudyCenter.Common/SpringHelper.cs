using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Spring.Context;
using Spring.Context.Support;
using Spring.Core.IO;
using Spring.Objects.Factory;
using Spring.Objects.Factory.Xml;

namespace StudyCenter.Common
{
    public class SpringHelper
    {
        private static XmlApplicationContext _context;

        /// <summary>
        /// 初始化Spring,默认配置文件路径为"~/Objects.xml"
        /// </summary>
        /// <returns></returns>
        public static  bool SpringInit()
        {
            return SpringInit("~/Objects.xml");
        }

        /// <summary>
        /// 初始化Spring
        /// </summary>
        /// <param name="configFilePath">默认配置文件路径</param>
        /// <returns></returns>
        public static bool SpringInit(String configFilePath)
        {
            try
            {
                _context = new XmlApplicationContext(configFilePath);
            }
            catch (Exception e)
            {
                var msg = e.Message;
            }
            if (_context != null)
                return true;
            return false;
        }

        /// <summary>
        /// 按照默认配置文件中的对象ID获取对象实例
        /// </summary>
        /// <param name="objConfigName"></param>
        /// <returns></returns>
        public static Object GetObject(String objConfigName)
        {
            ////通过XmlObjectFactory配置
            //IResource input = new FileSystemResource( "~/Objects.xml " );
            //IObjectFactory factory = new  XmlObjectFactory(input);
            //var obj = factory.GetObject(objConfigName);

            //通过IApplicationContext来配置 
            //_context = new XmlApplicationContext("~/Objects.xml");
            var obj = _context.GetObject(objConfigName);
            return obj;
        }

        /// <summary>
        /// 按照默认配置文件中的对象ID获取对象实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objConfigName"></param>
        /// <returns></returns>
        public static T GetObject<T>(String objConfigName)
        {
            var obj = (T)_context.GetObject(objConfigName);
            return obj;
        }

        /// <summary>
        /// 按照Objects配置文件和配置对象名创建对象实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objConfigName"></param>
        /// <param name="objConfigFilePath"></param>
        /// <param name="isOnce"></param>
        /// <returns></returns>
        public static T GetObject<T>(String objConfigName, String objConfigFilePath, bool isOnce)
        {
            if (string.IsNullOrEmpty(objConfigFilePath))
                return GetObject<T>(objConfigName);

            if (isOnce)
            {
                //将原先的上下文存储起来
                var oldContex = _context;
                //按照新的配置创建实例
                _context = new XmlApplicationContext(objConfigFilePath);
                //获取按照新配置上下文创建对象
                var obj = (T)_context.GetObject(objConfigName);

                //还原原先的上下文
                _context = oldContex;
                return obj;
            }

            //不是一次性的,永久使用传入的配置文件
            _context = new XmlApplicationContext(objConfigFilePath);
            //获取按照新配置上下文创建对象
            return _context.GetObject<T>(objConfigName);
        }

        /// <summary>
        /// 按照Objects配置文件和配置对象名创建对象实例
        /// </summary>
        /// <param name="objConfigName">配置文件中对象Id名称</param>
        /// <param name="objConfigFilePath">配置文件相对路径</param>
        /// <param name="isOnce">配置文件是否是支队此次使用有效</param>
        /// <returns>需要创建的对象</returns>
        public static Object GetObject(String objConfigName, String objConfigFilePath, bool isOnce)
        {
            if (string.IsNullOrEmpty(objConfigFilePath))
                return GetObject(objConfigName);

            if (isOnce)
            {
                //将原先的上下文存储起来
                var oldContex = _context;
                //按照新的配置创建实例
                _context = new XmlApplicationContext(objConfigFilePath);
                //获取按照新配置上下文创建对象
                var obj = _context.GetObject(objConfigName);

                //还原原先的上下文
                _context = oldContex;
                return obj;
            }

            //不是一次性的,永久使用传入的配置文件
            _context = new XmlApplicationContext(objConfigFilePath);
            //获取按照新配置上下文创建对象
            return _context.GetObject(objConfigName);
        }
    }
}
