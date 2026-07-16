using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CustomizeLib.BepInEx.UnmanagedTools;

public static class ObjectPinner
{
	private static readonly List<GCHandle> handles = new List<GCHandle>();

	public static System.IntPtr PinObjectVal(object value)
	{




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
			((System.IDisposable)enumerator).Dispose();
		}
		handles.Clear();
	}
}
