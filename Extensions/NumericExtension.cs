#region 命名空间

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
#endregion

namespace System
{
    /// <summary>
    ///     数值型扩展方法
    /// </summary>
    [DebuggerStepThrough]
    public static class NumericExtension
    {
        /// <summary>
        ///     是否为空
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmpty(this int value)
        {
            return value == 0;
        }

        /// <summary>
        ///     是否为空
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmpty(this int? value)
        {
            if (value != null)
                return ((int)value).IsEmpty();

            return true;
        }

        //big int 
        /// <summary>
        ///     是否为空
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmpty(this Int64 value)
        {
            return value == 0;
        }

        /// <summary>
        ///     是否为空
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmpty(this Int64? value)
        {
            if (value != null)
                return ((Int64)value).IsEmpty();

            return false;
        }


        //float 
        /// <summary>
        ///     是否为空
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmpty(this float value)
        {
            return value == 0;
        }

        /// <summary>
        ///     是否为空
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmpty(this float? value)
        {
            if (value != null)
                return ((float)value).IsEmpty();

            return false;
        }

        //double 
        /// <summary>
        ///     是否为空
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmpty(this double value)
        {
            return value == 0;
        }

        /// <summary>
        ///     是否为空
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmpty(this double? value)
        {
            if (value != null)
                return ((double)value).IsEmpty();

            return false;
        }
        /// <summary>
        ///     数组改单行
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Inline(this IEnumerable<int> input)
        {
            if (input == null || !input.Any())
            {
                return null;
            }
            return string.Join(",", input);
        }
    }
}