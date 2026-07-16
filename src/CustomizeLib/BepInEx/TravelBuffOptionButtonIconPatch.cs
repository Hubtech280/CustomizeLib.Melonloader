using System;
using HarmonyLib;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(TravelBuffOptionButton))]
public static class TravelBuffOptionButtonIconPatch
{
	[HarmonyPatch("SetBuff")]
	[HarmonyPrefix]
	public static void PreSetBuff(TravelBuffOptionButton __instance, Il2CppSystem.Object buff)
	{

		__instance.GeneralSet(buff);
	}

	[HarmonyPatch("SetBuff")]
	[HarmonyPostfix]
	public static void PostSetBuff(TravelBuffOptionButton __instance)
	{








		ValueTuple<BuffType, int> val = __instance.TryGetTypeAndID();
		if (CustomCore.CustomBuffsBg.ContainsKey(val))
		{
			__instance.SetBackground((TravelBuffOptionButton.BgType)CustomCore.CustomBuffsBg[val]);
		}
		if (CustomCore.CustomBuffIcon.ContainsKey(val))
		{
			if (__instance.show.IsObjExist())
			{
				UnityEngine.Object.Destroy(__instance.show.gameObject);
			}
			__instance.SetPlant(CustomCore.CustomBuffIcon[val]);
		}
	}
}
