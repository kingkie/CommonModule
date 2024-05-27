using RuanMou.ArchitectRelax.DesignMode1.IOC.RMAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RuanMou.ArchitectRelax.DesignMode1.IOC
{
    /// <summary>
    /// IOC抽象工厂
    /// </summary>
    public abstract class IOCFactory
    {
        /// <summary>
        /// IOC抽象工厂方法
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public abstract object GetObject(string typeName);
    }
}
