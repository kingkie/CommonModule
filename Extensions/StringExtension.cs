#region 命名空间

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

using Sharp.Infrastructure;
using Sharp.Infrastructure.Security;

#endregion

namespace System
{
    /// <summary>
    ///     字符型扩展方法
    /// </summary>
    [DebuggerStepThrough]
    public static class StringExtension
    {
        /// <summary>
        ///     转换为Int32
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int ToInt(this string input)
        {
            return Convert.ToInt32(input);
        }

        /// <summary>
        ///     转换字符串数组
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string[] ToArr(this string input)
        {
            return input.Split(new char[] { ',', '|' }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        ///     转换数字数组
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int[] ToArrInt(this string input)
        {
            int i = 0;
            var list = (from s in input.Split(new char[] { ',', '|','[' ,']'}, StringSplitOptions.RemoveEmptyEntries)
                        where int.TryParse(s, out i)
                        select i).ToArray();
            return list;
        }

        /// <summary>
        ///     字符串转化key，value结构
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ToDictionary(this string input)
        {
            var arr =
                input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split('\t'));
            return arr.ToDictionary(v => v[0], v => v[1]);
        }

        /// <summary>
        ///     是否为数字字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string input)
        {
            decimal d;
            return decimal.TryParse(input, out d);
        }

        /// <summary>
        ///     是否可以识别为数字数组
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <remarks>1 2 4</remarks>
        public static bool IsNumericArr(this string input)
        {
            input = Regex.Replace(input, @"\s", "");
            return decimal.TryParse(input, out _);
        }

        /// <summary>
        ///     返回MD5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Md5(this string input)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder(36);

            foreach (byte t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }

            return sBuilder.ToString();
        }
        /// <summary>
        ///    返回SHA1
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Sha1(this string input)
        {
            var hash = SHA1.Create();
            byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        /// <summary>
        ///     去除html
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ClearHtml(this string input)
        {
            return HTML.RemoveHtmlTags(input);
        }

        /// <summary>
        ///     转换到Base64
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToBase64(this string input)
        {
            return Base64Encrypt.ToBase64(input);
        }

        /// <summary>
        ///     从Base64字符串还原字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string FromBase64(this string input)
        {
            return Base64Encrypt.FromBase64(input);
        }

        /// <summary>
        ///     从json字符串转换为类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T FromJson<T>(this string input)
        {
            return SerializableHelper.DeSerialize<T>(input, DataFormart.Json);
        }

        /// <summary>
        ///     从xml字符串转换为类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T FromXml<T>(this string input)
        {
            return SerializableHelper.DeSerialize<T>(input, DataFormart.Xml);
        }

        /// <summary>
        ///     指定字符串是string.Empty
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string value)
        {
            return value == string.Empty;
        }

        /// <summary>
        ///     指定字符串是null还是string.Empty
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
        /// <summary>
        ///     指定字符串不是null还是string.Empty
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNotNullOrEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }
        /// <summary>
        ///     指定字符串是null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNull(this string value)
        {
            return value == null;
        }

        /// <summary>
        ///     数组转成一行
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Inline(this IEnumerable<string> input)
        {
            return "'" + string.Join("','", input) + "'";
        }
    }
}