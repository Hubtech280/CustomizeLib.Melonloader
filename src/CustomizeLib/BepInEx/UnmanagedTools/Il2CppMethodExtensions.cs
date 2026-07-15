using System;
using System.Reflection;
using Il2CppInterop.Runtime;

namespace CustomizeLib.BepInEx.UnmanagedTools;

public static class Il2CppMethodExtensions
{
	public static MethodInfo GetIl2CppMethodInfo(string name, BindingFlags flags)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		return typeof(IL2CPP).GetMethod(name, flags);
	}

	public static MethodInfo GetIl2CppMethodInfo(string name, BindingFlags flags, System.Type[] args)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		return typeof(IL2CPP).GetMethod(name, flags, args);
	}

	public static T ToDelegate<T>(this MethodInfo info) where T : System.Delegate
	{
		return (T)info.CreateDelegate(typeof(T));
	}
}
