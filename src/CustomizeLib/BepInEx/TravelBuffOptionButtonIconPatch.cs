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
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		__instance.GeneralSet(buff);
	}

	[HarmonyPatch("SetBuff")]
	[HarmonyPostfix]
	public static void PostSetBuff(TravelBuffOptionButton __instance)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
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
