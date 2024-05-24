#region 命名空间

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

#endregion

namespace System
{
    /// <summary>
    ///     Guid 类型扩展方法
    /// </summary>
    [DebuggerStepThrough]
    public static class GuidExtension
    {
        /// <summary>
        ///     是否为空
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmpty(this Guid value)
        {
            return value == Guid.Empty;
        }

        /// <summary>
        ///     是否为空
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmpty(this Guid? value)
        {
            if (value != null)
            {
                return ((Guid) value).IsEmpty();
            }

            return true;
        }

        /// <summary>
        ///     数组改单行
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Inline(this IEnumerable<Guid> input)
        {
            if (input == null || !input.Any())
            {
                return null;
            }
            return "'" + string.Join("','", input) + "'";
        }
    }
}