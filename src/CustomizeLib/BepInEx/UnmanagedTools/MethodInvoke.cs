using System;
using System.Runtime.InteropServices;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;

namespace CustomizeLib.BepInEx.UnmanagedTools;

public static class MethodInvoke
{
	public static System.IntPtr GetBaseMethodPtr(System.Type baseType, string methodName, System.Type returnType, params System.Type[] paramTypes)
	{

		System.IntPtr nativeClassPointer = Il2CppClassPointerStore.GetNativeClassPointer(baseType);
		if (nativeClassPointer == System.IntPtr.Zero)
		{
			throw new ArgumentException($"Base type {baseType} is not registered in Il2Cpp");
		}
		string returnTypeName = IL2CPP.RenderTypeName(returnType);
		string[] array = new string[paramTypes.Length];
		for (int i = 0; i < paramTypes.Length; i++)
		{
			array[i] = IL2CPP.RenderTypeName(paramTypes[i]);
		}
		return IL2CPP.GetIl2CppMethod(nativeClassPointer, isGeneric: false, methodName, returnTypeName, array);
	}

	public static System.IntPtr GetBaseGenericMethodPtr(System.Type baseType, string methodName, System.Type returnType, params System.Type[] paramTypes)
	{

		System.IntPtr nativeClassPointer = Il2CppClassPointerStore.GetNativeClassPointer(baseType);
		if (nativeClassPointer == System.IntPtr.Zero)
		{
			throw new ArgumentException($"Base type {baseType} is not registered in Il2Cpp");
		}
		string returnTypeName = IL2CPP.RenderTypeName(returnType);
		string[] array = new string[paramTypes.Length];
		for (int i = 0; i < paramTypes.Length; i++)
		{
			array[i] = IL2CPP.RenderTypeName(paramTypes[i]);
		}
		return IL2CPP.GetIl2CppMethod(nativeClassPointer, isGeneric: true, methodName, returnTypeName, array);
	}

	public static System.IntPtr GetBaseMethodPtr(System.Type baseType, string methodName, string returnTypeName, params string[] paramTypeNames)
	{

		System.IntPtr nativeClassPointer = Il2CppClassPointerStore.GetNativeClassPointer(baseType);
		if (nativeClassPointer == System.IntPtr.Zero)
		{
			throw new ArgumentException($"Base type {baseType} is not registered in Il2Cpp");
		}
		return IL2CPP.GetIl2CppMethod(nativeClassPointer, isGeneric: false, methodName, returnTypeName, paramTypeNames);
	}

	public static System.IntPtr GetBaseGenericMethodPtr(System.Type baseType, string methodName, string returnTypeName, params string[] paramTypeNames)
	{

		System.IntPtr nativeClassPointer = Il2CppClassPointerStore.GetNativeClassPointer(baseType);
		if (nativeClassPointer == System.IntPtr.Zero)
		{
			throw new ArgumentException($"Base type {baseType} is not registered in Il2Cpp");
		}
		return IL2CPP.GetIl2CppMethod(nativeClassPointer, isGeneric: true, methodName, returnTypeName, paramTypeNames);
	}

	public static T InvokeBase<T>(System.IntPtr methodPtr, Il2CppObjectBase instance, System.Type returnType, object[] args)
	{
		return InvokeBase<T>(methodPtr, instance, returnType, args, new bool[args.Length]);
	}

	public static T InvokeBase<T>(System.IntPtr methodPtr, Il2CppObjectBase instance, System.Type returnType)
	{
		return InvokeBase<T>(methodPtr, instance, returnType, new object[0], new bool[0]);
	}

	public static void InvokeBase(System.IntPtr methodPtr, Il2CppObjectBase instance, object[] args)
	{
		InvokeBase<object>(methodPtr, instance, typeof(void), args, new bool[args.Length]);
	}

	public static void InvokeBase(System.IntPtr methodPtr, Il2CppObjectBase instance)
	{
		InvokeBase<object>(methodPtr, instance, typeof(void), new object[0], new bool[0]);
	}

	public static void InvokeBase(System.IntPtr methodPtr, Il2CppObjectBase instance, object[] args, bool[] isRefOrOut)
	{
		InvokeBase<object>(methodPtr, instance, typeof(void), args, isRefOrOut);
	}

