using System;
using System.Reflection;

namespace CustomizeLib.BepInEx.OldVersion;

public static class Il2CppMethods
{
	public static class Il2CppMethodCallingTools
	{
		public static Lazy<Func<string, System.IntPtr>> GetIl2CppImage = new Lazy<Func<string, System.IntPtr>>((Func<Func<string, System.IntPtr>>)(() => Il2CppMethodExtensions.GetIl2CppMethodInfo("GetIl2CppImage", (BindingFlags)40).ToDelegate<Func<string, System.IntPtr>>()));

		public static Lazy<Func<System.IntPtr[]>> GetIl2CppImages = new Lazy<Func<System.IntPtr[]>>((Func<Func<System.IntPtr[]>>)(() => Il2CppMethodExtensions.GetIl2CppMethodInfo("GetIl2CppImages", (BindingFlags)40).ToDelegate<Func<System.IntPtr[]>>()));
	}

	public static System.IntPtr GetIl2CppImage(string name)
	{
		return Il2CppMethodCallingTools.GetIl2CppImage.Value.Invoke(name);
	}

	public static System.IntPtr[] GetIl2CppImages()
	{
		return Il2CppMethodCallingTools.GetIl2CppImages.Value.Invoke();
	}
}
