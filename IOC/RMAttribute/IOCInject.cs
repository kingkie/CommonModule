using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuanMou.ArchitectRelax.DesignMode1.IOC.RMAttribute
{
    /// <summary>
    /// IOC属性过滤特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    class IOCInject : Attribute
    {
        public IOCInject()
        {

        }
    }
}
