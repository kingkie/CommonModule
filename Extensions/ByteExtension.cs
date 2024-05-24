using System.Diagnostics;

namespace System
{
    /// <summary>
    ///     Byte类型扩展
    /// </summary>
    [DebuggerStepThrough]
    public static class ByteExtension
    {
        /// <summary>
        ///     是否为空
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>是否为空</returns>
        public static bool IsEmpty(this byte[] value)
        {
            if (value != null)
                return value.Length == 0;

            return false;
        }
    }
}