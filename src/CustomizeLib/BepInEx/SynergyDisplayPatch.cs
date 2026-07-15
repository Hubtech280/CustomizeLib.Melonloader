using HarmonyLib;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(SynergyDisplay))]
public static class SynergyDisplayPatch
{
	[HarmonyPatch("Start")]
	[HarmonyPrefix]
	public static void Prefix()
	{
		if (Utils.IsCustomLevel(out var _))
		{
			GameObject gameObject = ((Component)(object)SynergyManager.Instance).gameObject;
			Object.Destroy((Object)(object)SynergyManager.Instance);
			SynergyManager._instance = gameObject.AddComponent<SynergyManager>();
			GameObject gameObject2 = ((Component)(object)TravelMgr.Instance).gameObject;
			Object.Destroy((Object)(object)TravelMgr.Instance);
			TravelMgr._instance = gameObject2.AddComponent<TravelMgr>();
		}
	}
}
