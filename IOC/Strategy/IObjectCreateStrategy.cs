using System;
using System.Collections.Generic;
using System.Text;

namespace RuanMou.ArchitectRelax.DesignMode1.IOC.Strategy
{
    /// <summary>
    /// 对象创建策略
    /// </summary>
    public interface IObjectCreateStrategy
    {
        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public object CreateObject(Type type);
    }
}
