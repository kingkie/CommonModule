#region 命名空间

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

#endregion

namespace System
{
    /// <summary>
    ///     集合扩展
    /// </summary>
    [DebuggerStepThrough]
    public static class CollectionExtension
    {
        /// <summary>
        ///     转换数字数组
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static TResult[] ToArrInt<TResult>(this IEnumerable<TResult> input)
        {
            if (input == null) return null;
            return input.OfType<TResult>().ToArray();
        }
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsEmpty<TResult>(this IEnumerable<TResult> input)
        {
            if (input == null)
                return true;

            return !input.Any();
        }
    }
}