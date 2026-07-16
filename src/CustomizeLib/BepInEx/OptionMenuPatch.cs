using System;
using System.Reflection;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;

namespace CustomizeLib.BepInEx;

[HarmonyPatch]
public static class OptionMenuPatch
{
	[HarmonyTargetMethod]
	public static MethodBase GetTargetMethod()
	{
		System.Type[] nestedTypes = typeof(OptionMenu).GetNestedTypes((BindingFlags)20);
		foreach (System.Type type in nestedTypes)
		{
			MethodInfo method = type.GetMethod("_OnLockAlmanacMenu_b__0", (BindingFlags)20);
			if (method != (MethodInfo)null)
			{
				return (MethodBase)(object)method;
			}
		}
		return null;
	}

	[HarmonyPostfix]
	public static void PostOnLockAlmanacMenu()
	{




		var enumerator = GameAPP.resourcesManager.allPlants.GetEnumerator();
		while (enumerator.MoveNext())
		{
			PlantType current = enumerator.Current;
			if (!GameAPP.config.meetPlant_runTime.Contains(current))
			{
				GameAPP.config.meetPlant_runTime.Add(current);
			}
		}
	}
}
