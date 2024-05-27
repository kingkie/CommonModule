using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuanMou.ArchitectRelax.DesignMode1.IOC.RMAttribute
{
    /// <summary>
    /// IOC类型过滤特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class IOCService :Attribute
    {
        public IOCService()
        {

        }
    }
}