	public unsafe static T InvokeBase<T>(System.IntPtr methodPtr, Il2CppObjectBase instance, System.Type returnType, object[] args, bool[] isRefOrOut)
	{






		void** ptr = null;
		System.IntPtr[] array = null;
		GCHandle[] array2 = null;
		try
		{
			if (args != null && args.Length != 0)
			{
				ptr = (void**)(void*)Marshal.AllocHGlobal(args.Length * System.IntPtr.Size);
				array = new System.IntPtr[args.Length];
				array2 = (GCHandle[])(object)new GCHandle[args.Length];
				for (int i = 0; i < args.Length; i++)
				{
					if (args[i] == null)
					{
						ptr[i] = (void*)System.IntPtr.Zero;
						continue;
					}
					System.Type type = args[i].GetType();
					if (isRefOrOut != null && i < isRefOrOut.Length && isRefOrOut[i])
					{
						if (type.IsValueType)
						{
							array2[i] = GCHandle.Alloc(args[i], (GCHandleType)3);
					ptr[i] = (void*)array2[i].AddrOfPinnedObject();
							continue;
						}
						array[i] = Marshal.AllocHGlobal(System.IntPtr.Size);
						System.IntPtr intPtr = System.IntPtr.Zero;
						if (type == typeof(string))
						{
							intPtr = IL2CPP.ManagedStringToIl2Cpp((string)args[i]);
						}
						else if (typeof(Il2CppObjectBase).IsAssignableFrom(type))
						{
							intPtr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)args[i]);
						}
						Marshal.WriteIntPtr(array[i], intPtr);
						ptr[i] = (void*)array[i];
					}
					else if (type == typeof(string))
					{
						ptr[i] = (void*)(array[i] = IL2CPP.ManagedStringToIl2Cpp((string)args[i]));
					}
					else if (typeof(Il2CppObjectBase).IsAssignableFrom(type))
					{
						ptr[i] = (void*)(array[i] = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)args[i]));
					}
					else if (type.IsValueType)
					{
						array2[i] = GCHandle.Alloc(args[i], (GCHandleType)3);
						System.IntPtr intPtr2 = array2[i].AddrOfPinnedObject();
						ptr[i] = (void*)intPtr2;
					}
					else
					{
						ptr[i] = (void*)System.IntPtr.Zero;
					}
				}
			}
			System.IntPtr exc = System.IntPtr.Zero;
			System.IntPtr objectPointer = IL2CPP.il2cpp_runtime_invoke(methodPtr, instance?.Pointer ?? System.IntPtr.Zero, ptr, ref exc);
			if (exc != System.IntPtr.Zero)
			{
				Il2CppException.RaiseExceptionIfNecessary(exc);
			}
			if (isRefOrOut != null && args != null)
			{
				for (int j = 0; j < args.Length && j < isRefOrOut.Length; j++)
				{
					if (!isRefOrOut[j] || !(array[j] != System.IntPtr.Zero))
					{
						continue;
					}
					System.Type type2 = args[j].GetType();
					if (!type2.IsValueType)
					{
						System.IntPtr intPtr3 = Marshal.ReadIntPtr(array[j]);
						if (type2 == typeof(string))
						{
							args[j] = IL2CPP.Il2CppStringToManaged(intPtr3);
						}
						else if (typeof(Il2CppObjectBase).IsAssignableFrom(type2))
						{
							args[j] = IL2CPP.PointerToValueGeneric<object>(intPtr3, isFieldPointer: false, valueTypeWouldBeBoxed: false);
						}
					}
					else if (array2[j].IsAllocated)
					{
						args[j] = Marshal.PtrToStructure(array2[j].AddrOfPinnedObject(), type2);
					}
				}
			}
			if (returnType != (System.Type)null && returnType != typeof(void))
			{
				return IL2CPP.PointerToValueGeneric<T>(objectPointer, isFieldPointer: false, valueTypeWouldBeBoxed: false);
			}
			return default(T);
		}
		finally
		{
			if (array != null)
			{
				System.IntPtr[] array3 = array;
				foreach (System.IntPtr intPtr4 in array3)
				{
					if (intPtr4 != System.IntPtr.Zero)
					{
						Marshal.FreeHGlobal(intPtr4);
					}
				}
			}
			if (array2 != null)
			{
				GCHandle[] array4 = array2;
				for (int l = 0; l < array4.Length; l++)
				{
					GCHandle val = array4[l];
					if (val.IsAllocated)
					{
						val.Free();
					}
				}
			}
			if (ptr != null)
			{
				Marshal.FreeHGlobal((System.IntPtr)(void*)ptr);
			}
		}
	}

	public static string MakeRef(this string str)
	{
		return str + "&";
	}

	public static string MakeOut(this string str)
	{
		return str + "&";
	}
}
