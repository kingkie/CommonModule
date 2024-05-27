using RuanMou.ArchitectRelax.DesignMode1.IOC.RMAttribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuanMou.ArchitectRelax.DesignMode1.IOC.Examples
{
    /// <summary>
    /// 老师
    /// </summary>
    [IOCService]
    public class Teacher
    {
        //public School school { set; get; }
        public void Classes()
        {
            //school.dfdf();
            Console.WriteLine("老师开始上NET架构班体验课");
        }
    }
}
