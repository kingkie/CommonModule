using RuanMou.ArchitectRelax.DesignMode1.IOC.Examples;
using RuanMou.ArchitectRelax.DesignMode1.IOC.RMAttribute;
using RuanMou.ArchitectRelax.DesignMode1.IOC.Strategy;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RuanMou.ArchitectRelax.DesignMode1.IOC
{
    /// <summary>
    /// 创建一个IOC工厂（通用）
    /// List
    /// Set
    /// 字典：选择
    /// 集合当中
    /// （保证查询效率和唯一性）
    /// </summary>
    public class DefaultIOCFactory
    {
        /// <summary>
        /// 1、IOC容器(存储对象)
        /// </summary>
        private Dictionary<string, object> iocContainer = new Dictionary<string, object>();

        /// <summary>
        /// 1、IOCType容器(存储对象)
        /// </summary>
        private Dictionary<string, Type> iocTypeContainer = new Dictionary<string, Type>();

        /// <summary>
        /// 创建IOC工厂
        /// 1、创建对象 目标1
        /// 2、存储对象 目标2
        /// 3、对象属性赋值 目标3
        /// 
        /// 
        /// </summary>
        public DefaultIOCFactory()
        {
            /*Student student = new Student();
            Teacher teacher = new Teacher();
            // 1、违背开闭原则。*/

            // 1、加载项目中所有类型(反射类型的集合)
            Assembly assembly = Assembly.Load("RuanMou.ArchitectRelax.DesignMode1");
            // 2、使用反射从程序集获取对象类型
            Type[] types = assembly.GetTypes();
            foreach (var type in types)
            {
                iocTypeContainer.Add(type.FullName, type);
            }
            foreach (var type in types)
            {
                // 2.1 创建对象（student）
                object _oject = CreateObject(type, types);

                // 3、如何存储对象
                // 1、字典 如何选择key 1、好记 2、唯一性
                // GUID 12312-12312ada 雪花算法 12312312424243
                // 命令空间+类名
                iocContainer.Add(type.FullName, _oject);
            }
        }

        /// <summary>
        /// 如何使用递归
        /// 1、从代码逻辑中找到通用的代码
        /// 2、从通用的代码中找到通用的参数
        /// 3、开始自己调用自己了
        /// 
        /// 空间换时间的算法思想
        /// 
        /// 时间换空间：局部临时变量实现
        /// 1、VIP课程里面
        /// </summary>

        public object CreateObject(Type type,Type[] types)
        {
            object _object= Activator.CreateInstance(type);// Teacher

            // Teacher---School----City
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                /*foreach (var type1 in types)
                {
                    if (propertyInfo.PropertyType.FullName.Equals(type1.FullName))
                    {*/
                        Type type1 = iocTypeContainer[propertyInfo.PropertyType.FullName];
                        object _objectvalue = CreateObject(type1,types);
                        propertyInfo.SetValue(_object, _objectvalue);
                 /*   }
                }*/
            }
            return _object;
        }

    }
}
