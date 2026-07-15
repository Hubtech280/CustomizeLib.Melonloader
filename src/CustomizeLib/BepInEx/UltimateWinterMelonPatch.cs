using HarmonyLib;
using Unity.VisualScripting;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(UltimateWinterMelon))]
public static class UltimateWinterMelonPatch
{
	[HarmonyPatch("Start")]
	[HarmonyPrefix]
	public static void PreStart(UltimateWinterMelon __instance)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		if (SkinMgr.IsPlantSkinEnable(((Plant)__instance).thePlantType))
		{
			__instance.stage2 = ((Component)(object)__instance).transform.FindChild("WinterMelon/2").gameObject;
			__instance.stage3_1 = ((Component)(object)__instance).transform.FindChild("WinterMelon_melon/3_1").gameObject;
			__instance.stage3_2 = ((Component)(object)__instance).transform.FindChild("WinterMelon_melon/3_2").gameObject;
			((Object)(object)__instance).AddComponent<UltimateWinterMelonSkin>().plant = __instance;
		}
	}
}
