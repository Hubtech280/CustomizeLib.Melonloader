using System;
using System.Reflection;
using Il2CppInterop.Runtime.InteropTypes;
using UnityEngine;

namespace CustomizeLib.BepInEx;

public static class InterfaceCreator
{
	private static InterfaceBehaviour? Behaviour;

	internal static void InitInstance()
	{
		GameObject gameObject = new GameObject("InterfaceBehaviour");
		Object.DontDestroyOnLoad(gameObject);
		Behaviour = gameObject.AddComponent<InterfaceBehaviour>();
	}

	public static T GetInterfaceInstance<T>() where T : Il2CppObjectBase
	{

		ConstructorInfo constructor = typeof(T).GetConstructor((BindingFlags)52, new System.Type[1] { typeof(System.IntPtr) });
		if (constructor == (ConstructorInfo)null)
		{
			throw new ArgumentException("Cannot find a constructor with a parameter list of IntPtr");
		}
		return (T)constructor.Invoke(new object[1] { Behaviour?.gameObject.Pointer });
	}
}
