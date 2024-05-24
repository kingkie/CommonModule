#region 命名空间

using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;

#endregion

namespace System
{
    /// <summary>
    ///     文件扩展方法
    /// </summary>
    [DebuggerStepThrough]
    public static class FileInfoExtension
    {
        /// <summary>
        ///     计算Md5值
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        public static string Md5(this FileInfo fi)
        {
            using (FileStream fileStream = fi.OpenRead())
            {
                MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

                byte[] arrbytHashValue = md5Hasher.ComputeHash(fileStream); //计算指定Stream 对象的哈希值

                //由以连字符分隔的十六进制对构成的String，其中每一对表示value 中对应的元素；例如“F-2C-4A”
                string hashData = BitConverter.ToString(arrbytHashValue);
                //替换-
                hashData = hashData.Replace("-", "");


                return hashData;
            }
        }
    }
}