using System;
using System.Reflection;
using Il2CppInterop.Runtime;

namespace CustomizeLib.BepInEx.OldVersion;

public static class Il2CppMethodExtensions
{
	public static MethodInfo GetIl2CppMethodInfo(string name, BindingFlags flags)
	{

		return typeof(IL2CPP).GetMethod(name, flags);
	}

	public static MethodInfo GetIl2CppMethodInfo(string name, BindingFlags flags, System.Type[] args)
	{

		return typeof(IL2CPP).GetMethod(name, flags, args);
	}

	public static T ToDelegate<T>(this MethodInfo info) where T : System.Delegate
	{
		return (T)info.CreateDelegate(typeof(T));
	}
}
