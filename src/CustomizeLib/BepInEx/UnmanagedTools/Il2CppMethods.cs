using System;
using System.Collections.Generic;
using System.Reflection;

namespace CustomizeLib.BepInEx.UnmanagedTools;

public static class Il2CppMethods
{
	public static Dictionary<string, System.Delegate> CachedMethod = new Dictionary<string, System.Delegate>();

	public static T GetIl2CppMethod<T>(string name) where T : System.Delegate
	{
		System.Delegate obj = default(System.Delegate);
		if (!CachedMethod.TryGetValue(name, out obj))
		{
			T val = Il2CppMethodExtensions.GetIl2CppMethodInfo(name, (BindingFlags)60).ToDelegate<T>();
			if (!CachedMethod.ContainsKey(name))
			{
				CachedMethod.Add(name, (System.Delegate)val);
			}
			return val;
		}
		return (T)obj;
	}
}
