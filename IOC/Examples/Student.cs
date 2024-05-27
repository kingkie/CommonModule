using RuanMou.ArchitectRelax.DesignMode1.IOC.RMAttribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuanMou.ArchitectRelax.DesignMode1.IOC.Examples
{
    /// <summary>
    /// 学生类
    /// </summary>
    [IOCService]
    public class Student
    {
        [IOCInject]
        public Teacher teacher { set; get; }

        public void Study()
        {
            teacher.Classes();
            Console.WriteLine("学生开始学习");
        }
    }
}
