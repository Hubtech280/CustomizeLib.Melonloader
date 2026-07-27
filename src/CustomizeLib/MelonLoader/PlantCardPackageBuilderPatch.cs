using HarmonyLib;
using UnityEngine;

namespace CustomizeLib.MelonLoader;

[HarmonyPatch(typeof(PlantCardPackageBuilder))]
public static class PlantCardPackageBuilderPatch
{
	[HarmonyPatch("Start")]
	[HarmonyPostfix]
	public static void PostStart(PlantCardPackageBuilder __instance)
	{
		SelectCustomPlants.InitButton();
		PatchMgr.ShowCustomCards((MonoBehaviour)(object)__instance);
	}
}
