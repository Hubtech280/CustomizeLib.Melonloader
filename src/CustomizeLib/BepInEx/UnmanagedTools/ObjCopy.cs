using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CustomizeLib.BepInEx.UnmanagedTools;

public static class ObjCopy
{
	public static void CopyFieldAndProp(object source, object target, System.Collections.Generic.IEnumerable<System.Type>? skipTypes = null, System.Collections.Generic.IEnumerable<string>? skipStrs = null)
	{

		if (source == null || target == null)
		{
			throw new ArgumentNullException("源对象和目标对象均不可为空。");
		}
		if (skipTypes == null)
		{
			skipTypes = (System.Collections.Generic.IEnumerable<System.Type>?)new List<System.Type>();
		}
		if (skipStrs == null)
		{
			skipStrs = (System.Collections.Generic.IEnumerable<string>?)new List<string>();
		}
		System.Type type = source.GetType();
		System.Type type2 = target.GetType();
		FieldInfo[] fields = type.GetFields((BindingFlags)52);
		FieldInfo[] array = fields;
		foreach (FieldInfo val in array)
		{
			FieldInfo field = type2.GetField(((MemberInfo)val).Name, (BindingFlags)52);
			if (field != (FieldInfo)null && field.FieldType == val.FieldType && !Enumerable.Contains<System.Type>(skipTypes, field.FieldType) && !Enumerable.Contains<string>(skipStrs, ((MemberInfo)field).Name) && !Enumerable.Contains<System.Type>(skipTypes, val.FieldType) && !Enumerable.Contains<string>(skipStrs, ((MemberInfo)val).Name))
			{
				object value = val.GetValue(source);
				field.SetValue(target, value);
			}
		}
		PropertyInfo[] properties = type.GetProperties((BindingFlags)52);
		PropertyInfo[] array2 = properties;
		foreach (PropertyInfo val2 in array2)
		{
			if (val2.GetIndexParameters().Length == 0 && val2.CanRead)
			{
				PropertyInfo property = type2.GetProperty(((MemberInfo)val2).Name, (BindingFlags)52);
				if (property != (PropertyInfo)null && property.CanWrite && property.PropertyType == val2.PropertyType && !Enumerable.Contains<System.Type>(skipTypes, property.PropertyType) && !Enumerable.Contains<string>(skipStrs, ((MemberInfo)property).Name) && !Enumerable.Contains<System.Type>(skipTypes, val2.PropertyType) && !Enumerable.Contains<string>(skipStrs, ((MemberInfo)val2).Name))
				{
					object value2 = val2.GetValue(source);
					property.SetValue(target, value2);
				}
			}
		}
	}

	public static void CopyFieldAndPropTo(this object source, object target, System.Collections.Generic.IEnumerable<System.Type>? skipTypes = null, System.Collections.Generic.IEnumerable<string>? skipStrs = null)
	{
		CopyFieldAndProp(source, target, skipTypes, skipStrs);
	}
}
