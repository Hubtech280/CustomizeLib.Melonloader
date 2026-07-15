using HarmonyLib;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(NutFume))]
public static class NutFumePatch
{
	[HarmonyPatch("ReplaceSprite")]
	[HarmonyPrefix]
	public static void PreReplaceSprite(NutFume __instance)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		if (SkinMgr.IsPlantSkinEnable(((Plant)__instance).thePlantType) && __instance.changes.Count <= 0)
		{
			__instance.changes.Add(((Component)(object)__instance).transform.FindChild("FumeShroom_head").gameObject);
			__instance.changes.Add(((Component)(object)__instance).transform.FindChild("FumeShroom_body").gameObject);
		}
	}
}
