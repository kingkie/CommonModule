#region 命名空间

using System;
using System.Diagnostics;
using Sharp.Infrastructure;

#endregion

namespace System
{
    /// <summary>
    ///     日期类扩展
    /// </summary>
    [DebuggerStepThrough]
    public static class DateTimeExtension
    {
        /// <summary>
        ///     是否为空
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmpty(this DateTime value)
        {
            return value == DateTime.MinValue;
        }

        /// <summary>
        ///     是否为空
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmpty(this DateTime? value)
        {
            if (value != null)
                return ((DateTime) value).IsEmpty();

            return false;
        }

        /// <summary>
        ///     时间差，默认相差选项为天
        /// </summary>
        /// <param name="value"></param>
        /// <param name="endDate"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
        public static double DateDiff(this DateTime? value, DateTime? endDate,
            DateDiffOption interval = DateDiffOption.Day)
        {
            return MyDateTime.DateDiff(interval, value, endDate);
        }

        private static readonly DateTime Jan1St1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        /// <summary>
        /// 当前时间间隔 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static long CurrentTimeMillis(this DateTime d)
        {
            return (long)(DateTime.UtcNow - Jan1St1970).TotalMilliseconds;
        }
    }
}