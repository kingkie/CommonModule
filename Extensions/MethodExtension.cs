using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// Method 扩展方法
    /// </summary>
    public static class MethodExtension
    {
        /// <summary>
        /// 有返回值的扩展方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="isi"></param>
        /// <param name="call"></param>
        /// <returns></returns>
        public static TResult SafeInvoke<T, TResult>(this T isi, Func<T, TResult> call) where T : ISynchronizeInvoke
        {
            if (isi.InvokeRequired)
            {
                IAsyncResult result = isi.BeginInvoke(call, new object[] { isi });
                object endResult = isi.EndInvoke(result);
                return (TResult)endResult;
            }
            else
            {
                return call(isi);
            }
        }

        /// <summary>
        /// 没有返回值的扩展方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="isi"></param>
        /// <param name="call"></param>
        public static void SafeInvoke<T>(this T isi, Action<T> call) where T : ISynchronizeInvoke
        {
            if (isi.InvokeRequired)
                isi.BeginInvoke(call, new object[] {isi});
            else
                call(isi);
        }
    }
}