using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using HarmonyLib;
using Il2CppInterop.Runtime.Injection;
using UnityEngine;

namespace CustomizeLib.BepInEx;

public static class Tools
{
	public static Assembly Assembly => Assembly.GetCallingAssembly();

	public static Assembly GetAssembly()
	{
		return Assembly.GetCallingAssembly();
	}

	public static void InitMod(bool skipRegister = false)
	{
		InitMod(Assembly.GetCallingAssembly(), skipRegister);
	}

	public static void InitMod(Assembly assembly, bool skipRegister = false)
	{
		Console.OutputEncoding = Encoding.UTF8;
		if (!skipRegister)
		{
			System.Type[] allMonoBehaviourTypes = GetAllMonoBehaviourTypes(assembly);
			System.Type[] array = allMonoBehaviourTypes;
			foreach (System.Type type in array)
			{
				if (!ClassInjector.IsTypeRegisteredInIl2Cpp(type))
				{
					ClassInjector.RegisterTypeInIl2Cpp(type);
				}
			}
		}
		HarmonyLib.Harmony.CreateAndPatchAll(assembly);
	}

	public static System.Type[] GetAllMonoBehaviourTypes(Assembly assembly)
	{
		//IL_0037: Expected O, but got Unknown
		try
		{
			System.Type[] types = assembly.GetTypes();
			return Enumerable.ToArray<System.Type>(Enumerable.Where<System.Type>((System.Collections.Generic.IEnumerable<System.Type>)types, (Func<System.Type, bool>)((System.Type type) => typeof(MonoBehaviour).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface)));
		}
		catch (ReflectionTypeLoadException ex)
		{
			ReflectionTypeLoadException ex2 = ex;
			return Enumerable.ToArray<System.Type>(Enumerable.Where<System.Type>((System.Collections.Generic.IEnumerable<System.Type>)ex2.Types, (Func<System.Type, bool>)((System.Type type) => type != (System.Type)null && typeof(MonoBehaviour).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface)));
		}
	}
}
