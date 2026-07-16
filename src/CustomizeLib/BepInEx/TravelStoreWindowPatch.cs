using System;
using HarmonyLib;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(TravelStoreWindow))]
public static class TravelStoreWindowPatch
{
	[HarmonyPatch("SetType")]
	[HarmonyPostfix]
	public static void Postfix(TravelStoreWindow __instance, Il2CppSystem.Object buff)
	{














		ValueTuple<BuffType, int> val = __instance.GeneralSet(buff);
		BuffType item = val.Item1;
		int item2 = val.Item2;
		if (CustomCore.CustomBuffsBg.ContainsKey(new ValueTuple<BuffType, int>(item, item2)))
		{
			__instance.SetBackground((TravelStoreWindow.BgType)CustomCore.CustomBuffsBg[new ValueTuple<BuffType, int>(item, item2)]);
		}
		if (CustomCore.CustomBuffIcon.ContainsKey(new ValueTuple<BuffType, int>(item, item2)))
		{
			if (((BaseWindow)__instance).show != null)
			{
				UnityEngine.Object.Destroy(((BaseWindow)__instance).show);
			}
			((BaseWindow)__instance).SetPlant(CustomCore.CustomBuffIcon[new ValueTuple<BuffType, int>(item, item2)]);
		}
	}
}
