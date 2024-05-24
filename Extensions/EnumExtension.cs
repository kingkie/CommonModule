#region 命名空间

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

#endregion

namespace System
{
    /// <summary>
    ///     枚举类型扩展方法
    /// </summary>
    [DebuggerStepThrough]
    public static class EnumExtension
    {
        /// <summary>
        ///     得到Flags特性的枚举的集合
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static IList<Enum> GetEnumValuesFromFlagsEnum(Enum value)
        {
            List<Enum> values = Enum.GetValues(value.GetType()).Cast<Enum>().ToList();
            List<Enum> res = new List<Enum>();
            foreach (var itemValue in values)
            {
                if ((value.GetHashCode() & itemValue.GetHashCode()) != 0)
                    res.Add(itemValue);
            }
            return res;
        }

        /// <summary>
        ///     获取枚举变量值的 Description 属性
        /// </summary>
        /// <param name="obj">枚举变量</param>
        /// <returns>如果包含 Description 属性，则返回 Description 属性的值，否则返回枚举变量值的名称</returns>
        public static string GetDescription(this Enum obj)
        {
            string description = string.Empty;
            try
            {
                Type _enumType = obj.GetType();
                DescriptionAttribute dna = null;
                FieldInfo fi = null;
                var fields = _enumType.GetCustomAttributesData();

                if (!fields.Where(i => i.Constructor.DeclaringType.Name == "FlagsAttribute").Any())
                {
                    fi = _enumType.GetField(Enum.GetName(_enumType, obj));
                    dna = (DescriptionAttribute) Attribute.GetCustomAttribute(fi, typeof (DescriptionAttribute));
                    if (dna != null && string.IsNullOrEmpty(dna.Description) == false)
                        return dna.Description;
                    return null;
                }

                GetEnumValuesFromFlagsEnum(obj).ToList().ForEach(i =>
                {
                    fi = _enumType.GetField(Enum.GetName(_enumType, i));
                    dna = (DescriptionAttribute) Attribute.GetCustomAttribute(fi, typeof (DescriptionAttribute));
                    if (dna != null && string.IsNullOrEmpty(dna.Description) == false)
                        description += dna.Description + ",";
                });

                return description.EndsWith(",")
                    ? description.Remove(description.LastIndexOf(','))
                    : description;
            }
            catch
            {
                throw;
            }
        }
    }
}