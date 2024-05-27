using System;
using System.Collections.Generic;
using System.Text;

namespace RuanMou.ArchitectRelax.DesignMode1.IOC.Strategy
{
    /// <summary>
    /// Assembly 对象创建策略
    /// </summary>
    public class AssemblyObjectCreateStrategy : IObjectCreateStrategy
    {
        public object CreateObject(Type type)
        {
            return type.Assembly.CreateInstance(type.FullName);
        }
    }
}
