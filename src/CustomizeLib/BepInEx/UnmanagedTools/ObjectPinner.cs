using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CustomizeLib.BepInEx.UnmanagedTools;

public static class ObjectPinner
{
	private static readonly List<GCHandle> handles = new List<GCHandle>();

	public static System.IntPtr PinObjectVal(object value)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		GCHandle val = GCHandle.Alloc(value, (GCHandleType)3);
		handles.Add(val);
		return val.AddrOfPinnedObject();
	}

	public static System.IntPtr PinObjectRef(object value)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		GCHandle val = GCHandle.Alloc(value, (GCHandleType)3);
		handles.Add(val);
		return val.AddrOfPinnedObject();
	}

	public static void Release()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		var enumerator = handles.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				GCHandle current = enumerator.Current;
				if (current.IsAllocated)
				{
					current.Free();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
		}
		handles.Clear();
	}
}
