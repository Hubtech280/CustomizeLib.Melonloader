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
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
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
