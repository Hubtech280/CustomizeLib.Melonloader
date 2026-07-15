using System;
using System.Collections.Concurrent;

namespace CustomizeLib.BepInEx.UnmanagedTools;

/// <summary>
/// In-process replacement for the old BepInEx preloader patcher. MelonLoader
/// does not load BepInEx patchers, so the pointer map is kept by the mod itself.
/// </summary>
public static class MapValue
{
	private static readonly ConcurrentDictionary<IntPtr, ValueTuple<IntPtr, int>> Values = new();

	internal static void InitDatas()
	{
		// Kept for source and binary API compatibility.
	}

	public static void SetMap(IntPtr key, IntPtr value, int size)
	{
		Values[key] = new ValueTuple<IntPtr, int>(value, size);
	}

	public static ValueTuple<IntPtr, int> GetMap(IntPtr key)
	{
		return Values.TryGetValue(key, out ValueTuple<IntPtr, int> value)
			? value
			: default;
	}

	public static void RemoveMap(IntPtr key)
	{
		Values.TryRemove(key, out _);
	}
}
