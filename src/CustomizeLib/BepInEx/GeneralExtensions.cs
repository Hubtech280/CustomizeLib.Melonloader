using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CustomizeLib.BepInEx;

public static class GeneralExtensions
{
	public static void Swap<T>(ref T a, ref T b)
	{
		T val = a;
		T val2 = b;
		b = val;
		a = val2;
	}

	public static T GetRandomItem<T>(this System.Collections.Generic.IList<T> list)
	{
		return list[Random.RandomRangeInt(0, ((System.Collections.Generic.ICollection<T>)list).Count)];
	}

	public static List<ValueTuple<T1, T2>> ToEnumList<T1, T2>(this List<ValueTuple<int, int>> list) where T1 : System.Enum where T2 : System.Enum
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		List<ValueTuple<T1, T2>> val = new List<ValueTuple<T1, T2>>();
		var enumerator = list.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ValueTuple<int, int> current = enumerator.Current;
				int item = current.Item1;
				int item2 = current.Item2;
				val.Add(new ValueTuple<T1, T2>(item.ToEnumVal<T1>(), item2.ToEnumVal<T2>()));
			}
		}
		finally
		{
			((System.IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
		}
		return val;
	}

	public static List<ValueTuple<int, int>> ToIntegerList<T1, T2>(this List<ValueTuple<T1, T2>> list) where T1 : System.Enum where T2 : System.Enum
	{
		return Enumerable.ToList<ValueTuple<int, int>>(Enumerable.Select<ValueTuple<T1, T2>, ValueTuple<int, int>>((System.Collections.Generic.IEnumerable<ValueTuple<T1, T2>>)list, (Func<ValueTuple<T1, T2>, ValueTuple<int, int>>)((ValueTuple<T1, T2> tuple) => new ValueTuple<int, int>(tuple.Item1.ToIntVal(), tuple.Item2.ToIntVal()))));
	}

	public static T ToEnumVal<T>(this int value) where T : System.Enum
	{
		return (T)System.Enum.ToObject(typeof(T), value);
	}

	public static int ToIntVal<T>(this T value) where T : System.Enum
	{
		return (int)System.Enum.ToObject(typeof(T), (object)value);
	}
}
