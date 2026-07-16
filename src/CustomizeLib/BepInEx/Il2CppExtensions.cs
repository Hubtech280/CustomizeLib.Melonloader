using System;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace CustomizeLib.BepInEx;

public static class Il2CppExtensions
{
	public static Il2CppSystem.Collections.Generic.List<T> ToIl2CppList<T>(this System.Collections.Generic.List<T> list)
	{


		Il2CppSystem.Collections.Generic.List<T> list2 = new Il2CppSystem.Collections.Generic.List<T>();
		System.Collections.Generic.List<T>.Enumerator enumerator = list.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				T current = enumerator.Current;
				list2.Add(current);
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		return list2;
	}

	public static System.Collections.Generic.List<T> ToSystemList<T>(this Il2CppSystem.Collections.Generic.List<T> list)
	{
		System.Collections.Generic.List<T> val = new System.Collections.Generic.List<T>();
		Il2CppSystem.Collections.Generic.List<T>.Enumerator enumerator = list.GetEnumerator();
		while (enumerator.MoveNext())
		{
			T current = enumerator.Current;
			val.Add(current);
		}
		return val;
	}

	public static Il2CppSystem.Collections.Generic.List<T> CreateNewList<T>(this Il2CppSystem.Collections.Generic.List<T> list)
	{
		Il2CppSystem.Collections.Generic.List<T> list2 = new Il2CppSystem.Collections.Generic.List<T>();
		Il2CppSystem.Collections.Generic.List<T>.Enumerator enumerator = list.GetEnumerator();
		while (enumerator.MoveNext())
		{
			T current = enumerator.Current;
			list2.Add(current);
		}
		return list2;
	}

	public static Il2CppSystem.Type ToIl2CppType(this System.Type type)
	{
		if (type == (System.Type)null)
		{
			return null;
		}
		return Il2CppType.From(type);
	}

	public static Il2CppSystem.Array ToArray<T>(this Il2CppReferenceArray<T> array) where T : Il2CppObjectBase
	{
		return array.Cast<Il2CppSystem.Array>();
	}

	public static bool IsTypeOf(this Il2CppSystem.Object obj, System.Type type)
	{
		return obj.GetIl2CppType() == Il2CppType.From(type);
	}

	public static bool IsTypeOf<T>(this Il2CppSystem.Object obj)
	{
		return obj.GetIl2CppType() == Il2CppType.From(typeof(T));
	}

	public static Il2CppSystem.Object BoxEnumToIl2Object<TEnum>(object obj) where TEnum : System.Enum
	{
		return Il2CppSystem.Enum.ToObject(Il2CppType.From(typeof(TEnum)), (int)obj);
	}

	public static Il2CppSystem.Object BoxEnumToIl2Object(object obj, System.Type enumType)
	{
		return Il2CppSystem.Enum.ToObject(Il2CppType.From(enumType), (int)obj);
	}

	public static Il2CppSystem.Object BoxEnumToIl2Object(object obj, Il2CppSystem.Type enumType)
	{
		return Il2CppSystem.Enum.ToObject(enumType, (int)obj);
	}

	public static Il2CppSystem.Type GetIl2CppType(this object obj)
	{
		return Il2CppType.From(obj.GetType());
	}

	public static Il2CppSystem.Nullable<T> GetNullable<T>(this T obj) where T : new()
	{
		return new Il2CppSystem.Nullable<T>(obj);
	}
}
