using System.Diagnostics;
using Sharp.Infrastructure;

namespace System
{
    /// <summary>
    ///     对象扩展方法
    /// </summary>
    [DebuggerStepThrough]
    public static class ObjectExtension
    {
        /// <summary>
        ///     转换JSON数据
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToJson<TResult>(this TResult input) where TResult : class
        {
            return SerializableHelper.SerializeToString(input, DataFormart.Json);
        }

        /// <summary>
        ///     转换XML数据
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToXml<TResult>(this TResult input) where TResult : class
        {
            return SerializableHelper.SerializeToString(input, DataFormart.Xml);
        }

        /// <summary>
        ///     是否数值型
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNumericType<TResult>(this TResult input) where TResult : struct
        {
            if (input is int) return true;
            if (input is decimal) return true;
            if (input is float) return true;
            if (input is double) return true;

            return false;
        }
    }
}