using System;
using System.Runtime.CompilerServices;

namespace CustomizeLib.BepInEx.UnmanagedTools;

public static class MemTools
{
	public unsafe static void MemSetByte(System.IntPtr ptr, byte val, uint length)
	{
		byte* ptr2 = (byte*)(void*)ptr;
		for (uint num = 0u; num < length; num++)
		{
			ptr2[num] = val;
		}
	}

	public unsafe static void MemSet<T>(System.IntPtr ptr, T val, uint times) where T : unmanaged
	{
		int num = Unsafe.SizeOf<T>();
		byte* ptr2 = (byte*)(void*)ptr;
		for (uint num2 = 0u; num2 < times; num2++)
		{
			Unsafe.Write(ptr2 + num2 * num, val);
		}
	}

	public unsafe static void MemCpy(System.IntPtr ptr, System.IntPtr target, uint length)
	{
		Buffer.MemoryCopy((void*)ptr, (void*)target, (long)length, (long)length);
	}

	public unsafe static byte[] MemRead(System.IntPtr ptr, uint length)
	{
		byte* ptr2 = (byte*)(void*)ptr;
		byte[] array = new byte[length];
		for (uint num = 0u; num < length; num++)
		{
			array[num] = ptr2[num];
		}
		return array;
	}

	public unsafe static T[] MemRead<T>(System.IntPtr ptr, uint size) where T : unmanaged
	{
		T[] array = new T[size];
		fixed (T* destination = array)
		{
			Unsafe.CopyBlock(destination, (void*)ptr, (uint)(sizeof(T) * size));
		}
		return array;
	}

	public unsafe static byte[] ToBytes<T>(this T value) where T : unmanaged
	{
		byte[] array = new byte[Unsafe.SizeOf<T>()];
		fixed (byte* destination = array)
		{
			Unsafe.Write(destination, value);
		}
		return array;
	}

	public unsafe static int* ToIntPtr(this System.IntPtr ptr)
	{
		return (int*)(void*)ptr;
	}

	public unsafe static T* GetPtr<T>(this ref T self) where T : unmanaged
	{
		fixed (T* result = &self)
		{
			return result;
		}
	}
}
